import React, { useState, useEffect, useCallback } from 'react';
import Dropdown from 'react-bootstrap/Dropdown';
import DropdownButton from 'react-bootstrap/DropdownButton';
import Info from './common/Info.jsx';
import EditableInfo from './common/EditableInfo.jsx';
import { Form, Flex } from 'antd';

const defaultRules = [
    {
        required: true,
        message: 'Выберите вариант',
    },
];

const defaultFormParams = {
    key: 'name',
    name: 'Да/Нет',
    rules: defaultRules,
};

const DefaultForm = ({ value, setValue, formParams }) => {
    const { key, name, normalize, rules } = formParams;

    return (
        <Form.Item
            key={key}
            name={key}
            label={name}
        >
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
        </Form.Item>
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
        <Flex>
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
        </Flex>
    );
};

const renderMode = {
    info: Info,
    editableInfo: EditableInfo,
    form: DefaultForm,
    filter: Filter,
    edit: Edit,
};

const labelConverter = {
    'true': 'да',
    'false': 'нет',
    '': 'Выберите  значение',
};

const YesNoSelect = ({ id, mode, value, setValue, formParams }) => {
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
            formParams={{ ...defaultFormParams, ...formParams }}
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