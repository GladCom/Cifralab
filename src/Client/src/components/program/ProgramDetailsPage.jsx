import React, { useState, useEffect, useCallback } from 'react';
import { Layout, Loading, DetailsPageData } from '../shared/layout/index.js';
import { useParams } from 'react-router-dom';
import { Row, Col, Space, Button } from 'antd';
import config from '../../storage/catalogConfigs/educationPrograms.js';

const ProgramDetailsPage = () => {
    const { id } = useParams();
    const [programData, setProgramData] = useState({});
    const [isSaveInProgress, setIsSaveInProgress] = useState(false);
    const [initialData, setInitialData] = useState({}); 
    const { properties, crud } = config;
    const { useGetOneByIdAsync, useEditOneAsync } = crud;
    const { data, isLoading, isFetching } = useGetOneByIdAsync(id);

    const [editProgram] = useEditOneAsync();

    useEffect(() => {
        if (!isLoading && !isFetching) {
            const newData = { ...data };
            delete newData.id;
            setProgramData(newData);
            setInitialData(newData); 
        }
    }, [isLoading, isFetching, data]);

    
    
    const onSave = useCallback(async () => {
        setIsSaveInProgress(true); 
        try {
            await editProgram({ id, item: programData }).unwrap();
            setInitialData(programData); 
        } catch (error) {
            console.error("Ошибка сохранения данных:", error);
        } finally {
            setIsSaveInProgress(false); 
        }
    }, [id, programData]);
    
    const onCancel = useCallback(() => {
        setProgramData(initialData);
    }, [initialData]);
    
    return isLoading || isFetching
    ? (<Loading />)
    : (
        <Layout title="Данные программы">
            <h2>{programData?.name}</h2>
            <DetailsPageData
                items={properties}
                data={programData}
                editData={setProgramData}
            />
            <hr />
            <Row>
                <Col>
                    <Button onClick={onSave} style={{ marginRight: '10px' }}>Сохранить</Button>
                </Col>
                <Col>
                    <Button onClick={onCancel}disabled={isSaveInProgress}>Отмена</Button>
                </Col>
            </Row>
        </Layout>
    );
};

export default ProgramDetailsPage;