import React, { useState, useEffect, useCallback } from 'react';
import Dropdown from 'react-bootstrap/Dropdown';
import DropdownButton from 'react-bootstrap/DropdownButton';
import Info from './Info.jsx';
import Editor from './Editor.jsx';
import { DownOutlined } from '@ant-design/icons';

const Disability = ({ initValue, setValue, editable, formMode, filterMode }) => {
    const [editingMode, setEditingMode] = useState(formMode || filterMode);
    const [value, setDisabilityValue] = useState(initValue);
    const [valueChanged, setValueChanged] = useState(false);
    const [title, setTitle] = useState('ОВЗ');

    useEffect(() => {
        setDisabilityValue(initValue);
    }, [initValue]);

    useEffect(() => {
        setTitle('ОВЗ');
    }, []);

    const changeValue = useCallback((value) => {
        setDisabilityValue(value);
        setValue(value);
        setEditingMode(false);
        setValueChanged(true);
    });

    const genderValue = value ? 'да' : 'нет';

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
                            changeValue(false);
                            setTitle('нет');
                        }}>
                            нет
                        </Dropdown.Item>
                        <Dropdown.Item onClick={() => {
                            changeValue(true);
                            setTitle('да');
                        }}>
                            да
                        </Dropdown.Item>
                    </DropdownButton>
                </Editor>
            )}
        </>
    );
};

export default Disability;