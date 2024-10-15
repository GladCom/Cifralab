import React from 'react';

import String from '../../String'; 
import * as yup from 'yup';

const MODES = {
    EDITABLE_INFO: 'editableInfo',
    FORM: 'form',
    EDITOR: 'editor',
};



const emailSchema = yup
.string()
.email('Неверный формат email')
.required('Email является обязательным полем');


const validateEmail = async (snils) => {
    try {
        await emailSchema.validate(snils);
        return true;
    } catch (validationError) {
        throw new Error(validationError.message);
    }
};




const Email = ({ value, setValue, mode = MODES.EDITABLE_INFO }) => (
    <String
        value={value}
        mode={mode}
        setValue={setValue}
        validate={validateEmail}
        required={true}
    />
);

export default Email;
