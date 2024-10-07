import React, { useState, useEffect } from 'react';
import Info from './common/Info.jsx';
import EditableInfo from './common/EditableInfo.jsx';
import Editor from './Editor.jsx';
import YesNoButtons from './common/YesNoButtons.jsx';
import { Input } from 'antd';

const Form = ({ value, setValue, required }) => {

    return (
        <Editor>
            <Input 
                value={value}
                required={required}
                onChange={({ target }) => {
                    setValue(target.value)
                }} 
                onPressEnter={({ target }) => {
                    setValue(target.value)
                }} 
            />
        </Editor>
    );
};

const NoValidationForm = ({ value, setValue, required }) => {

    return (
        <Editor>
            В разработке
        </Editor>
    );
};

const Filter = () => {
    //  TODO:   реализовать функционал
    return (
        <div>В разработке!</div>
    );
};

const Edit = ({ value, setValue, setMode }) => {
    const [newValue, setNewValue] = useState(value);

    return (
        <Editor>
            <Input 
                value={newValue}
                onChange={({ target }) => {
                    setNewValue(target.value)
                }} 
                onPressEnter={({ target }) => {
                    setNewValue(target.value)
                }} 
            />
            <YesNoButtons
                setValue={() => {
                    setValue(newValue);
                }}
                onClick={() => {
                    setMode('editableInfo');
                }}
            />
        </Editor>
    );
};

const renderMode = {
    info: Info,
    editableInfo: EditableInfo,
    form: Form,
    filter: Filter,
    edit: Edit,
    noValidationForm: NoValidationForm,
};

const String = ({ id, mode, value, setValue, required }) => {
    const [compMode, setCompMode] = useState(mode);
    const [initValue, setInitValue] = useState(value);
    const [currentValue, setCurrentValue] = useState(value);
    const [changed, setChanged] = useState(false);

    useEffect(() => {
        setCurrentValue(value);
    }, [value]);

    const Component = renderMode[compMode] ?? renderMode.info;

    return (
        <Component
            id={id}
            value={currentValue}
            changed={changed}
            required={required}
            setMode={setCompMode}
            setValue={(newValue) => {
                setChanged(newValue !== initValue);
                setValue(newValue);
                setCurrentValue(newValue);
            }}
        />
    );
};

export default String;