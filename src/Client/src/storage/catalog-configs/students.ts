import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
} from '../crud/studentsCrud';
import { studentsModel } from '../models/index';
import BirthDate from '../../components/shared/business/BirthDate';

export default {
  detailsLink: 'student',
  hasDetailsPage: true,
  serverPaged: true,
  properties: studentsModel,
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
      title: 'Ф.И.О. обучающегося',
      dataIndex: 'studentFullName',
      key: 'fullName',
    },
    {
      title: 'Дата рождения',
      dataIndex: 'birthDate1',
      key: 'birthDate',
    },
    {
      title: 'Место проживания',
      dataIndex: 'address',
      key: 'address',
    },
    {
      title: 'Программа обучения',
      dataIndex: 'programName',
      key: 'programName',
    },
    {
      title: 'Группа',
      dataIndex: 'groupName',
      key: 'groupName',
    },
    {
      title: 'Год обучения',
      dataIndex: 'groupEndDate',
      key: 'groupEndDate',
    },
    {
      title: 'Статус заявки',
      dataIndex: 'statusRequestName',
      key: 'statusRequestName',
    },
  ],
  dataConverter: (data) => {
    return data?.map(({ birthDate, ...props }) => {
      const birthDate1 = <BirthDate value={birthDate} mode="info" />;
      return { ...props, birthDate1 };
    });
  },
};
