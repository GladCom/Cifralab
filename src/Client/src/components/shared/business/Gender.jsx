import React, { useState, useEffect } from 'react';
import Dropdown from 'react-bootstrap/Dropdown';
import DropdownButton from 'react-bootstrap/DropdownButton';
import Info from './common/Info.jsx';
import EditableInfo from './common/EditableInfo.jsx';
import Editor from './Editor.jsx';

const Form = ({ value, setValue }) => {

    return (
        <>
            <DropdownButton 
                id="dropdown-basic-button"
                title={value}
                size="sm"
            >
                <Dropdown.Item onClick={() => {
                    setValue(0);
                }}>
                    мужской
                </Dropdown.Item>
                <Dropdown.Item onClick={() => {
                    setValue(1);
                }}>
                    женский
                </Dropdown.Item>
            </DropdownButton>
        </>
    );
};

const Filter = () => {
    //  TODO:   реализовать функционал
    return (
        <div>В разработке!</div>
    );
};

const Edit = ({ value, setValue, setMode }) => {

    return (
        <Editor>
            <DropdownButton 
                id="dropdown-basic-button"
                title={value}
                size="sm"
            >
                <Dropdown.Item onClick={() => {
                    setValue(0);
                    setMode('editableInfo');
                }}>
                    мужской
                </Dropdown.Item>
                <Dropdown.Item onClick={() => {
                    setValue(1);
                    setMode('editableInfo');
                }}>
                    женский
                </Dropdown.Item>
            </DropdownButton>
        </Editor>
    );
};

const renderMode = {
    info: Info,
    editableInfo: EditableInfo,
    form: Form,
    filter: Filter,
    edit: Edit,
};

const genderLabelConverter = {
    0: 'муж.',
    1: 'жен.',
    '': 'Выберите пол',
};

const Gender = ({ id, mode, value, setValue, required }) => {
    const [compMode, setCompMode] = useState(mode);
    const [initValue, setInitValue] = useState(value);
    const [currentLabel, setCurrentLabel] = useState(genderLabelConverter[value]);
    const [changed, setChanged] = useState(false);
    
    useEffect(() => {
        setCurrentLabel(genderLabelConverter[value] ?? 'z');
    }, [value]);

    const Component = renderMode[compMode] ?? renderMode.info;

    return (
        <Component
            id={id}
            value={currentLabel}
            changed={changed}
            required={required}
            setMode={setCompMode}
            setValue={(newValue) => {
                setChanged(newValue !== initValue);
                setValue(newValue);
                setCurrentLabel(genderLabelConverter[newValue]);
            }}
        />
    );
};

export default Gender;