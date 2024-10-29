import React, { useState, useEffect, useCallback } from 'react';
import { Layout, Loading, DetailsPageData } from '../shared/layout/index.js';
import { useParams } from 'react-router-dom';
import { Row, Col, Space, Button } from 'antd';
import config from '../../storage/catalogConfigs/students.js'

const StudentDetailsPage = () => {
    const { id } = useParams();
    const [studentData, setStudentData] = useState({});
    const { properties, crud } = config;
    const { useGetOneByIdAsync, useEditOneAsync } = crud;
    const { data, isLoading, isFetching, refetch } = useGetOneByIdAsync(id);

    const [editStudent] = useEditOneAsync();

    useEffect(() => {
      if (!isLoading && !isFetching) {
        const newData = { ...data };
        delete newData.id;
        setStudentData(newData);
      }
    }, [isLoading, isFetching]);

    const onSave = useCallback(() => {
        editStudent({ id, item: studentData });
    });

    return isLoading || isFetching
    ? (<Loading />)
    : (
        <Layout title="Персональные данные студента">
            <h2>{studentData.family} {studentData?.name} {studentData?.patron}</h2>
            <DetailsPageData
                items={properties}
                data={studentData}
                editData={setStudentData}
            />
            <hr />
            <Row>
                <Col>
                    <Button onClick={onSave}>Сохранить</Button>
                </Col>
            </Row>
        </Layout>
  );
};

export default StudentDetailsPage;