import { useState, useEffect, useRef } from 'react';
import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
} from '../crud/person-requests-crud';
import { useGetRequestStatusQuery } from '../service/request-status-api';
import { personRequestsModel } from '../model/index';
import BirthDate from '../../components/shared/control/birth-date';
import { Select } from 'antd';

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
  columns: [
    {
      title: 'Ф.И.О. заявителя',
      dataIndex: 'studentFullName',
      key: 'studentFullName',
    },
    {
      title: 'Дата рождения',
      dataIndex: 'birthDate',
      key: 'birthDate',
      render: (_, record) => <BirthDate value={record.birthDate} mode="info" />,
    },
    {
      title: 'Место проживания',
      dataIndex: 'address',
      key: 'address',
    },
    {
      title: 'Уровень образования',
      dataIndex: 'typeEducation',
      key: 'typeEducation',
    },
    {
      title: 'Программа обучения',
      dataIndex: 'educationProgram',
      key: 'educationProgram',
    },
    {
      title: 'E-mail',
      dataIndex: 'email',
      key: 'email',
    },
    {
      title: 'Статус',
      dataIndex: 'statusRequest',
      key: 'statusRequest',
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
