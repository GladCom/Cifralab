import React, { useState, useEffect, useCallback } from 'react';
import { Layout, Loading, DetailsPageData, RoutingWarningModal } from '../shared/layout/index.js';
import { useParams, useBlocker } from 'react-router-dom';
import { Row, Col, Space, Button } from 'antd';
import config from '../../storage/catalogConfigs/students.js'

const StudentDetailsPage = () => {
    const { id } = useParams();
    const [studentData, setStudentData] = useState({});
    const [initialData, setInitialData] = useState({});
    const [isChanged, setIsChanged] = useState(false);
    const [isSaveInProgress, setIsSaveInProgress] = useState(false);

    const { properties, crud } = config;
    const { useGetOneByIdAsync, useEditOneAsync } = crud;
    const { data, isLoading, isFetching, refetch } = useGetOneByIdAsync(id);

    const [editStudent] = useEditOneAsync();

    useEffect(() => {
      if (!isLoading && !isFetching) {
        const newData = { ...data };
        delete newData.id;
        setStudentData(newData);
        setInitialData(newData);
      }
    }, [isLoading, isFetching,data]);

    let blocker = useBlocker(
        ({ currentLocation, nextLocation }) =>
            isChanged &&
            currentLocation.pathname !== nextLocation.pathname
    );

    const onSave = useCallback(async () => {
        setIsSaveInProgress(true); 
        try {
            await editStudent({ id, item: studentData }).unwrap();
            setInitialData(studentData); 
            setIsChanged(false)
        } catch (error) {
            console.error("Ошибка сохранения данных:", error);
        } finally {
            setIsSaveInProgress(false); 
        }
    }, [id, studentData]);

       
    const onCancel = useCallback(() => {
        setStudentData(initialData);
        setIsChanged(false);
    }, [initialData]);

    return isLoading || isFetching
    ? (<Loading />)
    : (
        <Layout title="Персональные данные студента">
            <h2>{studentData.family} {studentData?.name} {studentData?.patron}</h2>
            <DetailsPageData
                items={properties}
                data={studentData}
                editData={setStudentData}
                setIsChanged={setIsChanged}
            />
            <hr />
            <Row>
                <Col>
                    <Button onClick={onSave} style={{ marginRight: '10px' }}>Сохранить</Button>
                </Col>
                <Col>
                    <Button onClick={onCancel} disabled={isSaveInProgress}>Отмена</Button>
                </Col>
            </Row>
            <RoutingWarningModal
                show={blocker.state === "blocked"}
                blocker={blocker} 
            />
        </Layout>
  );
};

export default StudentDetailsPage;