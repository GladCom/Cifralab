import React, { useState, useEffect, useCallback } from 'react';
import Dropdown from 'react-bootstrap/Dropdown';
import DropdownButton from 'react-bootstrap/DropdownButton';
import Info from './common/Info.jsx';
import EditableInfo from './common/EditableInfo.jsx';
import Editor from './Editor.jsx';

const Form = ({ value, setValue }) => {
    const title = value ? 'да' : 'нет';

    return (
        <Editor>
            <DropdownButton 
                id="dropdown-basic-button"
                title={title}
                size="sm"
            >
                <Dropdown.Item onClick={() => {
                    setValue(false);
                }}>
                    нет
                </Dropdown.Item>
                <Dropdown.Item onClick={() => {
                    setValue(true);
                }}>
                    да
                </Dropdown.Item>
            </DropdownButton>
        </Editor>
    );
};

const NoValidationForm = ({ id, value, setValue, required }) => {

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
    const title = value ? 'да' : 'нет';

    return (
        <Editor>
            <DropdownButton 
                id="dropdown-basic-button"
                title={title}
                size="sm"
            >
                <Dropdown.Item onClick={() => {
                    setValue(false);
                    setMode('editableInfo');
                }}>
                    нет
                </Dropdown.Item>
                <Dropdown.Item onClick={() => {
                    setValue(true);
                    setMode('editableInfo');
                }}>
                    да
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
    noValidationForm: NoValidationForm,
};

const YesNoSelect = ({ mode, value, setValue, required }) => {
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

export default YesNoSelect;