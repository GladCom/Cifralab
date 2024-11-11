import React from 'react';
import String from '../String'; 
import * as yup from 'yup';

const MODES = {
    EDITABLE_INFO: 'editableInfo',
    FORM: 'form',
    EDITOR: 'editor',
};

const hoursSchema = yup
    .number()
    .required('Количество часов обязательно')
    .min(1, 'Количество часов должно быть не менее 1')
    .max(10000, 'Количество часов не может превышать 10000')
    .typeError('Количество часов должно быть числом');


const validateHours = async (hours) => {
    try {
        await hoursSchema.validate(hours);
        return true;
    } catch (validationError) {
        throw new Error(validationError.message);
    }
};


const formatHours = (hours) => {
    return hours ? new Intl.NumberFormat('ru-RU').format(hours) : '';
};

// Компонент для ввода и валидации количества часов обучения
// пока не приментяется
const HoursCount = ({ value, setValue, mode = MODES.EDITABLE_INFO }) => (
    <String
        value={formatHours(value)} 
        mode={mode}
        setValue={setValue}
        validate={validateHours} 
        required={true}
    />
);

export default HoursCount;
