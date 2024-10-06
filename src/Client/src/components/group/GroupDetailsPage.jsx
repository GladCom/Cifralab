import React, { useState, useEffect } from 'react';
import Layout from '../shared/Layout.jsx';
import { useParams } from 'react-router-dom';
import { useGetGroupByIdQuery, useEditGroupMutation } from '../../storage/services/groupsApi.js';
import Spinner from '../shared/Spinner.jsx';
import Empty from '../shared/Empty.jsx';
import Error from '../shared/Error.jsx';
import String from '../shared/business/String.jsx';
import EducationType from '../shared/business/EducationType.jsx';
import Gender from '../shared/business/Gender.jsx';
import Stack from 'react-bootstrap/Stack';
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

    if (error) {
        return <Error e={error} />;
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