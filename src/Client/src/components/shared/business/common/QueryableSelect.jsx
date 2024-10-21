import React, { useState, useEffect } from 'react';
import { Form, Select, Space, Button } from 'antd';
import QueryableInfo from './QueryableInfo.jsx';
import QueryableEditableInfo from './QueryableEditableInfo.jsx';
import YesNoButtons from './YesNoButtons.jsx';

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

const DefaultForm = ({ setId, value, crud, property }) => {
    const { data, error, isLoading, isFetching, refetch } = crud.useGetAllAsync();

    return (
        <Select
            showSearch
            defaultValue={value}
            style={{ minWidth: '150px' }}
            placeholder='Выберите значение'
            filterOption={(input, option) =>
                (option?.label ?? '').toLowerCase().includes(input.toLowerCase())
            }
            onChange={setId}
            loading={isLoading || isFetching}
            options={(data || []).map((d) => ({
                value: d.id,
                label: d[property],
            }))}
        />
    );
};

const Filter = () => {
    //  TODO:   реализовать функционал
    return (
        <div>В разработке!</div>
    );
};

const Edit = ({ id, setId, setMode, crud, property, formParams}) => {
    const { useGetAllAsync } = crud;
    const { key, name, normalize, rules } = formParams;
    const { data, isLoading, isFetching, refetch } = useGetAllAsync();

    const label = data?.filter(i => i.id === id)[0][property];

    const onSubmit = (formValues) => {
        setId(formValues[key]);
        setMode('editableInfo');
    };

    return (
        <Form
            layout="inline"
            name="selectEditModeForm"
            clearOnDestroy
            onFinish={(values) => onSubmit(values)}
        >
            <Form.Item
                key={key}
                name={key}
                initialValue={label}
                rules={rules ?? []}
                hasFeedback={true}
            >
                <Select
                    showSearch
                    defaultValue={label}
                    //style={{ minWidth: '250px' }} //  TODO: разобраться почему не растягивается
                    placeholder='Выберите значение'
                    filterOption={(input, option) =>
                        (option?.label ?? '').toLowerCase().includes(input.toLowerCase())
                    }
                    loading={isLoading || isFetching}
                    options={(data || []).map((d) => ({
                        value: d.id,
                        label: d[property],
                    }))}
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

const renderMode = {
    info: QueryableInfo,
    editableInfo: QueryableEditableInfo,
    form: DefaultForm,
    filter: Filter,
    edit: Edit,
};

const QueryableSelect = ({ id, mode, value, setValue, required, crud, property, formParams }) => {
    const [compMode, setCompMode] = useState(mode);
    const [changed, setChanged] = useState(false);
    const [initId, setInitId] = useState(id ?? '');
    const [label, setLabel] = useState(value ?? '');

    useEffect(() => {
        setInitId(id);
    }, []);

    const Component = renderMode[compMode];

    return (
        <Component
            id={id}
            value={label}
            required={required}
            crud={crud}
            changed={changed}
            setMode={setCompMode}
            property={property ?? 'name'}
            formParams={{ ...defaultFormParams, ...formParams }}
            setId={(newId) => {
                const changed = newId !== null && initId !== newId;
                setChanged(changed);
                setValue(newId);
            }}
        />
    );
};

export default QueryableSelect;