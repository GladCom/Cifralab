import React, { useState } from 'react';
import _ from 'lodash';
import { AutoComplete } from 'antd';
import { BaseControl } from './base-controls/base-control';

const mails = ['mail.ru', 'gmail.com', 'ya.ru', 'icloud.com', 'disk.ru', 'list.ru'];

const DefaultFormComponent = ({ value, onChange, formParams }) => {
  const { key } = formParams;
  const [options, setOptions] = useState([]);

  const handleChange = (inputValue) => {
    setOptions(() => {
      if (!inputValue || inputValue.includes('@')) {
        return [];
      }
      return mails.map((domain) => ({
        label: `${inputValue}@${domain}`,
        value: `${inputValue}@${domain}`,
      }));
    });
  };

  return (
    <AutoComplete
      key={key}
      onSearch={handleChange}
      allowClear
      onChange={onChange}
      defaultValue={value}
      options={options}
    />
  );
};

const DefaultEditComponent = ({ value, onChange, formParams }) => {
  const { key } = formParams;
  const [options, setOptions] = useState([]);

  const handleChange = (inputValue) => {
    setOptions(() => {
      if (!inputValue || inputValue.includes('@')) {
        return [];
      }
      return mails.map((domain) => ({
        label: `${inputValue}@${domain}`,
        value: `${inputValue}@${domain}`,
      }));
    });
  };

  return (
    <AutoComplete
      key={key}
      onSearch={handleChange}
      allowClear
      onChange={onChange}
      defaultValue={value}
      options={options}
      style={{ minWidth: '250px' }}
    />
  );
};

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

const defaultFormParams = {
  key: 'email',
  name: 'E-mail',
  rules,
};

const Email = ({ formParams, ...props }) => (
  <BaseControl
    {...{
      components,
      placeholder: 'введите e-mail',
      ...props,
      formParams: _.merge({}, defaultFormParams, formParams),
    }}
  />
);

export default Email;
