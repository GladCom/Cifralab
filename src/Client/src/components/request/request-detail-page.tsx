import { useState, useEffect, useCallback } from 'react';
import { Layout, Loading, RoutingWarningModal, DetailsPageHeader } from '../shared/layout/index';
import { useParams, useBlocker } from 'react-router-dom';
import { Row, Col, Button } from 'antd';
import { personRequestConfig } from '../../storage/catalog-config/person-request';
import { DetailsPageData } from '../shared/layout/details-page-data';
import type { RequestDTO } from '../../storage/service/types';

export const RequestDetailPage = () => {
  const { id } = useParams();
  const [requestData, setRequestData] = useState<RequestDTO>();
  const [initialData, setInitialData] = useState<RequestDTO>();
  const [isChanged, setIsChanged] = useState(false);
  const [isSaveInProgress] = useState(false);
  const { formModel, crud } = personRequestConfig;
  const { useGetOneByIdAsync, useEditOneAsync } = crud;
  const { data: personRequestData, isLoading, isFetching } = useGetOneByIdAsync(id);

  const [editRequest] = useEditOneAsync();

  useEffect(() => {
    if (!isLoading && !isFetching) {
      const newData = { ...personRequestData };
      delete newData.id;
      setRequestData(newData);
      setInitialData(newData);
    }
  }, [isLoading, isFetching, personRequestData]);

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

  if (!requestData) {
    return <Loading />;
  }

  const title = `Заявки - ${requestData?.family} ${requestData?.name} ${requestData?.patron}`;

  return isLoading || isFetching ? (
    <Loading />
  ) : (
    <Layout>
      <DetailsPageHeader title={title} />
      <h2 style={{ padding: '3vh' }}>
        {requestData.family} {requestData?.name} {requestData?.patron}
      </h2>
      <DetailsPageData items={formModel} data={requestData} editData={setRequestData} setIsChanged={setIsChanged} />
      <hr />
      <Row>
        <Col>
          <Button onClick={onSave} style={{ marginRight: '10px' }}>
            Сохранить
          </Button>
        </Col>
        <Col>
          <Button onClick={onCancel} disabled={isSaveInProgress}>
            Отмена
          </Button>
        </Col>
      </Row>
      <RoutingWarningModal show={blocker.state === 'blocked'} blocker={blocker} />
    </Layout>
  );
};
