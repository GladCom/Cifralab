import React, { useState } from 'react';
import { Form } from 'antd';
import BaseComponent from './common/BaseComponent';
import { AddressSuggestions } from 'react-dadata';
import 'react-dadata/dist/react-dadata.css';

const defaultRules = [
    {
        required: true,
        message: 'Необходимо заполнить адрес',
    },
];

const defaultFormParams = {
    key: 'address',
    name: 'Адрес',
    rules: defaultRules,
};

const AddressForm = ({ value, formParams }) => {
    const { key, name, rules } = formParams;
    const [addressValue, setAddressValue] = useState(value);

    return (
        <Form.Item
            key={key}
            name={key}
            label={name}
            rules={rules ?? []}
            hasFeedback={true}
        >
            <AddressSuggestions
                key={key}
                allowClear
                token="d9684e8c81525df77c58918948ebad6a9c83ea40"
                value={addressValue}
                onChange={setAddressValue}
            />
        </Form.Item>
    );
};

const renderMode = {
    //  form: AddressForm,  TODO:   в этом режиме отдает помимо value еще кучу всего
};

const Address = ({ mode, value, setValue, formParams }) => {

    return (
        <BaseComponent
            value={value}
            mode={mode}
            setValue={setValue}
            formParams={{ ...defaultFormParams, ...formParams }}
            renderMode={renderMode}
        />
    );
};

export default Address;
