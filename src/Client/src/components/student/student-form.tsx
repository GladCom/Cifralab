import { useState } from 'react';
import { DtoKeys, Student } from '../../storage/service/types';
import { StringControl } from '../shared/control/string-control';
import { StudentFormWrapper } from './student-form-wrapper';
import { ScopeOfActivitySelect } from '../shared/control/selects/scope-of-activity-select';
import { useGetscopeOfActivityQuery } from '../../storage/service/scope-of-activity-api';
import { EducationTypeSelect } from '../shared/control/selects/education-type-select';
import { DisplayMode } from '../shared/control/multi-mode-control/types';
import { BirthDate } from '../shared/control/birth-date';
import { Gender } from '../shared/control/gender';
import { Age } from '../shared/control/age';
import { Address } from '../shared/control/address';
import { PhoneNumber } from '../shared/control/phone-number';
import { Email } from '../shared/control/email';
import { Snils } from '../shared/control/snils';
import { YesNoControl } from '../shared/control/yes-no-control';

type StudentFormProps = {
  studentData: Student;
  setStudentData: (data: Student) => void;
  setIsChanged: (isChanged: boolean) => void;
};

export const StudentForm: React.FC<StudentFormProps> = (props) => {
  const [scopeOfActivityLvl2DisplayMode, setScopeOfActivityLvl2DisplayMode] = useState<DisplayMode>(
    DisplayMode.EDITABLE_VIEW,
  );
  const [scopeOfActivityLvl2Options, setScopeOfActivityLvl2Options] = useState<any>([]);
  const { data, isLoading, isFetching } = useGetscopeOfActivityQuery(undefined);
  const { studentData, setStudentData, setIsChanged } = props;

  const scopeOfActivityLvl1ChangeHandler = (value: string) => {
    if (!isLoading && !isFetching) {
      setStudentData({
        ...studentData,
        [DtoKeys.SCOPE_OF_ACTIVITY_LEVEL_ONE_ID]: value,
      });
      const filteredData = data.filter((d) => d.level === 2 && d.scopeOfActivityParentId === value);
      const lvl2Options = filteredData.map(({ id, nameOfScope }) => ({
        value: id,
        label: nameOfScope,
      }));

      //  На всякий случай закрываем  микро-форму редактирования у уровня 2.
      setScopeOfActivityLvl2DisplayMode(DisplayMode.EDITABLE_VIEW);
      setScopeOfActivityLvl2Options(lvl2Options);
      setIsChanged(true);
    }
  };

  return (
    <StudentFormWrapper studentData={studentData} setStudentData={setStudentData} setIsChanged={setIsChanged}>
      <StringControl
        formParams={{
          key: DtoKeys.FAMILY,
          name: 'Фамилия',
        }}
      />
      <StringControl
        formParams={{
          key: DtoKeys.NAME,
          name: 'Имя',
        }}
      />
      <StringControl
        formParams={{
          key: DtoKeys.PATRON,
          name: 'Отчество',
        }}
      />
      <BirthDate
        formParams={{
          key: DtoKeys.BIRTH_DATE,
          name: 'Пол',
        }}
      />
      <Gender
        formParams={{
          key: DtoKeys.SEX,
          name: 'Пол',
        }}
      />
      <Age
        formParams={{
          key: DtoKeys.AGE,
          name: 'Возраст',
          rules: [
            {
              required: false,
            },
          ],
        }}
        controlParams={{
          displayOptions: {
            [DisplayMode.FORM_ITEM]: false,
            [DisplayMode.VIEW]: true,
            [DisplayMode.EDITABLE_VIEW]: true,
            [DisplayMode.EDITOR]: true,
          },
        }}
      />
      <Address
        formParams={{
          key: DtoKeys.ADDRESS,
          name: 'Место проживания',
        }}
      />
      <PhoneNumber
        formParams={{
          key: DtoKeys.PHONE,
          name: 'Номер телефона',
        }}
      />
      <Email
        formParams={{
          key: DtoKeys.EMAIL,
          name: 'E-mail',
        }}
      />
      <Snils
        formParams={{
          key: DtoKeys.SNILS,
          name: 'Снилс',
        }}
      />
      <StringControl
        formParams={{
          key: DtoKeys.NATIONALITY,
          name: 'Гражданство',
        }}
      />
      <EducationTypeSelect
        formParams={{
          key: DtoKeys.EDUCATION_TYPE_ID,
          name: 'Уровень образования',
        }}
      />
      <StringControl
        formParams={{
          key: DtoKeys.SPECIALITY,
          name: 'Специальность',
        }}
      />
      <ScopeOfActivitySelect
        formParams={{
          key: DtoKeys.SCOPE_OF_ACTIVITY_LEVEL_ONE_ID,
          name: 'Сфера деятельности ур.1',
        }}
        setValue={scopeOfActivityLvl1ChangeHandler}
      />
      <ScopeOfActivitySelect
        formParams={{
          key: DtoKeys.SCOPE_OF_ACTIVITY_LEVEL_TWO_ID,
          name: 'Сфера деятельности ур.2',
          shouldUpdate: true,
        }}
        options={scopeOfActivityLvl2Options}
        displayMode={scopeOfActivityLvl2DisplayMode}
      />
      <StringControl
        formParams={{
          key: DtoKeys.FULL_NAME_DOCUMENT,
          name: 'Фамилия в дипломе о ВО/СПО',
        }}
      />
      <StringControl
        formParams={{
          key: DtoKeys.DOCUMENT_SERIES,
          name: 'Серия документа о ВО/СПО',
        }}
      />
      <StringControl
        formParams={{
          key: DtoKeys.DOCUMENT_NUMBER,
          name: 'Номер документа о ВО/СПО',
        }}
      />
      <YesNoControl
        formParams={{
          key: DtoKeys.DISABILITY,
          name: 'ОВЗ',
        }}
      />
    </StudentFormWrapper>
  );
};
