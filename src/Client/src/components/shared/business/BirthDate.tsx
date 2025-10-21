import React from 'react';
import _ from 'lodash';
import Date from './common/Date.jsx';

const rules = [
  {
    required: true,
    message: 'Необходимо заполнить дату рождения',
  },
];

const defaultFormParams = {
  key: 'birthDate',
  name: 'Введите дату рождения',
  normalize: (value) => value,
  rules,
  hasFeedback: true,
};

const BirthDate = ({ formParams, ...props }) => {
  return (
    <Date
      {...{
        defaultValue: '1990-03-05',
        ...props,
        formParams: _.merge({}, defaultFormParams, formParams),
      }}
    />
  );
};

export default BirthDate;
