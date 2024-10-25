import React from 'react';
import QueryableSelect from '../common/QueryableSelect.jsx';
import config from '../../../../storage/catalogConfigs/scopeOfActivity.js';    

const defaultRules = [
    {
        required: true,
        message: 'Необходимо заполнить это поле',
    },
];

const defaultFormParams = {
    labelKey: 'nameOfScope',
    name: 'Сфера деятельности',
    normalize: (value) => value,
    rules: defaultRules,
};

const ScopeOfActivitySelect = ({ id, mode, value, setValue, formParams }) => {
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

export default ScopeOfActivitySelect;