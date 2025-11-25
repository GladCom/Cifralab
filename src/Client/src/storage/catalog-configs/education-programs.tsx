import { useState, useEffect, useRef } from 'react';
import { Checkbox } from 'antd';
import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
  useSearchAsync,
} from '../crud/education-program-crud';
import { educationProgramsModel } from '../models/index';
import KindEducationProgramSelect from '../../components/shared/business/selects/kind-education-program-select';
import EducationFormSelect from '../../components/shared/business/selects/education-form-select';

//  TODO    лучше перенести эту реализацию в компонент в новый режим
const InArchive = ({ record }) => {
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
  properties: educationProgramsModel,
  searchPlaceholder: 'Поиск',
  crud: {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
    useSearchAsync,
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
      render: (_, record) => <KindEducationProgramSelect value={record.kindEducationProgramId} mode="info" />,
    },
    {
      title: 'Форма обучения',
      dataIndex: 'educationFormId',
      key: 'educationFormId',
      render: (_, record) => <EducationFormSelect value={record.educationFormId} mode="info" />,
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
      render: (_, record) => <InArchive record={record} />,
    },
  ],
  dataConverter: (data) => data,
};
