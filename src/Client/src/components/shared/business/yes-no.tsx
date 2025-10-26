import React, { useEffect } from 'react';
import _ from 'lodash';
import { Switch, Typography } from 'antd';
import BaseControl from './base-components/base-component';

const { Text } = Typography;
const keyValueMap = {
  false: 'нет',
  true: 'да',
};

const DefaultInfoComponent = ({ value }) => {
  return <Text>{keyValueMap[value]}</Text>;
};

const DefaultEditFormComponent = ({ value, onChange, formParams }) => {
  const { key } = formParams;

  //  Эффект нужен чтобы проинициализировать начальным значением
  useEffect(() => {
    onChange(value || false);
  }, []);

  return <Switch key={key} defaultValue={value || false} onChange={onChange} defaultChecked={value || false} />;
};

const components = {
  info: DefaultInfoComponent,
  editableInfo: DefaultInfoComponent,
  form: DefaultEditFormComponent,
  edit: DefaultEditFormComponent,
};

const rules = [
  {
    required: true,
    message: 'Выберьте значение',
  },
];

const defaultFormParams = {
  key: 'ошибка!',
  name: 'ошибка!',
  rules: rules,
};

const YesNo = ({ formParams, ...props }) => (
  <BaseControl
    {...{
      components,
      ...props,
      formParams: _.merge({}, defaultFormParams, formParams),
    }}
  />
);

export default YesNo;
