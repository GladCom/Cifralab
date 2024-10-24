import React, { useState } from 'react';
import String from './String';
import { Form, Button, Space, AutoComplete } from 'antd';

const defaultRules = [
    {
        required: true,
        message: 'Необходимо заполнить email',
    },
    {
        type: 'email',
        message: 'Некорректно заполнен email',
    },
];

const defaultFormParams = {
    key: 'email',
    name: 'E-mail',
    normalize: (value) => formatEmail(value),
    rules: defaultRules,
};

const mails = [
    'mail.ru',
    'gmail.com',
    'ya.ru',
    'icloud.com',
    'disk.ru',
    'list.ru',
];

const EmailForm = ({ value, formParams }) => {
    const { key, name, normalize, rules } = formParams;
    const [options, setOptions] = useState([]);

    const handleChange = (inputValue) => {
        setOptions(() => {
            if (!inputValue || inputValue.includes('@')) {
                return [];
            }
            return mails.map((domain) => ({
                label: `${inputValue}@${domain}`,
                value: `${inputValue}@${domain}`,
            }));
        });
    };

    return (
        <Form.Item
            key={key}
            name={key}
            label={name}
            rules={rules ?? []}
            normalize={normalize}
            hasFeedback={true}
        >
            <AutoComplete
                key={key}
                onSearch={handleChange}
                allowClear
                defaultValue={value}
                options={options}
            />
        </Form.Item>
    );
};

const EmailEdit = ({ value, setValue, setMode, formParams }) => {
    const { key, name, normalize, rules } = formParams;
    const [options, setOptions] = useState([]);

    const handleChange = (inputValue) => {
        setOptions(() => {
            if (!inputValue || inputValue.includes('@')) {
                return [];
            }
            return mails.map((domain) => ({
                label: `${inputValue}@${domain}`,
                value: `${inputValue}@${domain}`,
            }));
        });
    };

    const onSubmit = (formValues) => {
        setValue(formValues[key]);
        setMode('editableInfo');
    };

    return (
        <Form
            layout="inline"
            name="emailEditModeForm"
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
                <AutoComplete
                    key={key}
                    onSearch={handleChange}
                    allowClear
                    defaultValue={value}
                    options={options}
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

const formatEmail = (value) => value;

const renderMode = {
    form: EmailForm,
    //edit: EmailEdit,  //  TODO:   есть проблемы с отображением автокомплита, надо разобраться
};

const Email = ({ mode, value, setValue, formParams }) => (
    <String
        value={value}
        mode={mode}
        setValue={setValue}
        formParams={{ ...defaultFormParams, ...formParams }}
        renderMode={renderMode}
    />
);

export default Email;
