import React from 'react';
import QueryableSelect from '../QueryableSelect.jsx';
import config from '../../../../storage/catalogConfigs/feaProgram.js';    

const FEAProgramSelect = ({ id, mode, value, setValue, required }) => {
    const { crud } = config;

    return (
        <QueryableSelect
            id={id}
            value={value}
            required={required}
            crud={crud}
            mode={mode}
            setValue={setValue}
        />
    );
};

export default FEAProgramSelect;