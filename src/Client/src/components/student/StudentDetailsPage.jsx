import React, { useState, useEffect } from 'react';
import Layout from '../shared/Layout.jsx';
import { useParams } from 'react-router-dom';
import Spinner from '../shared/Spinner.jsx';
import Empty from '../shared/Empty.jsx';
import Error from '../shared/Error.jsx';
import String from '../shared/business/String.jsx';
import QueryableSelect from '../shared/business/QueryableSelect.jsx';
import EducationTypeSelect from '../shared/business/selects/EducationTypeSelect.jsx';
import YesNoSelect from '../shared/business/YesNoSelect.jsx';
import Gender from '../shared/business/Gender.jsx';
import { Flex, Button } from 'antd';
import Snils from '../shared/business/validation/Snils.jsx';
import studentsConfig from '../../storage/catalogConfigs/students.js';
import typeEducationConfig from '../../storage/catalogConfigs/typeEducation.js';
import formEducationConfig from '../../storage/catalogConfigs/educationForm.js';
import Email from '../shared/business/validation/Email.jsx';

const StudentDetailsPage = () => {
  const { id } = useParams();
  const [studentData, setStudentData] = useState({});
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

  const rowStyle = { alignItems: 'center', marginBottom: '-18px' };

  return (
    <Layout title="Персональные данные студента">
      <h2 className="m-3">{studentData.family} {studentData?.name} {studentData?.patron}</h2>
      <Flex vertical>
        <Flex style={rowStyle}>
          Фамилия:
          <String
            value={studentData?.family}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, family: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Имя:
          <String
            value={studentData?.name}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, name: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Отчество:
          <String
            value={studentData?.patron}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, patron: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Дата рождения:
          <String
            value={studentData?.birthDate}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, birthDate: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Пол:
          <Gender
            value={studentData?.sex}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, sex: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Место проживания:
          <String
            value={studentData?.address}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, address: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Телефон:
          <String
            value={studentData?.phone}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, phone: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          E-mail:
          <Email
            value={studentData?.email}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, email: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          СНИЛС:
          <Snils
            value={studentData?.snils}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, snils: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Гражданство:
          <String
            value={studentData?.nationality}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, nationality: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Уровень образования:
          <EducationTypeSelect
            mode='editableInfo'
            id={studentData?.typeEducationId}
            crud={typeEducationConfig.crud}
            setValue={(value) => setStudentData({ ...studentData, typeEducationId: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Специальность:
          <String
            value={studentData?.speciality}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, speciality: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Номер и дата договора об обучении:
          <String
            value={studentData?.patron}
            mode='editableInfo'
            setValue={() => { }}
          />
        </Flex>
        <Flex style={rowStyle}>
          ОВЗ:
          <YesNoSelect
            value={studentData?.disability}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, disability: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Опыт в IT:
          <String
            value={studentData?.iT_Experience}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, iT_Experience: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Проекты:
          <String
            value={studentData?.projects}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, projects: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Статус заявки:
          <String
            value={studentData?.patron}
            mode='editableInfo'
            setValue={() => { }}
          />
        </Flex>
        <Flex style={rowStyle}>
          Программа:
          <String
            value={studentData?.patron}
            mode='editableInfo'
            setValue={() => { }}
          />
        </Flex>
        <Flex style={rowStyle}>
          Группа:
          <String
            value={studentData?.groupStudent}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, groupStudent: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Форма обучения:
          <QueryableSelect
            value={studentData?.typeEducation}
            mode='info' // TODO: исправить когда бэк будет это возвращать
            property='name'
            crud={formEducationConfig.crud}
            setValue={(value) => setStudentData({ ...studentData, typeEducation: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Сфера деятельности ур. 1:
          <String
            value={studentData?.scopeOfActivityLevelOne}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, scopeOfActivityLevelOne: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Сфера деятельности ур. 2:
          <String
            value={studentData?.scopeOfActivityLevelTwo}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, scopeOfActivityLevelTwo: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Серия документа о ВО/СПО:
          <String
            value={studentData?.documentSeries}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, documentSeries: value })}
          />
        </Flex>
        <Flex style={rowStyle}>
          Номер документа о ВО/СПО:
          <String
            value={studentData?.documentNumber}
            mode='editableInfo'
            setValue={(value) => setStudentData({ ...studentData, documentNumber: value })}
          />
        </Flex>
        <Flex>
          <Button type="primary" onClick={() => {
            editStudent({ id, student: studentData });
            refetch();
          }}>Сохранить</Button>
        </Flex>
      </Flex>
    </Layout>
  );
};

export default StudentDetailsPage;