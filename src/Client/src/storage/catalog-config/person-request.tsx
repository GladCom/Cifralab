import { useState, useEffect, useRef } from 'react';
import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
  useSearchAsync,
} from '../crud/person-request-crud';
import { useGetRequestStatusQuery } from '../service/request-status-api';
import { Select } from 'antd';
import { BirthDate } from '../../components/shared/control/birth-date';
import { CheckCircleFilled } from '@ant-design/icons';
import { DisplayMode } from '../../components/shared/control/multi-mode-control/types';
import { personRequestFormModel } from '../form-model/person-request';
import { EmailCopyButton } from '../../components/shared/control/email-copy-button';
import { useGetEducationProgramQuery } from '../service/education-program-api';
import { useGetTypeEducationQuery } from '../service/type-education-api';
import { useGetEntranceExamStatusesQuery } from '../service/request-api';
import { EntityTableConfig } from '../../components/shared/layout/entity-table';
import { InputStatus } from 'antd/es/_util/statusUtils';

//  TODO    лучше перенести эту реализацию в компонент RequestStatusSelect в новый режим
const StatusRequestForm = ({ record }) => {
  const { id, statusRequest } = record;
  const { data, isLoading, isFetching } = useGetRequestStatusQuery({});
  const [editRequest, { isSuccess, isError }] = useEditOneAsync();
  const [status, setStatus] = useState<InputStatus>();
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
      filterOption={(input, option) => (option?.label ?? '').toString().toLowerCase().includes(input.toLowerCase())}
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

export const personRequestConfig: EntityTableConfig = {
  detailsLink: 'requests',
  hasDetailsPage: true,
  serverPaged: true,
  formModel: personRequestFormModel,
  searchPlaceholder: 'Поиск по заявкам',
  crud: {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
    useSearchAsync,
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
      render: (_, record) => <BirthDate value={record.birthDate} displayMode={DisplayMode.VIEW} />,
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
          <EmailCopyButton email={email} />
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
