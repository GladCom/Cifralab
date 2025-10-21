import React from 'react';
import _ from 'lodash';
import { InputNumber } from 'antd';
import BaseComponent from './baseComponents/BaseComponent.jsx';

const DefaultComponent = ({ value, onChange, formParams }) => {
  const { key } = formParams;

  return (
    <InputNumber key={key} min={1} max={10000} defaultValue={value} onChange={onChange} style={{ minWidth: '100px' }} />
  );
};

const components = {
  form: DefaultComponent,
  edit: DefaultComponent,
};

const rules = [
  {
    required: true,
    message: 'Необходимо указать кол-во часов',
  },
];

const defaultFormParams = {
  key: 'hoursCount',
  name: 'Кол-во часов',
  rules: rules,
};

const HoursCount = ({ formParams, ...props }) => (
  <BaseComponent
    {...{
      components,
      ...props,
      formParams: _.merge({}, defaultFormParams, formParams),
    }}
  />
);

export default HoursCount;
