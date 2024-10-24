import React from 'react';
import BaseComponent from './common/BaseComponent'; 

const defaultRules = [
    {
        required: true,
        message: 'Необходимо заполнить СНИЛС',
    },
    {
        pattern: /^\d{3}-\d{3}-\d{3} \d{2}$/,
        message: 'Некорректно заполнен СНИЛС',
    },
];

const defaultFormParams = {
    key: 'snils',
    name: 'СНИЛС',
    normalize: (value) => formatSnils(value),
    rules: defaultRules,
};

const formatSnils = (input) => {
    const digits = input.replace(/\D/g, ''); 
    const limitedDigits = digits.slice(0, 11);
    return limitedDigits.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, '$1-$2-$3 $4');

    
};

const Snils = ({ mode, value, setValue, formParams }) => {
    //const { rules } = formParams;   //  TODO:   подумать как корректно передавать required из конфигов

    return (
        <BaseComponent
            value={value}
            mode={mode}
            setValue={setValue}
            formParams={{ ...defaultFormParams, ...formParams }}
        />
    );
};

export default Snils;
