import React, { useState, useEffect } from 'react';
import Dropdown from 'react-bootstrap/Dropdown';
import DropdownButton from 'react-bootstrap/DropdownButton';
import Info from './common/Info.jsx';
import EditableInfo from './common/EditableInfo.jsx';
import { Flex, Form } from 'antd';

const defaultRules = [
    {
        required: true,
        message: 'Необходимо выбрать пол',
    },
];

const defaultFormParams = {
    key: 'gender',
    name: 'Пол',
    rules: defaultRules,
};

const DefaultForm = ({ value, setValue, formParams }) => {
    const { key, name, normalize, rules } = formParams;

    return (
        <Form.Item
            key={key}
            name={key}
            label={name}
            rules={rules ?? []}
            normalize={normalize}
            hasFeedback={true}
        >
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

const genderLabelConverter = {
    0: 'муж.',
    1: 'жен.',
    '': 'Выберите пол',
};

const Gender = ({ id, mode, value, setValue, formParams }) => {
    const [compMode, setCompMode] = useState(mode);
    const [initValue, setInitValue] = useState(value);
    const [currentLabel, setCurrentLabel] = useState(genderLabelConverter[value]);
    const [changed, setChanged] = useState(false);
    
    useEffect(() => {
        setCurrentLabel(genderLabelConverter[value] ?? 'Выберите пол');
    }, [value]);

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
                setCurrentLabel(genderLabelConverter[newValue]);
            }}
        />
    );
};

export default Gender;