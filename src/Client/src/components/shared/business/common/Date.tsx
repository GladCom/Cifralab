import React, { useCallback } from 'react';
import _ from 'lodash';
import BaseComponent from '../base-components/base-component';
import { DatePicker, Typography } from 'antd';
import dayjs from 'dayjs';

const { Text } = Typography;

const DefaultInfoComponent = ({ value }) => <Text>{dayjs(value).format('DD.MM.YYYY')}</Text>;

const DefaultEditableInfoComponent = ({ value }) => <Text>{dayjs(value).format('DD.MM.YYYY')}</Text>;

const format = {
  format: 'DD.MM.YYYY',
  type: 'mask',
};

const DefaultFormComponent = ({ defaultValue, onChange, formParams, placeholder }) => {
  const { key } = formParams;

  const formattValue = useCallback((value) => {
    const formattedDateString = dayjs(value).format('YYYY-MM-DD');
    onChange(formattedDateString);
  });

  return (
    <DatePicker
      key={key}
      placeholder={placeholder}
      defaultPickerValue={dayjs(defaultValue)}
      format={format}
      onChange={formattValue}
    />
  );
};

const DefaultEditComponent = ({ value, onChange, formParams }) => {
  const { key } = formParams;

  const formattValue = useCallback((value) => {
    const formattedDateString = dayjs(value).format('YYYY-MM-DD');
    onChange(formattedDateString);
  });

  return <DatePicker key={key} defaultValue={dayjs(value)} format={format} onChange={formattValue} />;
};

const components = {
  info: DefaultInfoComponent,
  editableInfo: DefaultEditableInfoComponent,
  form: DefaultFormComponent,
  edit: DefaultEditComponent,
};

const rules = [
  {
    required: true,
    message: 'Необходимо заполнить дату',
  },
];

const defaultFormParams = {
  key: 'date',
  name: 'Введите дату',
  normalize: (value) => value,
  rules,
  hasFeedback: true,
};

const Date = ({ formParams, ...props }) => {
  return (
    <BaseComponent
      {...{
        ...props,
        components,
        formParams: _.merge({}, defaultFormParams, formParams),
      }}
    />
  );
};

export default Date;
