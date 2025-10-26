import React from 'react';
import { Typography } from 'antd';
import { BaseControl } from './base-controls/base-control';

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
  <BaseControl
    {...{
      ...props,
      mode: 'info',
      components,
      formParams,
    }}
  />
);

export default Age;
