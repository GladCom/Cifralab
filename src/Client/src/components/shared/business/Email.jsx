import React, { useState } from 'react';
import BaseComponent from './baseComponents/BaseComponent.jsx';
import { AutoComplete } from 'antd';

const mails = [
    'mail.ru',
    'gmail.com',
    'ya.ru',
    'icloud.com',
    'disk.ru',
    'list.ru',
];

const DefaultFormComponent = ({ value, onChange, formParams }) => {
    const { key } = formParams;
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
        <AutoComplete
            key={key}
            onSearch={handleChange}
            allowClear
            onChange={onChange}
            defaultValue={value}
            options={options}
        />
    );
};

const DefaultEditComponent = ({ value, onChange, formParams }) => {
    const { key } = formParams;
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
        <AutoComplete
            key={key}
            onSearch={handleChange}
            allowClear
            onChange={onChange}
            defaultValue={value}
            options={options}
            style={{ minWidth: '250px' }}
        />
    );
};

const components = {
    form: DefaultFormComponent,
    edit: DefaultEditComponent,
};

const rules = [
    {
        required: true,
        message: 'Необходимо заполнить email',
    },
    {
        type: 'email',
        message: 'Некорректно заполнен email',
    },
];

const formParams = {
    key: 'email',
    name: 'E-mail',
    rules,
};

const Email = (props) => (
    <BaseComponent
        {
            ...{ 
                ...props,
                components,
                formParams,
            }
        }
    />
);

export default Email;
