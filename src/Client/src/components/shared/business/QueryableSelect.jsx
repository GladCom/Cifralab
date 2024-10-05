import React, { useState, useEffect } from 'react';
import { Select } from 'antd';
import QueryableInfo from './common/QueryableInfo.jsx';
import QueryableEditableInfo from './common/QueryableEditableInfo.jsx';
import Editor from './Editor.jsx';
import YesNoButtons from './common/YesNoButtons.jsx';

const Form = ({ setId, value, crud, property }) => {
    const { data, error, isLoading, isFetching, refetch } = crud.getAllAsync();

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

const Edit = ({ id, setId, setMode, crud, property }) => {
    const { getAllAsync } = crud;
    const { data, error, isLoading, isFetching, refetch } = getAllAsync();
    const [newId, setNewId] = useState(id);

    const label = data?.filter(i => i.id === id)[0][property];

    return (
        <Editor>
            <Select
                showSearch
                defaultValue={label}
                style={{ minWidth: '150px' }}
                placeholder='Выберите значение'
                filterOption={(input, option) =>
                    (option?.label ?? '').toLowerCase().includes(input.toLowerCase())
                }
                onChange={setNewId}
                loading={isLoading || isFetching}
                options={(data || []).map((d) => ({
                    value: d.id,
                    label: d[property],
                }))}
            />
            <YesNoButtons
                setValue={() => {
                    setId(newId);
                }}
                onClick={() => {
                    setMode('editableInfo');
                }}
            />
        </Editor>
    );
};

const renderMode = {
    info: QueryableInfo,
    editableInfo: QueryableEditableInfo,
    form: Form,
    filter: Filter,
    edit: Edit,
};

const QueryableSelect = ({ id, mode, value, setValue, required, crud, property }) => {
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
            setId={(newId) => {
                const changed = newId !== null && initId !== newId;
                setChanged(changed);
                setValue(newId);
            }}
        />
    );
};

export default QueryableSelect;