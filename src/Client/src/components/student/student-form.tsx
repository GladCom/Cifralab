import React, { useState } from 'react';
import { DtoKeys } from '../../storage/service/types';
import { StringControl } from '../shared/control/string-control';
import { StudentFormWrapper } from './student-form-wrapper';
import { ScopeOfActivitySelect } from '../shared/control/selects/scope-of-activity-select';
import { useGetscopeOfActivityQuery } from '../../storage/service/scope-of-activity-api';

type StudentFormProps = {
  studentData: any;
  setStudentData: (data: any) => void;
  setIsChanged: (isChanged: boolean) => void;
};

export const StudentForm: React.FC<StudentFormProps> = (props) => {
  const [ isScopeOfActivityLvlEnabled, setIsScopeOfActivityLvlEnabled ] = useState<boolean>(false);
  const [ scopeOfActivityLvl2Options, setScopeOfActivityLvl2Options ] = useState<any>([]);
  const { data, isLoading, isFetching } = useGetscopeOfActivityQuery(undefined);
  const { studentData, setStudentData, setIsChanged } = props

  const scopeOfActivityLvl1ChangeHandler = (value: any) => {
    if (!isLoading && !isFetching) {
      const filteredData = data.filter( d => d.level === 2 && d.scopeOfActivityParentId === value );
      const lvl2Options = filteredData.map(({ id, nameOfScope }) => ({
        value: id,
        label: nameOfScope,
      }));

      if (lvl2Options.length === 0) {

      }
      setScopeOfActivityLvl2Options(lvl2Options);
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
      formParams={
        {
          key: DtoKeys.SCOPE_OF_ACTIVITY_LEVEL_TWO_ID,
          name: 'Сфера деятельности ур.2',
          shouldUpdate: true,
        }
      }
      options={scopeOfActivityLvl2Options}
    />
    {/* ...добавляем остальные контролы */}
  </StudentFormWrapper>);
};
