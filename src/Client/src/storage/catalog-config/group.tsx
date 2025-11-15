import { DisplayMode } from '../../components/shared/control/multi-mode-control/types';
import { EducationProgramSelect } from '../../components/shared/control/selects/education-program-select';
import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
} from '../crud/group-crud';
import { groupFormModel } from '../form-model/group';

export default {
  detailsLink: 'group',
  hasDetailsPage: true,
  serverPaged: false,
  properties: groupFormModel,
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
      const educationProgram = <EducationProgramSelect value={educationProgramId} displayMode={DisplayMode.VIEW} />;
      return { ...props, educationProgram };
    });
  },
};
