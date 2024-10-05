import React from 'react';
import QueryableSelect from '../QueryableSelect.jsx';
import config from '../../../../storage/catalogConfigs/financingType.js';    

const FinancingTypeSelect = ({ id, mode, value, setValue, required }) => {
    const { crud } = config;

    return (
        <QueryableSelect
            id={id}
            value={value}
            required={required}
            crud={crud}
            mode={mode}
            setValue={setValue}
            property={'sourceName'}
        />
    );
};

export default FinancingTypeSelect;