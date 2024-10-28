import React from 'react';
import QueryableSelect from '../common/QueryableSelect.jsx';
import config from '../../../../storage/catalogConfigs/typeEducation.js';    

const defaultRules = [
    {
        required: true,
        message: 'Необходимо заполнить это поле',
    },
];

const defaultFormParams = {
    labelKey: 'name',
    name: 'Тип образования',
    normalize: (value) => value,
    rules: defaultRules,
};

const EducationFormSelect = ({ id, mode, value, setValue, formParams }) => {
    const { crud } = config;

    return (
        <QueryableSelect
            id={id}
            value={value}
            crud={crud}
            mode={mode}
            setValue={setValue}
            formParams={{ ...defaultFormParams, ...formParams }}
        />
    );
};

export default EducationFormSelect;