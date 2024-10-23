import React, { useState, useEffect } from 'react';
import Layout from '../shared/layout/Layout.jsx';
import { useParams } from 'react-router-dom';
import Spinner from '../shared/layout/Spinner.jsx';
import Empty from '../shared/layout/Empty.jsx';
import String from '../shared/business/String.jsx';
import StatusEntranceExamsSelect from '../shared/business/selects/StatusEntranceExamsSelect.jsx';
import RequestStatusSelect from '../shared/business/selects/RequestStatusSelect.jsx'
import YesNoSelect from '../shared/business/YesNoSelect.jsx';
import Stack from 'react-bootstrap/Stack';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import requestsConfig from '../../storage/catalogConfigs/personRequests.js';
import requestStatusConfig from '../../storage/catalogConfigs/requestStatus.js';
import Email from '../shared/business/Email.jsx';

const RequestDetailsPage = () => {
    const { id } = useParams();
    const [requestData, setRequestData] = useState({});
    const { useGetOneByIdAsync, useEditOneAsync } = requestsConfig.crud;
    const { data, error, isLoading, isFetching, refetch } = useGetOneByIdAsync(id);

    const [
        editRequest,
        { error: editRequestError, isLoading: isEdittingRequest },
      ] = useEditOneAsync();

    useEffect(() => {
        if (!isLoading && !isFetching) {
            const newData = { ...data };
            delete newData.id;
            setRequestData(newData);
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
        <Layout title="Заявка">
            <h2 className="m-3">{requestData.family} {requestData?.name} {requestData?.patron}</h2>
            <Stack direction="horizontal">
                <div>Фамилия:</div>
                <div>
                    <String
                        value={requestData?.family}
                        mode='editableInfo'
                        setValue={(value) => setRequestData({ ...requestData, family: value })}
                    />
                </div>
                <div>Имя:</div>
                <div>
                    <String
                        value={requestData?.name}
                        mode='editableInfo'
                        setValue={(value) => setRequestData({ ...requestData, name: value })}
                    />
                </div>
                <div>Отчество:</div>
                <div>
                    <String
                        value={requestData?.patron}
                        mode='editableInfo'
                        setValue={(value) => setRequestData({ ...requestData, patron: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Статус:</div>
                <div>
                    <RequestStatusSelect
                        mode='editableInfo'
                        id={requestData?.statusRequestId}
                        crud={requestStatusConfig.crud}
                        setValue={(value) => setRequestData({ ...requestData, statusRequestId: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Специальность</div>
                <div>
                    <String
                        value={requestData?.speciality}
                        mode='editableInfo'
                        setValue={(value) => setRequestData({ ...requestData, speciality: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Опыт в IT</div>
                <div>
                    <String
                        value={requestData?.iT_Experience}
                        mode='editableInfo'
                        setValue={(value) => setRequestData({ ...requestData, iT_Experience: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Проекты</div>
                <div>
                    <String
                        value={requestData?.projects}
                        mode='editableInfo'
                        setValue={(value) => setRequestData({ ...requestData, projects: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Тестовое задание</div>
                <div>
                    <StatusEntranceExamsSelect
                        mode='editableInfo'
                        value={requestData?.statusEntrancExams}
                        setValue={(value) => setRequestData({ ...requestData, statusEntrancExams: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>День рождения</div>
                <div>
                    <String
                        value={requestData?.birthDate}
                        mode='editableInfo'
                        setValue={(value) => setRequestData({ ...requestData, birthDate: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Возраст</div>
                <div>
                    <String
                        value={requestData?.age}
                        mode='info'
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Место проживания</div>
                <div>
                    <String
                        value={requestData?.address}
                        mode='editableInfo'
                        setValue={(value) => setRequestData({ ...requestData, address: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Телефон</div>
                <div>
                    <String
                        value={requestData?.phone}
                        mode='editableInfo'
                        setValue={(value) => setRequestData({ ...requestData, phone: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>E-mail</div>
                <div>
                    <Email
                        value={requestData?.email}
                        mode='editableInfo'
                        setValue={(value) => setRequestData({ ...requestData, email: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Согласие на обработку перс. данных</div>
                <div>
                    <YesNoSelect
                        value={requestData?.agreement}
                        mode='editableInfo'
                        setValue={(value) => setRequestData({ ...requestData, agreement: value })}
                    />
                </div>
            </Stack>
            <hr />
            <Row>
                <Col>
                    <Button onClick={() => {
                        editRequest({ id, request: requestData });
                        refetch();
                    }}>Сохранить</Button>
                </Col>
            </Row>
        </Layout>
    );
};

export default RequestDetailsPage;