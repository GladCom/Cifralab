import React, { useState, useEffect, useCallback } from 'react';
import { Layout, Loading, DetailsPageData } from '../shared/layout/index.js';
import { useParams } from 'react-router-dom';
import { Row, Col, Space, Button } from 'antd';
import config from '../../storage/catalogConfigs/personRequests.js';


const RequestDetailsPage = () => {
    const { id } = useParams();
    const [requestData, setRequestData] = useState({});
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
    }, [isLoading, isFetching]);

    const onSave = useCallback(() => {
        editRequest({ id, item: requestData });
    },[id,requestData]);

    const onCancel = useCallback(() => {
        setRequestData(initialData);
    }, [initialData]);

    return isLoading || isFetching
    ? (<Loading />)
    : (
        <Layout title={`Заявки - ${requestData.family} ${requestData?.name} ${requestData?.patron}`}>
            <h2>{requestData.family} {requestData?.name} {requestData?.patron}</h2>
            <DetailsPageData
                items={properties}
                data={requestData}
                editData={setRequestData}
            />
            <hr />
            <Row>
                <Col>
                    <Button onClick={onSave} style={{ marginRight: '10px' }}>Сохранить</Button>
                </Col>
                <Col>
                    <Button onClick={onCancel}>Отмена</Button>
                </Col>
            </Row>
        </Layout>
  );
};

export default RequestDetailsPage;