import React, { useState, useCallback, useEffect, memo } from 'react';
import Info from './Info.jsx';
import EditableInfo from './EditableInfo.jsx';
import { Flex, Form, Input, Button, Space } from 'antd';

const defaultRules = [
    {
        required: true,
        message: 'Необходимо заполнить это поле',
    },
];

const defaultFormParams = {
    key: 'name',
    name: 'Введите значение',
    normalize: (value) => value,
    rules: defaultRules,
};

// Оптимизация компонента Form с помощью React.memo
const DefaultForm = memo(({ value, formParams }) => {
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
            <Input
                key={key}
                allowClear
                defaultValue={value}
                type="textarea"
            />
        </Form.Item>
    );
});
DefaultForm.displayName = 'Form';


const NoValidationForm = memo(() => <Flex>В разработке</Flex>);
NoValidationForm.displayName = 'NoValidationForm';


const Filter = memo(() => <div>В разработке!</div>);
Filter.displayName = 'Filter';


const Edit = memo(({ value, setValue, setMode, formParams }) => {
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
                normalize={normalize}
                hasFeedback={true}
            >
                <Input
                    key={key}
                    allowClear
                    defaultValue={value}
                    type="textarea" 
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
});
Edit.displayName = 'Edit';

const defaultRenderMode = {
    info: Info,
    editableInfo: EditableInfo,
    form: DefaultForm,
    filter: Filter,
    edit: Edit,
    noValidationForm: NoValidationForm,
};

const BaseComponent = memo(({ mode, value, setValue, formParams, renderMode }) => {
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
});
BaseComponent.displayName = 'BaseComponent';

export default BaseComponent;
