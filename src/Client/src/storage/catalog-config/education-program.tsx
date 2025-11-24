import { useState, useEffect, useRef } from 'react';
import { Checkbox } from 'antd';
import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
} from '../crud/education-form-crud';
import { KindEducationProgramSelect } from '../../components/shared/control/selects/kind-education-program-select';
import { EducationFormSelect } from '../../components/shared/control/selects/education-form-select';
import { DisplayMode } from '../../components/shared/control/multi-mode-control/types';
import { educationProgramFormModel } from '../form-model/education-program';

//  TODO    лучше перенести эту реализацию в компонент в новый режим
const IsArchive = ({ record }) => {
  const { id, isArchive } = record;
  const [editProgram, { isSuccess, isError }] = useEditOneAsync();
  const [status, setStatus] = useState('');
  const checkboxRef = useRef(null);

  useEffect(() => {
    if (isError) {
      setStatus('error');
    }
  }, [isSuccess, isError]);

  const onChange = ({ target }) => {
    const editetProgram = { ...record };
    delete editetProgram.id;
    delete editetProgram.educationForm;
    delete editetProgram.kindDocumentRiseQualification;
    editProgram({ id, item: { ...editetProgram, isArchive: target.checked } });
    checkboxRef.current.blur();
  };

  return <Checkbox ref={checkboxRef} defaultChecked={isArchive} onChange={onChange} />;
};

export default {
  detailsLink: 'educationProgram',
  hasDetailsPage: true,
  serverPaged: false,
  properties: educationProgramFormModel,
  crud: {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
  },
  columns: [
    {
      title: 'Программа обучения',
      dataIndex: 'name',
      key: 'name',
    },
    {
      title: 'Вид программы',
      dataIndex: 'kindEducationProgramId',
      key: 'kindEducationProgramId',
      render: (_, record) => (
        <KindEducationProgramSelect value={record.kindEducationProgramId} displayMode={DisplayMode.VIEW} />
      ),
    },
    {
      title: 'Форма обучения',
      dataIndex: 'educationFormId',
      key: 'educationFormId',
      render: (_, record) => <EducationFormSelect value={record.educationFormId} displayMode={DisplayMode.VIEW} />,
    },
    {
      title: 'Кол-во часов',
      dataIndex: 'hoursCount',
      key: 'hoursCount',
    },
    {
      title: 'В архив',
      dataIndex: 'isArchive',
      key: 'archive',
      render: (_, record) => <IsArchive record={record} />,
    },
  ],
  dataConverter: (data) => data,
};
