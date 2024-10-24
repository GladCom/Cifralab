import React, { useState, useEffect } from 'react';
import Layout from '../shared/layout/Layout.jsx';
import { useParams } from 'react-router-dom';
import { useGetGroupByIdQuery, useEditGroupMutation } from '../../storage/services/groupsApi.js';
import Spinner from '../shared/layout/Spinner.jsx';
import Empty from '../shared/layout/Empty.jsx';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';

const GroupDetailsPage = () => {
    const { id } = useParams();
    const [groupData, setGroupData] = useState({});
    const { data, error, isLoading, isFetching, refetch } = useGetGroupByIdQuery(id);

    const [
        editStudent,
        { error: editGroupError, isLoading: isEdittingGroup },
      ] = useEditGroupMutation();

    useEffect(() => {
        if (!isLoading && !isFetching) {
            const newData = { ...data };
            delete newData.id;
            setGroupData(newData);
        }
    }, [isLoading, isFetching]);

    if (isLoading || isFetching) {
        return (
            <>
                <Spinner />
                <Empty />
            </>
        );
    }

    return (
        <Layout title={groupData?.name}>
            <hr />
            <Row>
                <Col>
                    <Button onClick={() => {
                        editStudent({ id, item: groupData });
                        refetch();
                    }}>Сохранить</Button>
                </Col>
            </Row>
        </Layout>
    );
};

export default GroupDetailsPage;