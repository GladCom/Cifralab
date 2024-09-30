import React, { useState, useEffect, useCallback } from 'react';
import Dropdown from 'react-bootstrap/Dropdown';
import DropdownButton from 'react-bootstrap/DropdownButton';
import Info from './Info.jsx';
import Editor from './Editor.jsx';
import { DownOutlined } from '@ant-design/icons';

const Gender = ({ initValue, setValue, editable, formMode, filterMode }) => {
    const [editingMode, setEditingMode] = useState(formMode || filterMode);
    const [value, setGenderValue] = useState(initValue);
    const [valueChanged, setValueChanged] = useState(false);
    const [title, setTitle] = useState('Выберите пол');

    useEffect(() => {
        setGenderValue(initValue);
    }, [initValue]);

    useEffect(() => {
        setTitle('Выберите пол');
    }, []);

    const changeValue = useCallback((value) => {
        setGenderValue(value);
        setValue(value);
        setEditingMode(false);
        setValueChanged(true);
    });

    const genderValue = value === 0 ? 'муж.' : 'жен.';

    const showEditor = editingMode || formMode || filterMode;
    const showInfo = !editingMode && !formMode && !filterMode;

    return (
        <>
            { showInfo && (
                <Info
                    value={genderValue}
                    changed={valueChanged}
                    editIcon={DownOutlined}
                    editable={editable}
                    setEditingMode={setEditingMode}
                />
            )}
            { showEditor && (
                <Editor>
                    <DropdownButton 
                        id="dropdown-basic-button"
                        title={title}
                        size="sm"
                    >
                        <Dropdown.Item onClick={() => {
                            changeValue(0);
                            setTitle('муж.');
                        }}>
                            мужской
                        </Dropdown.Item>
                        <Dropdown.Item onClick={() => {
                            changeValue(1);
                            setTitle('жен.');
                        }}>
                            женский
                        </Dropdown.Item>
                    </DropdownButton>
                </Editor>
            )}
        </>
    );
};

export default Gender;