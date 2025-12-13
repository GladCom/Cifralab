import { useState, useEffect, useCallback } from 'react';
import { Layout, Loading, RoutingWarningModal, DetailsPageHeader } from '../shared/layout/index';
import { useParams, useBlocker } from 'react-router-dom';
import { Row, Col, Button } from 'antd';
import { DetermineStudentModal } from './determine-student-modal';
import { useGetSimilarStudentsQuery } from '../../storage/service/student-api';
import { personRequestConfig } from '../../storage/catalog-config/person-request';
import { DetailsPageData } from '../shared/layout/details-page-data';
import { RequestDTO } from '../../storage/service/types';

const isRequestDTO = (data: unknown): data is RequestDTO => {
  return typeof data === 'object' && data !== null;
};

const getRequestDTO = (data: unknown): RequestDTO | undefined => {
  return isRequestDTO(data) ? data : undefined;
};

export const RequestDetailPage = () => {
  const { id } = useParams();
  const [requestData, setRequestData] = useState<RequestDTO | undefined>(getRequestDTO({}));
  const [isChanged, setIsChanged] = useState(false);
  const [isSaveInProgress] = useState(false);
  const [initialData, setInitialData] = useState<RequestDTO | undefined>(getRequestDTO({}));
  const [isModalOpen, setIsModalOpen] = useState(false);
  const { crud, formModel } = personRequestConfig;
  const { useGetOneByIdAsync, useEditOneAsync } = crud;
  const { data: personRequestData, isLoading, isFetching } = useGetOneByIdAsync(id);

  const [editRequest] = useEditOneAsync();

  const fullname = `${requestData?.family || ''} ${requestData?.name || ''} ${requestData?.patron || ''}`.trim();
  const { data: similarStudents, isLoading: isLoadingSimilar } = useGetSimilarStudentsQuery(
    {
      fullname,
      adress: requestData?.address || '',
      email: requestData?.email || '',
      phone: requestData?.phone || '',
    },
    { skip: !isModalOpen },
  );

  useEffect(() => {
    if (!isLoading && !isFetching) {
      const newData = { ...personRequestData };
      delete newData.id;
      const requestDTO = getRequestDTO(newData);
      if (requestDTO) {
        setRequestData(requestDTO);
        setInitialData(requestDTO);
      }
    }
  }, [isLoading, isFetching, personRequestData]);

  let blocker = useBlocker(
    ({ currentLocation, nextLocation }) => isChanged && currentLocation.pathname !== nextLocation.pathname,
  );

  const onSave = useCallback(() => {
    if (requestData) {
      editRequest({ id, item: requestData });
      setIsChanged(false);
    }
  }, [editRequest, id, requestData]);

  const onCancel = useCallback(() => {
    setRequestData(initialData);
    setIsChanged(false);
  }, [initialData]);

  const handleOpenModal = useCallback(() => {
    setIsModalOpen(true);
  }, []);

  const title = `Заявки - ${requestData?.family || ''} ${requestData?.name || ''} ${requestData?.patron || ''}`;

  return isLoading || isFetching ? (
    <Loading />
  ) : (
    <Layout>
      <DetailsPageHeader title={title} />
      <h2 style={{ padding: '3vh' }}>
        {requestData?.family} {requestData?.name} {requestData?.patron}
      </h2>
      {requestData && (
        <DetailsPageData items={formModel} data={requestData} editData={setRequestData} setIsChanged={setIsChanged} />
      )}
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
