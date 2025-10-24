import React from 'react';
import { Typography } from 'antd';
import BaseComponent from './base-components/base-component';

const { Text } = Typography;

const DefaultInfoComponent = ({ value }) => {
  return <Text>{value}</Text>;
};

const components = {
  info: DefaultInfoComponent,
  editableInfo: DefaultInfoComponent,
  form: DefaultInfoComponent,
  filter: DefaultInfoComponent,
  edit: DefaultInfoComponent,
  modal: DefaultInfoComponent,
};

const formParams = {
  rules: [
    {
      required: false,
    },
  ],
};

const Age = (props) => (
  <BaseComponent
    {...{
      ...props,
      mode: 'info',
      components,
      formParams,
    }}
  />
);

export default Age;
