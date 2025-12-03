import React, { useState, useEffect, useCallback } from 'react';
import { Layout, Loading, DetailsPageData, RoutingWarningModal, DetailsPageHeader } from '../shared/layout/index';
import { useParams, useBlocker } from 'react-router-dom';
import { Row, Col, Button } from 'antd';
import config from '../../storage/catalog-config/student';

const StudentDetailsPage = () => {
  const { id } = useParams();
  const [studentData, setStudentData] = useState({});
  const [initialData, setInitialData] = useState({});
  const [isChanged, setIsChanged] = useState(false);
  const { properties, crud } = config;
  const { useGetOneByIdAsync, useEditOneAsync } = crud;
  const { data, isLoading, isFetching } = useGetOneByIdAsync(id);
  const [isSaveInProgress, setIsSaveInProgress] = useState(false);
  const [editStudent] = useEditOneAsync();

  useEffect(() => {
    if (!isLoading && !isFetching) {
      const newData = { ...data };
      delete newData.id;
      setStudentData(newData);
      setInitialData(newData);
    }
  }, [isLoading, isFetching, data]);

  let blocker = useBlocker(
    ({ currentLocation, nextLocation }) => isChanged && currentLocation.pathname !== nextLocation.pathname,
  );

  const onSave = useCallback(async () => {
    setIsSaveInProgress(true); // начинаем сохранение
    await editStudent({ id, item: studentData });
    setIsSaveInProgress(false); // завершаем сохранение
    setIsChanged(false);
  }, [id, studentData, editStudent]);

  const onCancel = useCallback(() => {
    setStudentData(initialData);
    setIsChanged(false);
  }, [initialData]);

  const title = `Обучающиеся - ${studentData.family} ${studentData?.name} ${studentData?.patron}`;

  return isLoading || isFetching ? (
    <Loading />
  ) : (
    <Layout>
      <DetailsPageHeader title={title} />
      <h2 style={{ padding: '3vh' }}>{`${studentData.family} ${studentData?.name} ${studentData?.patron}`}</h2>
      <DetailsPageData items={properties} data={studentData} editData={setStudentData} setIsChanged={setIsChanged} />
      <hr />
      <Row>
        <Col>
          <Button onClick={onSave} style={{ marginRight: '10px' }} disabled={isSaveInProgress}>
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

export default StudentDetailsPage;
