import { useState, useEffect, useRef } from 'react';
import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
} from '../crud/person-requests-crud';
import { useGetEducationProgramQuery } from '../services/education-program-api';
import { useGetRequestStatusQuery } from '../services/request-status-api';
import { useGetTypeEducationQuery } from '../services/type-education-api';
import { useGetEntranceExamStatusesQuery } from '../services/requests-api';
import { personRequestsModel } from '../models/index';
import { Select } from 'antd';
import { CheckCircleFilled } from '@ant-design/icons';
import BirthDate from '../../components/shared/business/birth-date';
import { EmailCopyButton } from '../../components/shared/business/common/email-copy-button';

//  TODO    лучше перенести эту реализацию в компонент RequestStatusSelect в новый режим
const StatusRequestForm = ({ record }) => {
  const { id, statusRequest, statusRequestId } = record;
  const { data, isLoading, isFetching, refetch } = useGetRequestStatusQuery();
  const [editRequest, { isSuccess, isError }] = useEditOneAsync();
  const [status, setStatus] = useState('');
  const selectRef = useRef(null);

  useEffect(() => {
    if (isError) {
      setStatus('error');
    }
  }, [isSuccess, isError]);

  const onChange = (statusRequestId) => {
    const editetRequest = { ...record };
    delete editetRequest.id;
    editRequest({ id, item: { ...editetRequest, statusRequestId } });
    selectRef.current.blur();
  };

  return (
    <Select
      showSearch
      ref={selectRef}
      defaultValue={statusRequest}
      style={{ minWidth: '150px' }}
      placeholder="Статус заявки"
      filterOption={(input, option) => (option?.label ?? '').toLowerCase().includes(input.toLowerCase())}
      onChange={onChange}
      variant="borderless"
      loading={isLoading || isFetching}
      status={status}
      options={(data || []).map((d) => ({
        value: d.id,
        label: d.name,
      }))}
    />
  );
};

export default {
  detailsLink: 'requests',
  hasDetailsPage: true,
  serverPaged: true,
  properties: personRequestsModel,
  crud: {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
  },
  filters: [
    {
      key: 'educationProgramId',
      backendKey: 'EducationProgramId',
      label: 'Программа обучения',
      placeholder: 'Все программы',
      useQuery: useGetEducationProgramQuery,
      mapOptions: (data) =>
        (Array.isArray(data) ? data : []).map((item) => ({
          value: item.id,
          label: item.name,
        })),
    },
    {
      key: 'statusRequestId',
      backendKey: 'StatusRequestId',
      label: 'Статус заявки',
      placeholder: 'Все статусы',
      useQuery: useGetRequestStatusQuery,
      mapOptions: (data) =>
        (Array.isArray(data) ? data : []).map((item) => ({
          value: item.id,
          label: item.name,
        })),
    },
    {
      key: 'typeEducationId',
      backendKey: 'TypeEducationId',
      label: 'Уровень образования',
      placeholder: 'Все уровни образования',
      useQuery: useGetTypeEducationQuery,
      mapOptions: (data) =>
        (Array.isArray(data) ? data : []).map((item) => ({
          value: item.id,
          label: item.name,
        })),
    },
    {
      key: 'statusEntrancExams',
      backendKey: 'StatusEntranceExam',
      label: 'Статус вступительного испытания',
      placeholder: 'Все статусы испытания',
      useQuery: useGetEntranceExamStatusesQuery,
      mapOptions: (data) =>
        (Array.isArray(data) ? data : []).map((item) => ({
          value: item.id,
          label: item.status,
        })),
    },
  ],
  columns: [
    {
      title: 'Ф.И.О. заявителя',
      dataIndex: 'studentFullName',
      key: 'studentFullName',
      sorter: true,
      sorterKey: 'StudentFullName',
    },
    {
      title: 'Дата рождения',
      dataIndex: 'birthDate',
      key: 'birthDate',
      sorter: true,
      sorterKey: 'BirthDate',
      render: (_, record) => <BirthDate value={record.birthDate} mode="info" />,
    },
    {
      title: 'Место проживания',
      dataIndex: 'address',
      key: 'address',
      sorter: true,
      sorterKey: 'Address',
    },
    {
      title: 'Уровень образования',
      dataIndex: 'typeEducation',
      key: 'typeEducation',
      sorter: true,
      sorterKey: 'TypeEducation',
    },
    {
      title: 'Программа обучения',
      dataIndex: 'educationProgram',
      key: 'educationProgram',
      sorter: true,
      sorterKey: 'EducationProgram',
    },
    {
      title: 'E-mail',
      dataIndex: 'email',
      key: 'email',
      sorter: true,
      sorterKey: 'Email',
      render: (_, { email }) => (
        <span>
          {email} &nbsp;
          <EmailCopyButton  email={email} />
        </span>
      ),
    },
    {
      title: 'Статус',
      dataIndex: 'statusRequest',
      key: 'statusRequest',
      sorter: true,
      sorterKey: 'StatusRequest',
      render: (_, record) => {
        return <StatusRequestForm record={record} />;
      },
    },
    {
      title: 'Обучающийся',
      key: 'trined',
      render: (_, { trained }) => {
        return trained && <CheckCircleFilled style={{ color: '#52c41a' }} />;
      },
    },
  ],
  dataConverter: (data) => data,
};
