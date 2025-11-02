import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
} from '../crud/groups-crud';
import { groupsModel } from '../models/index';
import React from 'react';
import EducationProgramSelect from '../../components/shared/business/selects/education-program-select';

export default {
  detailsLink: 'group',
  hasDetailsPage: true,
  serverPaged: false,
  properties: groupsModel,
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
      title: 'Группа',
      dataIndex: 'name',
      key: 'name',
    },
    {
      title: 'Программа обучения',
      dataIndex: 'educationProgram',
      key: 'educationProgram',
    },
    {
      title: 'Дата начала',
      dataIndex: 'startDate',
      key: 'startDate',
    },
    {
      title: 'Дата окончания',
      dataIndex: 'endDate',
      key: 'endDate',
    },
    {
      title: 'В архив',
      key: 'nameOfGroup',
    },
  ],
  dataConverter: (data) => {
    return data?.map(({ educationProgramId, ...props }) => {
      const educationProgram = <EducationProgramSelect value={educationProgramId} mode="info" />;
      return { ...props, educationProgram };
    });
  },
};
