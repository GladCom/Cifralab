import { useState, useEffect, useCallback } from 'react';
import { Layout, Loading, RoutingWarningModal, DetailsPageHeader } from '../shared/layout/index';
import { useParams, useBlocker } from 'react-router-dom';
import { Row, Col, Button } from 'antd';
import config from '../../storage/catalog-config/student';
import { StudentForm } from './student-form';
import { skipToken } from '@reduxjs/toolkit/query/react';

export const StudentDetailsPage = () => {
  const { id } = useParams();
  const [studentData, setStudentData] = useState({});
  const [initialData, setInitialData] = useState({});
  const [isChanged, setIsChanged] = useState(false);
  const [isSaveInProgress, setIsSaveInProgress] = useState(false);

  const { properties, crud } = config;
  const { useGetOneByIdAsync, useEditOneAsync } = crud;
  const { data, isLoading, isFetching, refetch } = useGetOneByIdAsync(id || skipToken);

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

  const onSave = useCallback(() => {
    editStudent({ id, item: studentData });
    setIsChanged(false);
  }, [id, studentData]);

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
      <StudentForm studentData={studentData} setStudentData={setStudentData} setIsChanged={setIsChanged} />
      <hr />
      {isChanged && (
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
      )}
      <RoutingWarningModal show={blocker.state === 'blocked'} blocker={blocker} />
    </Layout>
  );
};
