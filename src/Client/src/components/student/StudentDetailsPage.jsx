import React, { useState, useEffect } from 'react';
import Layout from '../shared/Layout.jsx';
import { useParams } from 'react-router-dom';
import Spinner from '../shared/Spinner.jsx';
import Empty from '../shared/Empty.jsx';
import Error from '../shared/Error.jsx';
import String from '../shared/business/String.jsx';
import QueryableSelect from '../shared/business/QueryableSelect.jsx';
import EducationTypeSelect from '../shared/business/selects/EducationTypeSelect.jsx'
import YesNoSelect from '../shared/business/YesNoSelect.jsx';
import Gender from '../shared/business/Gender.jsx';
import Stack from 'react-bootstrap/Stack';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import studentsConfig from '../../storage/catalogConfigs/students.js';
import typeEducationConfig from '../../storage/catalogConfigs/typeEducation.js'
import formEducationConfig from '../../storage/catalogConfigs/educationForm.js'

const StudentDetailsPage = () => {
    const { id } = useParams();
    const [studentData, setStudentData] = useState({ });
    const { useGetOneByIdAsync, useEditOneAsync } = studentsConfig.crud;
    const { data, error, isLoading, isFetching, refetch } = useGetOneByIdAsync(id);

    const [
        editStudent,
        { error: editStudentError, isLoading: isEdittingStudent },
      ] = useEditOneAsync();

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
            <h2 className="m-3">{studentData.family} {studentData?.name} {studentData?.patron}</h2>
            <Stack direction="horizontal">
                <div>Фамилия:</div>
                <div>
                    <String
                        value={studentData?.family}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, family: value })}
                    />
                </div>
                <div>Имя:</div>
                <div>
                    <String
                        value={studentData?.name}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, name: value })}
                    />
                </div>
                <div>Отчество:</div>
                <div>
                    <String
                        value={studentData?.patron}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, patron: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Статус заявки:</div>
                <div>
                    <String
                        value={studentData?.patron}
                        mode='editableInfo'
                        setValue={() => {}}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Программа:</div>
                <div>
                    <String
                        value={studentData?.patron}
                        mode='editableInfo'
                        setValue={() => {}}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Группа:</div>
                <div>
                    <String
                        value={studentData?.groupStudent}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, groupStudent: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Уровень образования:</div>
                <div>
                    <EducationTypeSelect
                        mode='editableInfo'
                        id={studentData?.typeEducationId}
                        crud={typeEducationConfig.crud}
                        setValue={(value) => setStudentData({ ...studentData, typeEducationId: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Специальность:</div>
                <div>
                    <String
                        value={studentData?.speciality}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, speciality: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Опыт в IT:</div>
                <div>
                    <String
                        value={studentData?.iT_Experience}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, iT_Experience: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Проекты:</div>
                <div>
                    <String
                        value={studentData?.projects}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, projects: value })}
                    />
                </div>
            </Stack>
            <hr />
            <Stack direction="horizontal">
                <div>Дата рождения:</div>
                <div>
                    <String
                        value={studentData?.birthDate}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, birthDate: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Пол:</div>
                <div>
                    <Gender
                        value={studentData?.sex}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, sex: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Место проживания:</div>
                <div>
                    <String
                        value={studentData?.address}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, address: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Телефон:</div>
                <div>
                    <String
                        value={studentData?.phone}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, phone: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>E-mail:</div>
                <div>
                    <String
                        value={studentData?.email}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, email: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>СНИЛС:</div>
                <div>
                    <String
                        value={studentData?.snils}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, snils: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Гражданство:</div>
                <div>
                    <String
                        value={studentData?.nationality}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, nationality: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>ОВЗ:</div>
                <div>
                    <YesNoSelect
                        value={studentData?.disability}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, disability: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Сфера деятельности ур. 1:</div>
                <div>
                    <String
                        value={studentData?.scopeOfActivityLevelOne}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, scopeOfActivityLevelOne: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Сфера деятельности ур. 2:</div>
                <div>
                    <String
                        value={studentData?.scopeOfActivityLevelTwo}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, scopeOfActivityLevelTwo: value })}
                    />
                </div>
            </Stack>
            <hr />
            <Stack direction="horizontal">
                <div>Фамилия в дипломе о ВО/СПО:</div>
                <div>
                    <String
                        value={studentData?.patron}
                        mode='editableInfo'
                        setValue={() => {}}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Серия документа о ВО/СПО:</div>
                <div>
                    <String
                        value={studentData?.documentSeries}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, documentSeries: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Номер документа о ВО/СПО:</div>
                <div>
                    <String
                        value={studentData?.documentNumber}
                        mode='editableInfo'
                        setValue={(value) => setStudentData({ ...studentData, documentNumber: value })}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Номер и дата договора об обучении:</div>
                <div>
                    <String
                        value={studentData?.patron}
                        mode='editableInfo'
                        setValue={() => {}}
                    />
                </div>
            </Stack>
            <Stack direction="horizontal">
                <div>Форма обучения:</div>
                <div>
                    <QueryableSelect
                        value={studentData?.typeEducation}
                        mode='info' //  TODO:   исправить когда бэк будет это возвращать
                        property='name'
                        crud={formEducationConfig.crud}
                        setValue={(value) => setStudentData({ ...studentData, typeEducation: value })}
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