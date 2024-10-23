import React, { useState, useEffect } from 'react';
import { Form, Select, Space, Button } from 'antd';
import QueryableInfo from './QueryableInfo.jsx';
import QueryableEditableInfo from './QueryableEditableInfo.jsx';

const defaultRules = [
    {
        required: true,
        message: 'Необходимо заполнить это поле',
    },
];

const defaultFormParams = {
    key: 'name',
    name: 'Введите значение',
    rules: defaultRules,
};

const DefaultForm = ({ setId, value, crud, formParams }) => {
    const { key, labelKey, name, normalize, rules } = formParams;
    const { data, error, isLoading, isFetching, refetch } = crud.useGetAllAsync();

    return (
        <Form.Item
            key={key}
            name={key}
            label={name}
            rules={rules ?? []}
            hasFeedback={true}
        >
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
                    label: d[labelKey],
                }))}
            />
        </Form.Item>
    );
};

const Filter = () => {
    //  TODO:   реализовать функционал
    return (
        <div>В разработке!</div>
    );
};

const Edit = ({ value, setId, setMode, crud, formParams}) => {
    const { useGetAllAsync } = crud;
    const { key, labelKey, name, normalize, rules } = formParams;
    const { data, isLoading, isFetching, refetch } = useGetAllAsync();

    //const label = data?.filter(i => i.id === value)[0][key];

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
                initialValue={value}
                rules={rules ?? []}
                hasFeedback={true}
            >
                <Select
                    showSearch
                    defaultValue={value}
                    style={{ minWidth: '250px' }} //  TODO: разобраться почему не растягивается
                    placeholder='Выберите значение'
                    filterOption={(input, option) =>
                        (option?.label ?? '').toLowerCase().includes(input.toLowerCase())
                    }
                    loading={isLoading || isFetching}
                    options={(data || []).map((d) => ({
                        value: d.id,
                        label: d[labelKey],
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

const QueryableSelect = ({ mode, value, setValue, crud, formParams }) => {
    const [compMode, setCompMode] = useState(mode);
    const [changed, setChanged] = useState(false);
    const [initId, setInitId] = useState(value ?? '');

    useEffect(() => {
            setInitId(value);   //  TODO:    тут баг короче: value изначально приходит пустым
    }, []);

    const Component = renderMode[compMode];

    return (
        <Component
            //id={id}
            value={value}
            crud={crud}
            changed={changed}
            setMode={setCompMode}
            formParams={{ ...defaultFormParams, ...formParams }}
            setId={(newId) => {
                console.log(newId)
                console.log(initId)
                const changed = newId !== null && initId !== newId;
                setChanged(changed);
                setValue(newId);
            }}
        />
    );
};

export default QueryableSelect;