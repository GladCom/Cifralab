import React, { useState, useEffect, useCallback } from 'react';
import { EditOutlined } from '@ant-design/icons';
import { Form, Checkbox, Button, Space } from 'antd';
import Stack from 'react-bootstrap/Stack';

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

const Info = ({ value }) => {
    return (
        <Checkbox checked={value} disabled={true} />
    );
};

const ChangeSymbol = () => (<span className="">* </span>);

const EditableInfo = ({ value, changed, setMode }) => {

    return (
        <>
            <Stack direction="horizontal" className="m-3">
                <div className="me-1">
                    {changed && (<ChangeSymbol />)}
                    <Checkbox checked={value} disabled={true} />
                </div>
                <div type="button" onClick={() => setMode('edit')}>
                    <EditOutlined />
                </div>
            </Stack>
        </>
    );
};

const DefaultForm = ({ setValue, formParams }) => {
    const { key, name, normalize, rules } = formParams;

    return (
        <Form.Item
            key={key}
            name={key}
            label={name}
        >
            <Checkbox onChange={(e) => setValue(e.target.checked)} />
        </Form.Item>
    );
};

const Filter = () => {
    //  TODO:   реализовать функционал
    return (
        <div>В разработке!</div>
    );
};

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
            //initialValues={{ [key]: value }}
            clearOnDestroy
            onFinish={(values) => onSubmit(values)}
        >
            <Form.Item
                key={key}
                name={key}
                initialValue={value}
                rules={rules ?? []}
            >
                <Checkbox checked={value} />
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

const CheckBox = ({ mode, value, setValue, formParams, renderMode }) => {
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

export default CheckBox;