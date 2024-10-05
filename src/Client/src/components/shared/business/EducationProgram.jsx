import React, { useState, useEffect } from 'react';
import { Select } from 'antd';
import Info from './common/Info.jsx';
import EditableInfo from './common/EditableInfo.jsx';
import Editor from './Editor.jsx';
import YesNoButtons from './common/YesNoButtons.jsx';
import { 
    useGetEducationProgramQuery as useGetAllQuery,
    useGetEducationProgramByIdQuery as useGetOneByIdQuery,
} from '../../../services/educationProgramApi.js';

const placeholder = 'Выберите программу';

const Form = ({ setId, value }) => {
    const { data, error, isLoading, isFetching, refetch } = useGetAllQuery();

    return (
        <Select
            showSearch
            defaultValue={value}
            style={{ minWidth: '150px' }}
            placeholder={placeholder}
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
    const { data, error, isLoading, isFetching, refetch } = useGetAllQuery();
    const [newId, setNewId] = useState(id);

    return (
        <Editor>
            <Select
                showSearch
                defaultValue={value}
                style={{ minWidth: '150px' }}
                placeholder={placeholder}
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
    'info': Info,
    'editableInfo': EditableInfo,
    'form': Form,
    'filter': Filter,
    'edit': Edit,
};

const EducationProgram = ({ id, mode, value, setValue, required, crud }) => {
    const [compMode, setCompMode] = useState(mode);
    const [changed, setChanged] = useState(false);
    const [initId, setInitId] = useState('');
    const [programName, setProgramName] = useState(value);

    const { getOneByIdAsync } = crud;
    const { data, error, isLoading, isFetching, refetch } = getOneByIdAsync(id);

    useEffect(() => {
        if (!isLoading && !isFetching) {
            const nameFromServer = data?.name;
            setProgramName(nameFromServer);
        }
    }, [isLoading, isFetching, id]);

    useEffect(() => {
        setInitId(id);
    }, []);
console.log(initId)
    const Component = renderMode[compMode];

    return (
        <Component
            id={id}
            value={programName}
            required={required}
            crud={crud}
            changed={changed}
            setMode={setCompMode}
            setId={(newId) => {
                const changed = newId !== null && initId !== newId;
                setChanged(changed);
                setValue(newId);
            }}
        />
    );
};

export default EducationProgram;