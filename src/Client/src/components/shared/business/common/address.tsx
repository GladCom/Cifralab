import { useCallback } from 'react';
// import { AddressSuggestions } from 'react-dadata';
// import 'react-dadata/dist/react-dadata.css';
import { BaseControl } from '../base-controls/base-control';
import { Input } from 'antd';
import { AddressProps, FieldProps } from '../base-controls/types';

const DefaultFormComponent = ({ value, onChange, formParams }: FieldProps) => {
  const { key } = formParams;

  const formattValue = useCallback((value) => {
    onChange(value.value);
  }, []);

  return (
    <Input
      value={value}
      key={key}
      allowClear
      // token="d9684e8c81525df77c58918948ebad6a9c83ea40"
      onChange={formattValue}
    />
  );
};

const DefaultEditComponent = ({ value, onChange, formParams }: FieldProps) => {
  const { key } = formParams;
  const formattValue = useCallback((value) => {
    onChange(value.value);
    console.log(value);
  });

  return (
    <Input
      value={value}
      key={key}
      allowClear
      token="d9684e8c81525df77c58918948ebad6a9c83ea40"
      onChange={formattValue}
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
    message: 'Необходимо заполнить место проживания',
  },
  {
    pattern: /^[А-Яа-яЁё0-9\s-.,/]+$/,
    message: 'Неверный формат адреса',
  }
];

const formParams = {
  key: 'address',
  name: 'Место проживания',
  normalize: (value: string) => value,
  rules,
  hasFeedback: true,
};

const Address = (props) : AddressProps => {
  return (
    <BaseControl
      {...{
        ...props,
        components,
        formParams,
      }}
    />
  );
};

export default Address;
