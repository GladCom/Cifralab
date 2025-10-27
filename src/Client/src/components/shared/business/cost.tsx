import React from 'react';
import _ from 'lodash';
import { InputNumber } from 'antd';
import { BaseControl } from './base-controls/base-control';

const DefaultComponent = ({ value, onChange, formParams }) => {
  const { key } = formParams;

  return (
    <InputNumber
      key={key}
      min={1}
      max={1000000}
      prefix="₽"
      defaultValue={value}
      onChange={onChange}
      style={{ minWidth: '150px' }}
    />
  );
};

const components = {
  form: DefaultComponent,
  edit: DefaultComponent,
};

const rules = [
  {
    required: true,
    message: 'Выберите значение',
  },
];

const defaultFormParams = {
  key: 'cost!',
  name: 'Стоимость',
  rules: rules,
};

const Cost = ({ formParams, ...props }) => (
  <BaseControl
    {...{
      components,
      ...props,
      formParams: _.merge({}, defaultFormParams, formParams),
    }}
  />
);

export default Cost;
