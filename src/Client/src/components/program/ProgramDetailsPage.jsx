import React, { useState, useEffect } from 'react';
import Layout from '../shared/Layout.jsx';
import { useParams } from 'react-router-dom';
import { useGetEducationProgramByIdQuery, useEditEducationProgramMutation } from '../../storage/services/educationProgramApi.js';
import Spinner from '../shared/Spinner.jsx';
import Empty from '../shared/Empty.jsx';
import Error from '../shared/Error.jsx';
import String from '../shared/business/String.jsx';
import EducationFormSelect from '../../components/shared/business/selects/EducationFormSelect.jsx'
import FinancingTypeSelect from '../../components/shared/business/selects/FinancingTypeSelect.jsx'
import FEAProgramSelect from '../../components/shared/business/selects/FEAProgramSelect.jsx'
import KindDocumentRiseQualificationSelect from '../../components/shared/business/selects/KindDocumentRiseQualificationSelect.jsx'
import YesNoSelect from '../../components/shared/business/YesNoSelect.jsx';
import config from '../../storage/catalogConfigs/educationPrograms.js'
import Stack from 'react-bootstrap/Stack';
import Row from 'react-bootstrap/Row';
import QueryableSelect from '../shared/business/QueryableSelect.jsx';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';

const ProgramDetailsPage = () => {
    const { id } = useParams();
    const [programData, setProgramData] = useState({});
    const { properties, crud } = config;
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
        <Layout title="Данные программы">
        <h2 className="m-3">   
            <String
                    value={programData?.name}
                    mode='editableInfo'
                    setValue={(value) => setProgramData({ ...programData, name: value })}
                /> 
                </h2>
                {Object.entries(properties).map(([key, { name, type, show, required }]) => {
                    const Input = type;
                    const isSelect = [
                        EducationFormSelect,
                        FinancingTypeSelect,
                        FEAProgramSelect,
                        KindDocumentRiseQualificationSelect
                    ].includes(type);
                    return (
                        <Stack direction="horizontal" key={key}>
                            <div>{name}</div>
                            <div>
                                <Input
                                    key={key}
                                    name={key}
                                    // Если Input это QueryableSelect, используем 'id' вместо 'value'
                                    {...(isSelect
                                        ? { id: programData[key] }  
                                        : { value: programData[key] }) 
                                    }
                                    mode='editableInfo'
                                    setValue={(value) => {
                                        setProgramData({
                                            ...programData,
                                            [key]: value
                                        });
                                    }}
                                />
                            </div>
                        </Stack>
                    );
                })}

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