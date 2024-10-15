import React from 'react';
import String from '../../String'; 
import * as yup from 'yup';

const MODES = {
    EDITABLE_INFO: 'editableInfo',
    FORM: 'form',
    EDITOR: 'editor',
};



const snilsSchema = yup
    .string()
    .matches(/^\d{3}-\d{3}-\d{3} \d{2}$/, 'Неверный формат СНИЛС');


const validateSnils = async (snils) => {
    try {
        await snilsSchema.validate(snils);
        return true;
    } catch (validationError) {
        throw new Error(validationError.message);
    }
};


const formatSnils = (input) => {
    const digits = input.replace(/\D/g, ''); 
    const limitedDigits = digits.slice(0, 11); 
    return limitedDigits.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, '$1-$2-$3 $4');
};

// eslint-disable-next-line react/prop-types
const Snils = ({ value, setValue, mode = MODES.EDITABLE_INFO }) => (
    <String
        value={value}
        mode={mode}
        setValue={setValue}
        validate={validateSnils}
        format={formatSnils}
        required={true}
    />
);

export default Snils;
