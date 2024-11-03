import React, { useState, useEffect, useCallback } from 'react';
import { Layout, Loading, DetailsPageData } from '../shared/layout/index.js';
import { useParams } from 'react-router-dom';
import { useGetGroupByIdQuery, useEditGroupMutation } from '../../storage/services/groupsApi.js';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import config from '../../storage/catalogConfigs/groups.js';

const GroupDetailsPage = () => {
    const { id } = useParams();
    const [groupData, setGroupData] = useState({});
    const [initialData, setInitialData] = useState({});
    const [isSaveInProgress, setIsSaveInProgress] = useState(false); // состояние для отслеживания процесса сохранения
    const { properties, crud } = config;
    const { useGetOneByIdAsync, useEditOneAsync } = crud;
    const { data, isLoading, isFetching, refetch } = useGetOneByIdAsync(id);
    const [editGroup] = useEditOneAsync();
    const [
        editStudent,
        { error: editGroupError, isLoading: isEdittingGroup },
    ] = useEditGroupMutation();

    useEffect(() => {
        if (!isLoading && !isFetching) {
            const newData = { ...data };
            delete newData.id;
            setGroupData(newData);
            setInitialData(newData);
        }
    }, [isLoading, isFetching, data]);

    const onSave = useCallback(async () => {
        setIsSaveInProgress(true); 
        try {
            await editGroup({ id, item: groupData }).unwrap();
            refetch();
            setInitialData(groupData); 
        } catch (error) {
            console.error("Ошибка сохранения данных:", error);
        } finally {
            setIsSaveInProgress(false); 
        }
    }, [id, groupData]);

    const onCancel = useCallback(() => {
        setGroupData(initialData);
    }, [initialData]);

    return isLoading || isFetching
    ? (<Loading />)
    : (
        <Layout title="Данные программы">
            <h2>{groupData?.name}</h2>
            <DetailsPageData
                items={properties}
                data={groupData}
                editData={setGroupData}
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
        </Layout>
    );
};

export default GroupDetailsPage;
