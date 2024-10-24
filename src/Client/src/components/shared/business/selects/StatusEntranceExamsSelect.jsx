import { Select, Form, Button, Space } from 'antd'; 
import Info from '../common/Info.jsx';
import EditableInfo from '../common/EditableInfo.jsx';
import React, { useState, useCallback, useEffect, } from 'react';

const options = [
    { value: 0, label: 'Не сдано' },
    { value: 1, label: 'Тестовое задание' },
    { value: 2, label: 'Собеседование' },
    { value: 3, label: 'Выполнено' },
];
const defaultRules = [
    {
        required: true,
        message: 'Необходимо заполнить это поле',
    },
];

const defaultFormParams = {
    labelKey: 'name',
    name: 'Введите значение',
    normalize: (value) => value,
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
            <Select 
                defaultValue={value ?? 0}
                options={options}
                onChange={setValue}
            />
        </Form.Item>
    );
};

const Filter = () => <div>В разработке!</div>;

const Edit = ({ value, setValue, setMode, formParams }) => {
    const { key, name, normalize, rules } = formParams;

    const onSubmit = (formValues) => {
        setValue(formValues[key]);
        setMode('editableInfo');
    };

    return (
        <Form
            layout="inline"
            name="editModeForm"
            initialValues={{ [key]: value }}
            clearOnDestroy
            onFinish={(values) => onSubmit(values)}
        >
            <Form.Item
                key={key}
                name={key}
                initialValue={value}
                rules={rules ?? []}
                normalize={normalize}
                hasFeedback={true}
            >
                <Select 
                    defaultValue={value ?? 0}
                    options={options}
                    onChange={setValue}
                />
            </Form.Item>
            <Form.Item>
                <Space>
                <Button type="primary" htmlType="submit">
                    Сохранить
                </Button>
                <Button htmlType="button" onClick={() => setMode('editableInfo')}>
                    Отмена
                </Button>
                </Space>
            </Form.Item>
        </Form>
    );
};

const defaultRenderMode = {
    info: Info,
    editableInfo: EditableInfo,
    form: DefaultForm,
    filter: Filter,
    edit: Edit,
};

const StatusEntranceExamsSelect = ({ mode, value, setValue, formParams, renderMode }) => {
    const compRenderMode = { ...defaultRenderMode, ...renderMode };
    const [compMode, setCompMode] = useState(mode);
    const [changed, setChanged] = useState(false);

    const handleSetValue = useCallback((newValue) => {
        setChanged(newValue !== value);
        setValue(newValue);
    }, [value, setValue]);

    const Component = compRenderMode[compMode] || renderMode.info;

    return (
        <Component
            value={value}
            changed={changed}
            setMode={setCompMode}
            setValue={handleSetValue}
            formParams={{ ...defaultFormParams, ...formParams }}
        />
    );
};

export default StatusEntranceExamsSelect;