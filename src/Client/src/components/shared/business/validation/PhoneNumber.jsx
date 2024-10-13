import React from 'react';

import String from '../String'; 
import * as yup from 'yup';

const MODES = {
    EDITABLE_INFO: 'editableInfo',
    FORM: 'form',
    EDITOR: 'editor',
};




const russianPhoneSchema = yup
    .string()
    .required('Телефон обязателен')
    .matches(/^\+7 \(\d{3}\) \d{3}-\d{2}-\d{2}$/, 'Неверный формат номера телефона');



const validateEmail = async (snils) => {
    try {
        await russianPhoneSchema.validate(snils);
        return true;
    } catch (validationError) {
        throw new Error(validationError.message);
    }
};




const PhoneNumber = ({ value, setValue, mode = MODES.EDITABLE_INFO }) => (
    <String
        value={value}
        mode={mode}
        setValue={setValue}
        validate={validateEmail}
        required={true}
    />
);

export default PhoneNumber;
