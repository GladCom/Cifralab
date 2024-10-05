import React, { useState, useEffect, useCallback } from 'react';
import Dropdown from 'react-bootstrap/Dropdown';
import DropdownButton from 'react-bootstrap/DropdownButton';
import Info from './common/Info.jsx';
import EditableInfo from './common/EditableInfo.jsx';
import Editor from './Editor.jsx';

const Form = ({ value, setValue }) => {

    return (
        <Editor>
            <DropdownButton 
                id="dropdown-basic-button"
                title={value}
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
};

const labelConverter = {
    'true': 'да',
    'false': 'нет',
    '': 'Выберите  значение',
};

const YesNoSelect = ({ id, mode, value, setValue, required }) => {
    const [compMode, setCompMode] = useState(mode);
    const [initValue, setInitValue] = useState(value);
    const [currentLabel, setCurrentLabel] = useState(labelConverter[value]);
    const [changed, setChanged] = useState(false);
    
    useEffect(() => {
        setCurrentLabel(labelConverter[value] );
    }, [value]);

    useEffect(() => {
        setInitValue(value);
    }, []);

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
                setCurrentLabel(labelConverter[newValue] );
            }}
        />
    );
};

export default YesNoSelect;