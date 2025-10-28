import React from 'react';
import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
} from '../crud/scope-of-activity-crud';
import scopeOfActivityModel from '../models/scope-of-activity';
import ScopeOfActivitySelect from '../../components/shared/business/selects/scope-of-activity-select';

const iconStyle = { marginRight: '5px' };

export default {
  detailsLink: 'scopeOfActivity',
  hasDetailsPage: false,
  serverPaged: false,
  properties: scopeOfActivityModel,
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
      title: 'Сфера деятельности',
      dataIndex: 'nameOfScope',
      key: 'nameOfScope',
    },
    {
      title: 'Уровень',
      dataIndex: 'level',
      key: 'level',
    },
    {
      title: 'Здарова, Отец',
      dataIndex: 'scopeOfActivityParentId',
      key: 'scopeOfActivityParentId',
    },
  ],
  dataConverter: (data) => {
    return data?.map(({ scopeOfActivityParentId, ...props }) => {
      const parent = <ScopeOfActivitySelect value={scopeOfActivityParentId} mode="info" />;
      return { ...props, scopeOfActivityParentId: parent };
    });
  },
};
