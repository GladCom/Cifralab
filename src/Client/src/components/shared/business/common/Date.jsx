import React, { useCallback } from 'react';
import BaseComponent from '../baseComponents/BaseComponent.jsx';
import { DatePicker, Typography } from 'antd';
import dayjs from 'dayjs';

const { Text } = Typography;

const DefaultInfoComponent = ({ value }) => (
    <Text>{dayjs(value).format('DD.MM.YYYY')}</Text>
);

const DefaultEditableInfoComponent = ({ value }) => (
    <Text>{dayjs(value).format('DD.MM.YYYY')}</Text>
);

const DefaultFormComponent = ({ value, onChange, formParams }) => {
    const { key } = formParams;

    const formattValue = useCallback((value) => {
        const formattedDateString = dayjs(value).format('YYYY-MM-DD');
        onChange(formattedDateString);
    });

    return (
        <DatePicker
            key={key}
            defaultValue={dayjs(value)}
            format={{
                format: 'DD.MM.YYYY',
                type: 'mask',
              }}
            onChange={formattValue}
        />
    );
};

const DefaultEditComponent = ({ value, onChange, formParams }) => {
    const { key } = formParams;

    const formattValue = useCallback((value) => {
        const formattedDateString = dayjs(value).format('YYYY-MM-DD');
        onChange(formattedDateString);
    });

    return (
        <DatePicker
            key={key}
            defaultValue={dayjs(value)}
            format={{
                format: 'DD.MM.YYYY',
                type: 'mask',
              }}
            onChange={formattValue}
        />
    );
};

const components = {
    info: DefaultInfoComponent,
    editableInfo: DefaultEditableInfoComponent,
    form: DefaultFormComponent,
    edit: DefaultEditComponent,
};

const rules = [
    {
        required: true,
        message: 'Необходимо заполнить дату',
    },
];

const formParams = {
    key: 'birthDate',
    name: 'Введите дату',
    normalize: (value) => value,
    rules,
    hasFeedback: true,
};

const Date = (props) => {
    return (
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
};

export default Date;