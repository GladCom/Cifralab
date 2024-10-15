import React from 'react';
import QueryableSelect from '../QueryableSelect';
import config from '../../../../storage/catalogConfigs/educationForm.js';    

const EducationFormSelect = ({ id, mode, value, setValue, required }) => {
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

export default EducationFormSelect;