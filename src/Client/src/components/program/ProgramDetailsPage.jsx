import React, { useState, useEffect } from 'react';
import Layout from '../shared/layout/Layout.jsx';
import { useParams } from 'react-router-dom';
import { useGetEducationProgramByIdQuery, useEditEducationProgramMutation } from '../../storage/services/educationProgramApi.js';
import Spinner from '../shared/layout/Spinner.jsx';
import Empty from '../shared/layout/Empty.jsx';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';

const ProgramDetailsPage = () => {
    const { id } = useParams();
    const [programData, setProgramData] = useState({});
    const { data, error, isLoading, isFetching, refetch } = useGetEducationProgramByIdQuery(id);

    const [
        editProgram,
        { error: editProgramError, isLoading: isEditingProgram },
      ] = useEditEducationProgramMutation();

    useEffect(() => {
        if (!isLoading && !isFetching) {
            const newData = { ...data };
            delete newData.id;
            setProgramData(newData);
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
        <Layout title={programData?.name}>
            
            <hr />
            <Row>
                <Col>
                    <Button onClick={() => {
                        editProgram({ id, item: programData });
                        refetch();
                    }}>Сохранить</Button>
                </Col>
            </Row>
        </Layout>
    );
};

export default ProgramDetailsPage;