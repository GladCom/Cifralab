import React, { useCallback } from 'react';
import _ from 'lodash';
import BaseComponent from '../baseComponents/BaseComponent.jsx';
import { DatePicker, Typography } from 'antd';
import dayjs from 'dayjs';

const { Text } = Typography;

const DefaultInfoComponent = ({ value }) => (
    <Text>{dayjs(value).format('DD.MM.YYYY HH:mm:ss')}</Text>
);

const DefaultEditableInfoComponent = ({ value }) => (
    <Text>{dayjs(value).format('DD.MM.YYYY HH:mm:ss')}</Text>
);

const DefaultFormComponent = ({ defaultValue, onChange, formParams }) => {
    const { key } = formParams;

    const formattValue = useCallback((value) => {
        const formattedDateString = dayjs(value).format('YYYY-MM-DDTHH:mm:ss');
        onChange(formattedDateString);
    });

    return (
        <DatePicker
            key={key}
            defaultValue={dayjs(defaultValue)}
            showTime
            format={{
                format: 'DD.MM.YYYY HH:mm:ss',
                type: 'mask',
              }}
            onChange={formattValue}
        />
    );
};

const DefaultEditComponent = ({ value, onChange, formParams }) => {
    const { key } = formParams;

    const formattValue = useCallback((value) => {
        const formattedDateString = dayjs(value).format('YYYY-MM-DDTHH:mm:ss');
        onChange(formattedDateString);
    });

    return (
        <DatePicker
            key={key}
            defaultValue={dayjs(value)}
            showTime
            format={{
                format: 'DD.MM.YYYY HH:mm:ss',
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

const defaultFormParams = {
    key: 'date',
    name: 'Введите дату',
    normalize: (value) => value,
    rules,
    hasFeedback: true,
};

const DateTime = ({ formParams, ...props }) => {
    return (
        <BaseComponent
            {
                ...{
                    ...props,
                    components,
                    formParams: _.merge({}, defaultFormParams, formParams),
                }
            }
        />
    );
};

export default DateTime;