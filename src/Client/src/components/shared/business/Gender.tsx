import React from 'react';
import { Select, Typography } from 'antd';
import _ from 'lodash';
import BaseControl from './base-components/base-component';

const { Text } = Typography;

const options = [
  { value: 0, label: 'мужской' },
  { value: 1, label: 'женский' },
];

const keyValueMap = {
  0: 'муж.',
  1: 'жен.',
  '': 'Выберите пол',
};

const DefaultInfoComponent = ({ value }) => <Text>{keyValueMap[value]}</Text>;

const DefaulGenderComponent = ({ value, onChange, formParams, placeholder }) => {
  const { key } = formParams;

  return (
    <Select
      key={key}
      defaultValue={value}
      variant="filled"
      placeholder={placeholder}
      //style={{ minWidth: '200px' }}
      options={options}
      onChange={onChange}
    />
  );
};

const components = {
  info: DefaultInfoComponent,
  editableInfo: DefaultInfoComponent,
  form: DefaulGenderComponent,
  edit: DefaulGenderComponent,
};

const rules = [
  {
    required: true,
    message: 'Необходимо выбрать пол',
  },
];

const defaultFormParams = {
  key: 'gender',
  name: 'Пол',
  rules: rules,
};

const Gender = ({ formParams, ...props }) => (
  <BaseControl
    {...{
      components,
      placeholder: 'Выберите пол',
      ...props,
      formParams: _.merge({}, defaultFormParams, formParams),
    }}
  />
);

export default Gender;
