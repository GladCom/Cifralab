import React, { useState, useEffect, useCallback } from 'react';
import { Select } from 'antd';
import Info from './common/Info.jsx';
import EditableInfo from './common/EditableInfo.jsx';
import Editor from './Editor.jsx';
import YesNoButtons from './common/YesNoButtons.jsx';
import { useGetTypeEducationQuery, useGetTypeEducationByIdQuery } from '../../../storage/services/typeEducationApi.js';

const Form = ({ setId, value }) => {
    const { data, error, isLoading, isFetching, refetch } = useGetTypeEducationQuery();

    return (
        <Select
            showSearch
            defaultValue={value}
            style={{ minWidth: '150px' }}
            placeholder='Выберите уровень образования'
            filterOption={(input, option) =>
                (option?.label ?? '').toLowerCase().includes(input.toLowerCase())
            }
            onChange={setId}
            loading={isLoading || isFetching}
            options={(data || []).map((d) => ({
                value: d.id,
                label: d.name,
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

const Edit = ({ id, setId, value, setMode }) => {
    const { data, error, isLoading, isFetching, refetch } = useGetTypeEducationQuery();
    const [newVId, setNewId] = useState(id);

    return (
        <Editor>
            <Select
                showSearch
                defaultValue={value}
                style={{ minWidth: '150px' }}
                placeholder='Выберите уровень образования'
                filterOption={(input, option) =>
                    (option?.label ?? '').toLowerCase().includes(input.toLowerCase())
                }
                onChange={setNewId}
                loading={isLoading || isFetching}
                options={(data || []).map((d) => ({
                    value: d.id,
                    label: d.name,
                }))}
            />
            <YesNoButtons
                setValue={() => {
                    setId(newVId);
                }}
                onClick={() => {
                    setMode('editableInfo');
                }}
            />
        </Editor>
    );
};

const renderMode = {
    'info': Info,
    'editableInfo': EditableInfo,
    'form': Form,
    'filter': Filter,
    'edit': Edit,
};

const EducationType = ({ mode, id, setNewId }) => {
    const [compMode, setCompMode] = useState(mode);
    const [changed, setChanged] = useState(false);
    const [initId, setInitId] = useState(id);
    const [value, setValue] = useState('');

    const { data, error, isLoading, isFetching, refetch } = useGetTypeEducationByIdQuery(id);

    useEffect(() => {
        if (!isLoading && !isFetching) {
            const valueFromServer = data?.name;
            setValue(valueFromServer);
        }
    }, [isLoading, isFetching]);

    const Component = renderMode[compMode];

    return (
        <Component
            id={id}
            value={value}
            changed={changed}
            setMode={setCompMode}
            setId={(newId) => {
                const changed = newId !== null && initId !== newId;
                setChanged(changed);
                setNewId(newId);
            }}
        />
    );
};

export default EducationType;