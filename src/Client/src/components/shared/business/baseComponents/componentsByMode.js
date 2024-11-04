import React from 'react';
import { Input, Typography } from 'antd';
const { Text } = Typography;

const DefaultInfoComponent = ({ value }) => (
    <Text>{value}</Text>
);

const DefaultEditableInfoComponent = ({ value }) => (
    <Text>{value}</Text>
);

const DefaultEditComponent = ({ value, onChange, defaultValue, formParams }) => {
    const { key } = formParams;

    return (
        <Input
            key={key}
            allowClear
            value={value}
            onChange={onChange}
            defaultValue={defaultValue}
            type="textarea"
        />
    );
};

const DefaultFormComponent = ({ value, onChange, formParams }) => {
    const { key } = formParams;

    return (
        <Input
            key={key}
            allowClear
            value={value}
            onChange={onChange}
            defaultValue=''
            type="textarea"
        />
    );
};

//  TODO:   доработать компонент
const DefaultFilterComponent = () => (
    <Text>В разработке</Text>
);

//  TODO:   доработать компонент
const DefaultModalComponent = () => (
    <Text>В разработке</Text>
);


const defaultComponentsByMode = {
    info: DefaultInfoComponent,
    editableInfo: DefaultEditableInfoComponent,
    form: DefaultFormComponent,
    filter: DefaultFilterComponent,
    edit: DefaultEditComponent,
    modal: DefaultModalComponent,
};

export default defaultComponentsByMode;