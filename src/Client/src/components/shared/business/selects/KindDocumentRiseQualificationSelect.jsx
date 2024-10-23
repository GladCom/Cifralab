import React from 'react';
import QueryableSelect from '../common/QueryableSelect.jsx';
import config from '../../../../storage/catalogConfigs/kindDocumentRiseQualification.js';    

const defaultRules = [
    {
        required: true,
        message: 'Необходимо заполнить это поле',
    },
];

const defaultFormParams = {
    labelKey: 'name',
    name: 'Вид документа повышения квалификации',
    normalize: (value) => value,
    rules: defaultRules,
};

const KindDocumentRiseQualificationSelect = ({ id, mode, value, setValue, formParams }) => {
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

export default KindDocumentRiseQualificationSelect;