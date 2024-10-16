import React, { useState, useCallback, useEffect, memo } from 'react';
import Info from './common/Info.jsx';
import EditableInfo from './common/EditableInfo.jsx';
import Editor from './Editor.jsx';
import YesNoButtons from './common/YesNoButtons.jsx';
import { Input } from 'antd';

const formatValue = (value, format) => (format ? format(value) : value);

const validateValue = async (value, validate) => {
    if (!validate) return;
    await validate(value);
};

// Оптимизация компонента ErrorMessage с помощью React.memo
const ErrorMessage = memo(({ error }) => error ? <span style={{ color: 'red' }}>{error}</span> : null);
ErrorMessage.displayName = 'ErrorMessage';

// Оптимизация компонента Form с помощью React.memo
const Form = memo(({ value, setValue, required, format }) => {

    //  TODO:   починить валидацию
    // const [newValue, setNewValue] = useState(value);

    // const handleChange = useCallback((inputValue) => {
    //     const formattedValue = formatValue(inputValue, format);
    //     setNewValue(formattedValue);
    //     setValue(formattedValue);
    // }, [format, setValue]); // Зависимости для useCallback

    // return (
    //     <Editor>
    //         <Input
    //             value={newValue}
    //             required={required}
    //             onChange={({ target }) => handleChange(target.value)}
    //             onPressEnter={({ target }) => handleChange(target.value)}
    //         />
    //     </Editor>
    // );

    useEffect(() => {setValue(value)}, []);
    
    return (
        <Input 
            allowClear
            defaultValue={value}
            type="textarea"
            onChange={({ target }) => setValue(target.value)}
        />
    );
});
Form.displayName = 'Form';


const NoValidationForm = memo(() => <Editor>В разработке</Editor>);
NoValidationForm.displayName = 'NoValidationForm';


const Filter = memo(() => <div>В разработке!</div>);
Filter.displayName = 'Filter';


const Edit = memo(({ value, setValue, setMode, validate, format }) => {
    const [newValue, setNewValue] = useState(value);
    const [error, setError] = useState('');

    const handleChange = useCallback((inputValue) => {
        const formattedValue = formatValue(inputValue, format);
        setNewValue(formattedValue);
    }, [format]);

    const handleSave = useCallback(async () => {
        try {
            await validateValue(newValue, validate);
            setValue(newValue);
            setMode('editableInfo');
            setError('');
        } catch (validationError) {
            setError(validationError.message || 'Validation failed');
        }
    }, [newValue, validate, setValue, setMode]);

    return (
        <Editor>
            <Input
                value={newValue}
                onChange={({ target }) => handleChange(target.value)}
                onPressEnter={handleSave}
            />
            <ErrorMessage error={error} />
            <YesNoButtons
                setValue={handleSave}
                onClick={() => setMode('editableInfo')}
            />
        </Editor>
    );
});
Edit.displayName = 'Edit';

const renderMode = {
    info: Info,
    editableInfo: EditableInfo,
    form: Form,
    filter: Filter,
    edit: Edit,
    noValidationForm: NoValidationForm,
};

const String = memo(({ id, mode, value, setValue, required, validate, format }) => {
    const [compMode, setCompMode] = useState(mode);
    const [changed, setChanged] = useState(false);

    const handleSetValue = useCallback((newValue) => {
        setChanged(newValue !== value);
        setValue(newValue);
    }, [value, setValue]);

    const Component = renderMode[compMode] || renderMode.info;

    return (
        <Component
            id={id}
            value={value}
            changed={changed}
            required={required}
            setMode={setCompMode}
            setValue={handleSetValue}
            validate={validate}
            format={format}
        />
    );
});
String.displayName = 'String';

export default String;
