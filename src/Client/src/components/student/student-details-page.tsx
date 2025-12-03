import { useState, useEffect, useCallback } from 'react';
import { Layout, Loading, RoutingWarningModal, DetailsPageHeader } from '../shared/layout/index';
import { useParams, useBlocker } from 'react-router-dom';
import { Row, Col, Button } from 'antd';
import config from '../../storage/catalog-config/student';
import { StudentForm } from './student-form';
import { skipToken } from '@reduxjs/toolkit/query/react';
import { Student } from '../../storage/service/types';

export const StudentDetailsPage = () => {
  const { id } = useParams();
  const [studentData, setStudentData] = useState<Student>();
  //  formKeyValue нужен чтобы форма перемонтировалась при сохранении и отмене.
  const [formKeyValue, setFormKeyValue] = useState(0);
  const [initialData, setInitialData] = useState<Student>();
  const [isChanged, setIsChanged] = useState(false);
  const [isSaveInProgress, setIsSaveInProgress] = useState(false);

  const { crud } = config;
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
    setFormKeyValue((prev) => prev + 1);
    setInitialData(studentData);
  }, [id, studentData]);

  const onCancel = useCallback(() => {
    setFormKeyValue((prev) => prev + 1);
    setStudentData(initialData);
    setIsChanged(false);
  }, [initialData]);

  const title = `Обучающиеся - ${studentData?.family} ${studentData?.name} ${studentData?.patron}`;

  return isLoading || isFetching || !studentData ? (
    <Loading />
  ) : (
    <Layout>
      <DetailsPageHeader title={title} />
      <h2 style={{ padding: '3vh' }}>{`${studentData?.family} ${studentData?.name} ${studentData?.patron}`}</h2>
      {/* новый key будет пересоздавать форму заново, чтобы ресетить все внутренние состояния контролов, например isChanged */}
      <StudentForm
        key={formKeyValue}
        studentData={studentData}
        setStudentData={setStudentData}
        setIsChanged={setIsChanged}
      />
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
