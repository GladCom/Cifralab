import React from 'react';
import _ from 'lodash';
import { InputNumber } from 'antd';
import BaseComponent from './baseComponents/BaseComponent.jsx';

const DefaultComponent = ({ value, onChange, formParams }) => {
    const { key } = formParams;

    return (
        <InputNumber
            key={key}
            min={1}
            max={2}
            defaultValue={value || 1}
            onChange={onChange}
            style={{ minWidth: '100px' }}
        />
    );
};

const components = {
    form: DefaultComponent,
    edit: DefaultComponent,
};

const rules = [
    {
        required: true,
        message: 'Необходимо указать уровень',
    },
];

const defaultFormParams = {
    key: 'level',
    name: 'Уровень сферы деятельности',
    rules: rules,
};

const ScopeOfActivityLevel = ({ formParams, ...props }) => (
    <BaseComponent
        {
            ...{
                components,
                ...props,
                formParams: _.merge({}, defaultFormParams, formParams),
            }
        }
    />
);

export default ScopeOfActivityLevel;