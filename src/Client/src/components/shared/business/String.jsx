import React, { useState, useEffect, useRef } from 'react';
import Info from './Info.jsx';
import Editor from './Editor.jsx';
import { EditOutlined, CheckOutlined } from '@ant-design/icons';
import Button from 'react-bootstrap/Button';
import { Input } from 'antd';

const String = ({ initValue, setValue, editable, required, formMode, filterMode }) => {
    const [editingMode, setEditingMode] = useState(false);
    const [value, setStringValue] = useState(initValue);
    const [valueChanged, setValueChanged] = useState(false);

    useEffect(() => {
        setStringValue(initValue);
    }, [initValue]);

    const showEditor = editingMode || formMode || filterMode;
    const showInfo = !editingMode && !formMode && !filterMode;

    return (
        <>
            { showInfo && (
                <Info 
                    value={value}
                    changed={valueChanged}
                    editIcon={EditOutlined}
                    editable={editable}
                    setEditingMode={setEditingMode}
                />
            )}
            { showEditor && (
                <Editor>
                    <Input 
                        value={value}
                        required={required}
                        onChange={({ target }) => {
                            setStringValue(target.value)

                            if(formMode || filterMode) {
                                setValue(target.value);
                            }
                        }} 
                        onPressEnter={() => {
                            setEditingMode(false);
                            setValue(value);
                            setValueChanged(initValue !== value);
                        }} 
                    />
                    { !formMode && !filterMode  && (
                        <>
                            <Button className="m-1" variant="outline-success" size="sm" onClick={() => {
                                setEditingMode(false);
                                setValue(value);

                                if (initValue !== value) {
                                    setValueChanged(true);
                                }
                            }}>
                                <CheckOutlined />
                                Save
                            </Button>
                            <Button className="m-1" variant="outline-danger" size="sm" onClick={() => {
                                setEditingMode(false);
                                setStringValue(initValue);
                                setValue(initValue);
                            }}>
                                Cancel
                            </Button>
                        </>
                    )}
                </Editor>
            )}
        </>

    );
};

export default String;