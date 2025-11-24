import { useState, useEffect, useRef } from 'react';
import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
} from '../crud/person-request-crud';
import { useGetRequestStatusQuery } from '../service/request-status-api';
import { Select } from 'antd';
import { BirthDate } from '../../components/shared/control/birth-date';
import { CheckCircleFilled } from '@ant-design/icons';
import { DisplayMode } from '../../components/shared/control/multi-mode-control/types';
import { personRequestFormModel } from '../form-model/person-request';
import { EmailCopyButton } from '../../components/shared/control/email-copy-button';

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
  properties: personRequestFormModel,
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
      render: (_, record) => <BirthDate value={record.birthDate} displayMode={DisplayMode.VIEW} />,
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
