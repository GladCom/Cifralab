import React, { useState, useEffect } from 'react';
import Layout from '../shared/layout/Layout.jsx';
import { useParams } from 'react-router-dom';
import { useGetEducationProgramByIdQuery, useEditEducationProgramMutation } from '../../storage/services/educationProgramApi.js';
import Spinner from '../shared/layout/Spinner.jsx';
import Empty from '../shared/layout/Empty.jsx';
import String from '../shared/business/String.jsx';
import EducationFormSelect from '../../components/shared/business/selects/EducationFormSelect.jsx'
import FinancingTypeSelect from '../../components/shared/business/selects/FinancingTypeSelect.jsx'
import FEAProgramSelect from '../../components/shared/business/selects/FEAProgramSelect.jsx'
import KindDocumentRiseQualificationSelect from '../../components/shared/business/selects/KindDocumentRiseQualificationSelect.jsx'
import config from '../../storage/catalogConfigs/educationPrograms.js'
import { Row, Col, Space, Button } from 'antd';

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

    const rowStyle = { alignItems: 'center', marginBottom: '0px' };

    return (
        <Layout title="Данные программы">
        <h2 className="m-3">   
            <String
                    value={programData?.name}
                    mode='info'
                    setValue={(value) => setProgramData({ ...programData, name: value })}
                /> 
                </h2>
                <Space direction="vertical" size={0} style={{ display: 'flex' }}>
                {Object.entries(properties).map(([key, { name, type, formParams }]) => {
                    const Item = type;

                    return (
                        <Row style={rowStyle} key={key}>
                            <Col span={3}>{name}</Col>
                            <Col span={8}>
                                <Item
                                    key={key}
                                    name={key}
                                    value={programData[key]}
                                    mode='editableInfo'
                                    formParams={{ key, name, ...formParams }}
                                    setValue={(value) => {
                                        setProgramData({
                                            ...programData,
                                            [key]: value
                                        });
                                    }}
                                />
                            </Col>
                        </Row>
                    );
                })}
                 </Space>

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