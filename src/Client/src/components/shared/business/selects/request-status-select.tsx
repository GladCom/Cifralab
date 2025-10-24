import React from 'react';
import _ from 'lodash';
import QueryableSelect from '../common/queryable-select';
import config from '../../../../storage/catalog-configs/request-status';

const defaultRules = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const defaultFormParams = {
  labelKey: 'name',
  name: 'Статус заявки',
  normalize: (value) => value,
  rules: defaultRules,
};

const RequestStatusSelect = ({ value, formParams, ...props }) => {
  const { crud } = config;
  const { useGetOneByIdAsync, useGetAllAsync } = crud;
  const { data: dataById } = useGetOneByIdAsync(value);
  const { data: allData } = useGetAllAsync();

  return (
    <QueryableSelect
      {...{
        ...props,
        dataById: dataById || {},
        allData: allData || [],
        crud: config.crud,
        formParams: _.merge({}, defaultFormParams, formParams),
      }}
    />
  );
};

export default RequestStatusSelect;
