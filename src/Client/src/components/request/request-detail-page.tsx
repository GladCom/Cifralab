import React, { useState, useEffect, useCallback } from 'react';
import { Layout, Loading, DetailsPageData, RoutingWarningModal, DetailsPageHeader } from '../shared/layout/index';
import { useParams, useBlocker } from 'react-router-dom';
import { Row, Col, Space, Button } from 'antd';
import config from '../../storage/catalog-configs/person-requests';

const RequestDetailsPage = () => {
  const { id } = useParams();
  const [requestData, setRequestData] = useState({});
  const [isChanged, setIsChanged] = useState(false);
  const [isSaveInProgress, setIsSaveInProgress] = useState(false);
  const [initialData, setInitialData] = useState({});
  const { properties, crud } = config;
  const { useGetOneByIdAsync, useEditOneAsync } = crud;
  const { data, isLoading, isFetching, refetch } = useGetOneByIdAsync(id);

  const [editRequest] = useEditOneAsync();

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
  }, [id, requestData]);

  const onCancel = useCallback(() => {
    setRequestData(initialData);
    setIsChanged(false);
  }, [initialData]);

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
          <Button onClick={onCancel} disabled={isSaveInProgress}>
            Отмена
          </Button>
        </Col>
      </Row>
      <RoutingWarningModal show={blocker.state === 'blocked'} blocker={blocker} />
    </Layout>
  );
};

export default RequestDetailsPage;
