import { useState } from 'react';
import _ from 'lodash';
import { AutoComplete } from 'antd';
import { BaseControl } from '../base-controls/base-control';
import {FieldProps, AutoCompleteOption, EmailProps} from '../base-controls/types';

const mails: string[] = ['mail.ru', 'gmail.com', 'ya.ru', 'icloud.com', 'disk.ru', 'list.ru', 'yahoo.com'];



const DefaultFormComponent = ({ value, onChange, formParams }: FieldProps) => {
  const { key } = formParams;
  const [options, setOptions] = useState<AutoCompleteOption[]>([]);

  const handleChange = (inputValue: string) => {
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

const DefaultEditComponent = ({ value, onChange, formParams }: FieldProps) => {
  const { key } = formParams;
  const [options, setOptions] = useState<AutoCompleteOption[]>([]);

  const handleChange = (inputValue: string) => {
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
  {
    pattern: /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$/,
    message: 'Только латиница и стандартный формат email',
  }
];

const defaultFormParams = {
  key: 'email',
  name: 'E-mail',
  rules
};



const Email = ({ formParams, ...props }: EmailProps) => (
  <BaseControl
    {...{
      components,
      placeholder: 'введите e-mail',
      ...props,
      params: {},
      formParams: _.merge({}, defaultFormParams, formParams),
    }}
  />
);

export default Email;
