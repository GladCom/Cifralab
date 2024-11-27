import React from 'react';
import _ from 'lodash';
import BaseComponent from './baseComponents/BaseComponent.jsx';

const formatPhoneNumber = (input) => {
    if (!input) return input;
    let digits = input.replace(/\D/g, '');
    if (digits.length > 0) {
      digits = '7' + digits.slice(1);
    }
    const limitedDigits = digits.slice(0, 11);
    return limitedDigits.replace(/(\d{1})(\d{3})(\d{3})(\d{2})(\d{2})/, '+$1 ($2) $3-$4-$5');
};

const rules = [
    {
        required: true,
        message: 'Необходимо заполнить номер телефона',
    },
    {
        pattern: /^\+7 \(\d{3}\) \d{3}-\d{2}-\d{2}$/,
        message: 'Некорректно заполнен номер телефона',
    },
];

const defaultFormParams = {
    key: 'phone',
    name: 'Номер телефона',
    normalize: (value) => formatPhoneNumber(value),
    rules,
};

const PhoneNumber = ({ formParams, ...props }) => (
    <BaseComponent
        {
            ...{
                ...props,
                formParams: _.merge({}, defaultFormParams, formParams),
            }
        }
    />
);

export default PhoneNumber;