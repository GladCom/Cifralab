import React from 'react';
import Date from './common/Date.jsx'

const rules = [
    {
        required: true,
        message: 'Необходимо заполнить дату рождения',
    },
];

const formParams = {
    key: 'birthDate',
    name: 'Введите дату рождения',
    normalize: (value) => value,
    rules,
    hasFeedback: true,
};

const BirthDate = (props) => {
    return (
        <Date
            {
                ...{ 
                    ...props,
                    formParams,
                }
            }
        />
    );
};

export default BirthDate;