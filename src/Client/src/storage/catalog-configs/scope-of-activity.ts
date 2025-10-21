import React from 'react';
import {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetOneByIdAsync,
  useAddOneAsync,
  useEditOneAsync,
  useRemoveOneAsync,
} from '../crud/scopeOfActivityCrud';
import scopeOfActivityModel from '../models/scopeOfActivity';
import ScopeOfActivitySelect from '../../components/shared/business/selects/ScopeOfActivitySelect';

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
