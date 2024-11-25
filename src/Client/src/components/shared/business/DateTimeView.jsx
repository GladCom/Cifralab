import React from 'react';
import _ from 'lodash';
import Date from './common/DateTime.jsx'

const rules = [
    {
        required: true,
        message: 'Необходимо заполнить дату создания заявки',
    },
];

const defaultFormParams = {
    key: 'dateOfCreate',
    name: 'Введите дату создания заявки',
    normalize: (value) => value,
    rules,
    hasFeedback: true,
};

const DateTimeView = ({ formParams, ...props }) => {
    return (
        <Date
            {
                ...{
                    defaultValue: '1990-03-05',
                    ...props,
                    mode: 'info',
                    formParams: _.merge({}, defaultFormParams, formParams),
                }
            }
        />
    );
};

export default DateTimeView;