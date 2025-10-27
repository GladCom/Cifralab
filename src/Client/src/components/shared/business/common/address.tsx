import React, { useCallback } from 'react';
import { AddressSuggestions } from 'react-dadata';
import 'react-dadata/dist/react-dadata.css';
import { BaseControl } from '../base-controls/base-control';

const DefaultFormComponent = ({ value, onChange, formParams }) => {
  const { key } = formParams;

  const formattValue = useCallback((value) => {
    onChange(value.value);
  });

  return (
    <AddressSuggestions
      value={value}
      key={key}
      allowClear
      token="d9684e8c81525df77c58918948ebad6a9c83ea40"
      onChange={formattValue}
    />
  );
};

const DefaultEditComponent = ({ value, onChange, formParams }) => {
  const { key } = formParams;
  const formattValue = useCallback((value) => {
    onChange(value.value);
    console.log(value);
  });

  return (
    <AddressSuggestions
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
];

const formParams = {
  key: 'address',
  name: 'Место проживания',
  normalize: (value) => value,
  rules,
  hasFeedback: true,
};

const Address = (props) => {
  return (
    <BaseControl
      {...{
        ...props,
        //components,
        formParams,
      }}
    />
  );
};

export default Address;
