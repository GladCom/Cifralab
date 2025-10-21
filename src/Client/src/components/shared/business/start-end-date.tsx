import React from 'react';

import BaseComponent from './baseComponents/BaseComponent';
import { AutoComplete } from 'antd';

const components = {
  form: DefaultFormComponent,
  edit: DefaultEditComponent,
};

const rules = [
  {
    required: true,
    message: 'Необходимо заполнить email',
  },
  {
    type: 'email',
    message: 'Некорректно заполнен email',
  },
];

const formParams = {
  key: 'email',
  name: 'E-mail',
  rules,
};

const StartEndDate = (props) => (
  <BaseComponent
    {...{
      ...props,
      components,
      formParams,
    }}
  />
);

export default StartEndDate;
