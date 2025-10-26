import React from 'react';
import { templateParser, templateFormatter, parseDigit } from 'input-format';
import BaseControl from './base-components/base-component';

//  TODO:   разобраться с форматтером
const TEMPLATE = 'xxx-xxx-xxx xx';
const parse = templateParser(TEMPLATE, parseDigit);
const format = templateFormatter(TEMPLATE);

const formatSnils = (input) => {
  const digits = input.replace(/\D/g, '');
  const limitedDigits = digits.slice(0, 11);
  return limitedDigits.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, '$1-$2-$3 $4');
};

const rules = [
  {
    required: true,
    message: 'Необходимо заполнить СНИЛС',
  },
  {
    pattern: /^\d{3}-\d{3}-\d{3} \d{2}$/,
    message: 'Некорректно заполнен СНИЛС',
  },
];

const formParams = {
  key: 'snils',
  name: 'СНИЛС',
  normalize: (value) => formatSnils(value),
  rules: rules,
};

const Snils = (props) => (
  <BaseControl
    {...{
      ...props,
      formParams,
    }}
  />
);

export default Snils;
