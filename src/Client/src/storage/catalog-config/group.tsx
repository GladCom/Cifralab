import { DisplayMode } from '../../features/shared/control/multi-mode-control/types';
import { EducationProgramSelect } from '../../features/shared/control/selects/education-program-select';
import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
  useSearchAsync,
} from '../crud/group-crud';
import { groupFormModel } from '../form-model/group';

export const groupConfig = {
  detailsLink: 'group',
  hasDetailsPage: true,
  serverPaged: false,
  formModel: groupFormModel,
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
