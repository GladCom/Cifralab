import React from 'react';
import QueryableSelect from '../QueryableSelect.jsx';
import config from '../../../../storage/catalogConfigs/scopeOfActivity.js';    

const ScopeOfActivitySelect = ({ id, mode, value, setValue, required }) => {
    const { crud } = config;

    return (
        <QueryableSelect
            id={id}
            value={value}
            required={required}
            crud={crud}
            mode={mode}
            setValue={setValue}
            property={'nameOfScope'}
        />
    );
};

export default ScopeOfActivitySelect;