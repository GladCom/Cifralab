import { useCallback } from 'react';
// import { AddressSuggestions } from 'react-dadata';
// import 'react-dadata/dist/react-dadata.css';
import { BaseControl } from '../base-controls/base-control';
import { Input } from 'antd';
import { ControlByMode } from '../base-controls/types';

const DefaultFormComponent = ({ value, onChange, formParams }) => {
  const { key } = formParams;

  const formattValue = useCallback((value) => {
    onChange(value.value);
  });

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

const DefaultEditComponent = ({ value, onChange, formParams }) => {
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
      //token="d9684e8c81525df77c58918948ebad6a9c83ea40"
      onChange={formattValue}
    />
  );
};

const components: ControlByMode = {
  formItem: DefaultFormComponent,
  editor: DefaultEditComponent,
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
        components,
        formParams,
      }}
    />
  );
};

export default Address;
