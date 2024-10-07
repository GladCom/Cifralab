import React, { useState, useEffect } from 'react';
import Layout from '../shared/Layout.jsx';
import { useParams } from 'react-router-dom';
import { useGetEducationProgramByIdQuery, useEditEducationProgramMutation } from '../../storage/services/educationProgramApi.js';
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

    if (error) {
        return <Error e={error} />;
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