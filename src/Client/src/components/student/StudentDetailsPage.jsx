import React, { useState, useEffect } from 'react';
import Layout from '../shared/Layout.jsx';
import { useParams } from 'react-router-dom';
import { useGetStudentByIdQuery, useEditStudentMutation } from '../../services/studentsApi.js';
import Spinner from '../shared/Spinner.jsx';
import Empty from '../shared/Empty.jsx';
import Error from '../shared/Error.jsx';
import String from '../shared/business/String.jsx';
import Gender from '../shared/business/Gender.jsx';
import Stack from 'react-bootstrap/Stack';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';

const StudentDetailsPage = () => {
    const { id } = useParams();
    const [studentData, setStudentData] = useState({});
    const { data, error, isLoading, isFetching, refetch } = useGetStudentByIdQuery(id);

    const [
        editStudent,
        { error: editStudentError, isLoading: isEdittingStudent },
      ] = useEditStudentMutation();

    useEffect(() => {
        if (!isLoading && !isFetching) {
            const newData = { ...data };
            delete newData.id;
            setStudentData(newData);
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
        <Layout title="Персональные данные студента">
            <h2 className="m-3">{studentData?.family} {studentData?.name} {studentData?.patron}</h2>
            <Stack direction="horizontal">
                <div>Фамилия:</div>
                <div>
                    <String
                        initValue={studentData?.family}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, family: value })}
                    />
                </div>
                <div>Имя:</div>
                <div>
                    <String
                        initValue={studentData?.name}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, name: value })}
                    />
                </div>
                <div>Отчество:</div>
                <div>
                    <String
                        initValue={studentData?.patron}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, patron: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Статус заявки:</div>
                <div>
                    <String
                        initValue={studentData?.patron}
                        editable={true}
                        setValue={() => {}}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Программа:</div>
                <div>
                    <String
                        initValue={studentData?.patron}
                        editable={true}
                        setValue={() => {}}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Группа:</div>
                <div>
                    <String
                        initValue={studentData?.groupStudent}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, groupStudent: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Уровень образования:</div>
                <div>
                    <String
                        initValue={studentData?.typeEducationId}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, typeEducationId: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Специальность:</div>
                <div>
                    <String
                        initValue={studentData?.speciality}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, speciality: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Опыт в IT:</div>
                <div>
                    <String
                        initValue={studentData?.iT_Experience}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, iT_Experience: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Проекты:</div>
                <div>
                    <String
                        initValue={studentData?.projects}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, projects: value })}
                    />
                </div>
            </Stack>
            <hr />
            <Stack direction="horizontal">
                <div>Дата рождения:</div>
                <div>
                    <String
                        initValue={studentData?.birthDate}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, birthDate: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Пол:</div>
                <div>
                    <Gender
                        initValue={studentData?.sex}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, sex: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Место проживания:</div>
                <div>
                    <String
                        initValue={studentData?.address}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, address: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Телефон:</div>
                <div>
                    <String
                        initValue={studentData?.phone}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, phone: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>E-mail:</div>
                <div>
                    <String
                        initValue={studentData?.email}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, email: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>СНИЛС:</div>
                <div>
                    <String
                        initValue={studentData?.snils}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, snils: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Гражданство:</div>
                <div>
                    <String
                        initValue={studentData?.nationality}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, nationality: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>ОВЗ:</div>
                <div>
                    <String
                        initValue={studentData?.disability}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, disability: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Сфера деятельности ур. 1:</div>
                <div>
                    <String
                        initValue={studentData?.scopeOfActivityLevelOne}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, scopeOfActivityLevelOne: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Сфера деятельности ур. 2:</div>
                <div>
                    <String
                        initValue={studentData?.scopeOfActivityLevelTwo}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, scopeOfActivityLevelTwo: value })}
                    />
                </div>
            </Stack>
            <hr />
            <Stack direction="horizontal">
                <div>Фамилия в дипломе о ВО/СПО:</div>
                <div>
                    <String
                        initValue={studentData?.patron}
                        editable={true}
                        setValue={() => {}}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Серия документа о ВО/СПО:</div>
                <div>
                    <String
                        initValue={studentData?.documentSeries}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, documentSeries: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Номер документа о ВО/СПО:</div>
                <div>
                    <String
                        initValue={studentData?.documentNumber}
                        editable={true}
                        setValue={(value) => setStudentData({ ...studentData, documentNumber: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Номер и дата договора об обучении:</div>
                <div>
                    <String
                        initValue={studentData?.patron}
                        editable={true}
                        setValue={() => {}}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Форма обучения:</div>
                <div>
                    <String
                        initValue={studentData?.patron}
                        editable={true}
                        setValue={() => {}}
                    />
                </div>
            </Stack>
            <hr />
            <Row>
                <Col>
                    <Button onClick={() => {
                        editStudent({ id, student: studentData });
                        refetch();
                    }}>Сохранить</Button>
                </Col>
            </Row>
        </Layout>
    );
};

export default StudentDetailsPage;