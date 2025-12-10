import { useState, useEffect, useCallback } from 'react';
import { Layout, Loading, DetailsPageData, RoutingWarningModal, DetailsPageHeader } from '../shared/layout/index';
import { useParams, useBlocker } from 'react-router-dom';
import { Row, Col, Button } from 'antd';
import config from '../../storage/catalog-config/person-request';
import DetermineStudentModal from './determine-student-modal';
import { useGetSimilarStudentsQuery } from '../../storage/service/student-api';

const RequestDetailsPage = () => {
  const { id } = useParams();
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const [requestData, setRequestData] = useState<Record<string, any>>({});
  const [isChanged, setIsChanged] = useState(false);
  const [isSaveInProgress] = useState(false);
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const [initialData, setInitialData] = useState<Record<string, any>>({});
  const [isModalOpen, setIsModalOpen] = useState(false);
  const { properties, crud } = config;
  const { useGetOneByIdAsync, useEditOneAsync } = crud;
  const { data, isLoading, isFetching } = useGetOneByIdAsync(id);

  const [editRequest] = useEditOneAsync();

  const fullname = `${requestData.family || ''} ${requestData?.name || ''} ${requestData?.patron || ''}`.trim();
  const { data: similarStudents, isLoading: isLoadingSimilar } = useGetSimilarStudentsQuery(
    {
      fullname,
      adress: requestData.address || '',
      email: requestData.email || '',
      phone: requestData.phone || '',
    },
    { skip: !isModalOpen },
  );

  useEffect(() => {
    if (!isLoading && !isFetching) {
      const newData = { ...data };
      delete newData.id;
      setRequestData(newData);
      setInitialData(newData);
    }
  }, [isLoading, isFetching, data]);

  let blocker = useBlocker(
    ({ currentLocation, nextLocation }) => isChanged && currentLocation.pathname !== nextLocation.pathname,
  );

  const onSave = useCallback(() => {
    editRequest({ id, item: requestData });
    setIsChanged(false);
  }, [editRequest, id, requestData]);

  const onCancel = useCallback(() => {
    setRequestData(initialData);
    setIsChanged(false);
  }, [initialData]);

  const handleOpenModal = useCallback(() => {
    setIsModalOpen(true);
  }, []);

  const title = `Заявки - ${requestData.family} ${requestData?.name} ${requestData?.patron}`;

  return isLoading || isFetching ? (
    <Loading />
  ) : (
    <Layout>
      <DetailsPageHeader title={title} />
      <h2 style={{ padding: '3vh' }}>
        {requestData.family} {requestData?.name} {requestData?.patron}
      </h2>
      <DetailsPageData items={properties} data={requestData} editData={setRequestData} setIsChanged={setIsChanged} />
      <hr />
      <Row>
        <Col>
          <Button onClick={onSave} style={{ marginRight: '10px' }}>
            Сохранить
          </Button>
        </Col>
        <Col>
          <Button onClick={onCancel} disabled={isSaveInProgress} style={{ marginRight: '10px' }}>
            Отмена
          </Button>
        </Col>
        <Col>
          <Button onClick={handleOpenModal} style={{ marginRight: '10px' }}>
            Определить студента
          </Button>
        </Col>
      </Row>
      <DetermineStudentModal
        open={isModalOpen}
        onClose={() => setIsModalOpen(false)}
        students={similarStudents}
        isLoading={isLoadingSimilar}
      />
      <RoutingWarningModal show={blocker.state === 'blocked'} blocker={blocker} />
    </Layout>
  );
};

export default RequestDetailsPage;
