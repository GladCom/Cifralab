import React from 'react';
import BaseComponent from '../common/BaseComponent';
import * as yup from 'yup';

const defaultRules = [
  {
    required: true,
    message: 'Телефон обязателен',
  },
  {
    pattern: /^\+7 \(\d{3}\) \d{3}-\d{2}-\d{2}$/,
    message: 'Неверный формат номера телефона',
  },
];

const defaultFormParams = {
  key: 'phoneNumber',
  name: 'Номер телефона',
  normalize: (value) => formatPhoneNumber(value),
  rules: defaultRules,
};

const formatPhoneNumber = (input) => {
  if (!input) return input;
  let digits = input.replace(/\D/g, '');
  if (digits.length > 0) {
    digits = '7' + digits.slice(1);
  }
  const limitedDigits = digits.slice(0, 11);
  return limitedDigits.replace(/(\d{1})(\d{3})(\d{3})(\d{2})(\d{2})/, '+$1 ($2) $3-$4-$5');
};

const PhoneNumber = ({ mode, value, setValue, formParams }) => {
  return (
    <BaseComponent
      name="Телефон"
      value={value}
      mode={mode}
      setValue={setValue}
      formParams={{ ...defaultFormParams, ...formParams }}
    />
  );
};

export default PhoneNumber;