import React from 'react';
import QueryableSelect from '../common/QueryableSelect.jsx';
import config from '../../../../storage/catalogConfigs/financingType.js';    

const defaultRules = [
    {
        required: true,
        message: 'Необходимо заполнить это поле',
    },
];

const defaultFormParams = {
    labelKey: 'sourceName',
    name: 'Тип финансирования',
    normalize: (value) => value,
    rules: defaultRules,
};

const FinancingTypeSelect = ({ id, mode, value, setValue, formParams }) => {
    const { crud } = config;

    return (
        <QueryableSelect
            id={id}
            value={value}
            crud={crud}
            mode={mode}
            setValue={setValue}
            fformParams={{ ...defaultFormParams, ...formParams }}
        />
    );
};

export default FinancingTypeSelect;