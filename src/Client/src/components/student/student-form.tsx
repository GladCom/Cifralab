import { useState } from 'react';
import { DtoKeys, Student } from '../../storage/service/types';
import { StringControl } from '../shared/control/string-control';
import { StudentFormWrapper } from './student-form-wrapper';
import { ScopeOfActivitySelect } from '../shared/control/selects/scope-of-activity-select';
import { useGetscopeOfActivityQuery } from '../../storage/service/scope-of-activity-api';
import { EducationTypeSelect } from '../shared/control/selects/education-type-select';
import { DisplayMode } from '../shared/control/multi-mode-control/types';

type StudentFormProps = {
  studentData: Student;
  setStudentData: (data: Student) => void;
  setIsChanged: (isChanged: boolean) => void;
};

export const StudentForm: React.FC<StudentFormProps> = (props) => {
  const [ scopeOfActivityLvl2DisplayMode, setScopeOfActivityLvl2DisplayMode ] = useState<DisplayMode>(DisplayMode.EDITABLE_VIEW);
  const [ scopeOfActivityLvl2Options, setScopeOfActivityLvl2Options ] = useState<any>([]);
  const { data, isLoading, isFetching } = useGetscopeOfActivityQuery(undefined);
  const { studentData, setStudentData, setIsChanged } = props

  const scopeOfActivityLvl1ChangeHandler = (value: string) => {
    if (!isLoading && !isFetching) {
      setStudentData({
        ...studentData,
        [DtoKeys.SCOPE_OF_ACTIVITY_LEVEL_ONE_ID]: value,
      });
      const filteredData = data.filter( d => d.level === 2 && d.scopeOfActivityParentId === value );
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

  return (<StudentFormWrapper studentData={studentData} setStudentData={setStudentData} setIsChanged={setIsChanged}>
    <StringControl
      formParams={
        {
          key: DtoKeys.FAMILY,
          name: 'Фамилия',
        }
      }
    />
    <StringControl
      formParams={
        {
          key: DtoKeys.NAME,
          name: 'Имя',
        }
      }
    />
    <StringControl
      formParams={
        {
          key: DtoKeys.PATRON,
          name: 'Отчество',
        }
      }
    />

    {/* ...добавляем остальные контролы */}

    <EducationTypeSelect
      formParams={
        {
          key: DtoKeys.EDUCATION_TYPE_ID,
          name: 'Уровень образования',
        }
      }
    />

    {/* ...добавляем остальные контролы */}

    {/* TODO: вынести эти оба компонента в один и утащить туда обработчики изменений */}
    <ScopeOfActivitySelect
      formParams={
        {
          key: DtoKeys.SCOPE_OF_ACTIVITY_LEVEL_ONE_ID,
          name: 'Сфера деятельности ур.1',
        }
      }
      setValue={scopeOfActivityLvl1ChangeHandler}
    />
    <ScopeOfActivitySelect
      //value={'ddfff'}
      formParams={
        {
          key: DtoKeys.SCOPE_OF_ACTIVITY_LEVEL_TWO_ID,
          name: 'Сфера деятельности ур.2',
          shouldUpdate: true,
        }
      }
      options={scopeOfActivityLvl2Options}
      displayMode={scopeOfActivityLvl2DisplayMode}
    />
    {/* ...добавляем остальные контролы */}
  </StudentFormWrapper>);
};
