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
import { Row, Col, Space, Button } from 'antd';
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
      <Space direction="vertical" size={0} style={{ display: 'flex' }}>
        <Row style={rowStyle}>
          <Col span={3}>Фамилия:</Col>
          <Col span={8}>
            <String
              value={studentData?.family}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, family: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Имя:</Col>
          <Col span={8}>
            <String
              value={studentData?.name}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, name: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Отчество:</Col>
          <Col span={8}>
            <String
              value={studentData?.patron}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, patron: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Дата рождения:</Col>
          <Col span={8}>
            <String
              value={studentData?.birthDate}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, birthDate: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Пол:</Col>
          <Col span={8}>
            <Gender
              value={studentData?.sex}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, sex: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Место проживания:</Col>
          <Col span={8}>
            <String
              value={studentData?.address}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, address: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Телефон:</Col>
          <Col span={8}>
            <String
              value={studentData?.phone}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, phone: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>E-mail:</Col>
          <Col span={8}>
            <Email
              value={studentData?.email}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, email: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>СНИЛС:</Col>
          <Col span={8}>
            <Snils
              value={studentData?.snils}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, snils: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Гражданство:</Col>
          <Col span={8}>
            <String
              value={studentData?.nationality}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, nationality: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Уровень образования:</Col>
          <Col span={8}>
            <EducationTypeSelect
              mode='editableInfo'
              id={studentData?.typeEducationId}
              crud={typeEducationConfig.crud}
              setValue={(value) => setStudentData({ ...studentData, typeEducationId: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Специальность:</Col>
          <Col span={8}>
            <String
              value={studentData?.speciality}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, speciality: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Номер и дата договора об обучении:</Col>
          <Col span={8}>
            <String
              value={studentData?.patron}
              mode='editableInfo'
              setValue={() => { }}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>ОВЗ:</Col>
          <Col span={8}>
            <YesNoSelect
              value={studentData?.disability}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, disability: value })}
            />
          </Col>
        </Row>

        <Row style={rowStyle}>
          <Col span={3}>Опыт в IT:</Col>
          <Col span={8}>
            <String
              value={studentData?.iT_Experience}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, iT_Experience: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Проекты:</Col>
          <Col span={8}>
            <String
              value={studentData?.projects}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, projects: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Статус заявки:</Col>
          <Col span={8}>
            <String
              value={studentData?.patron}
              mode='editableInfo'
              setValue={() => { }}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Программа:</Col>
          <Col span={8}>
            <String
              value={studentData?.patron}
              mode='editableInfo'
              setValue={() => { }}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Группа:</Col>
          <Col span={8}>
            <String
              value={studentData?.groupStudent}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, groupStudent: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Форма обучения:</Col>
          <Col span={8}>
            <QueryableSelect
              value={studentData?.typeEducation}
              mode='info' // TODO: исправить когда бэк будет это возвращать
              property='name'
              crud={formEducationConfig.crud}
              setValue={(value) => setStudentData({ ...studentData, typeEducation: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Сфера деятельности ур. 1:</Col>
          <Col span={8}>
            <String
              value={studentData?.scopeOfActivityLevelOne}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, scopeOfActivityLevelOne: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Сфера деятельности ур. 2:</Col>
          <Col span={8}>
            <String
              value={studentData?.scopeOfActivityLevelTwo}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, scopeOfActivityLevelTwo: value })}
            />
          </Col>
        </Row>
        <Row style={rowStyle}>
          <Col span={3}>Серия документа о ВО/СПО:</Col>
          <Col span={8}>
            <String
              value={studentData?.documentSeries}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, documentSeries: value })}
            />
          </Col>
        </Row>
        <Row style={{alignItems: 'center', marginBottom: '5px' }}>
          <Col span={3}>Номер документа о ВО/СПО:</Col>
          <Col span={8}>
            <String
              value={studentData?.documentNumber}
              mode='editableInfo'
              setValue={(value) => setStudentData({ ...studentData, documentNumber: value })}
            />
          </Col>
        </Row>
        <Row style={{ alignItems: 'center', marginBottom: '10px' }}>
          <Col span={12}>
            <Button type="primary" onClick={() => {
              editStudent({ id, student: studentData });
              refetch();
            }}>Сохранить</Button>
          </Col>
        </Row>
      </Space>
    </Layout>
  );
};

export default StudentDetailsPage;