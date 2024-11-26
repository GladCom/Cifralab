import React from 'react';
import _ from 'lodash';
import { Checkbox } from 'antd';
import BaseComponent from '../baseComponents/BaseComponent.jsx';


const DefaultInfoComponent = ({ value }) => {
    return (
        <Checkbox 
            checked={value}
            disabled={true}
        />
    );
};

const DefaultEditFormComponent = ({ value, onChange, formParams }) => {
    const { key } = formParams;

    return (
        <Checkbox
            key={key}
            defaultChecked={value}
            onChange={({ target }) => {onChange(target.checked);}}
        />
    );
};

const components = {
    info: DefaultInfoComponent,
    editableInfo: DefaultInfoComponent,
    form: DefaultEditFormComponent,
    edit: DefaultEditFormComponent,
};

const rules = [
    {
        required: true,
        message: 'Необходимо установить значение',
    },
];

const defaultFormParams = {
    key: 'name',
    name: 'Да/Нет',
    rules,
};

const CheckBox = ({ formParams, ...props }) => (
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

export default CheckBox;