import React, { useState, useCallback } from 'react';
import BusinessComponent from './BusinessComponent.jsx';
import Info from './Info.jsx';
import Editor from './Editor.jsx';
import { EditOutlined, CheckOutlined } from '@ant-design/icons';
import Button from 'react-bootstrap/Button';
import cn from 'classnames';
import { Input } from 'antd';
import Col from 'react-bootstrap/Col';

const String = ({ initValue, setStringValue, editable }) => {
    const [editingMode, setEditingMode] = useState(false);
    const [value, setValue] = useState(initValue);
    const [valueChanged, setValueChanged] = useState(false);
    const classes = cn('auto d-flex justify-content-start', { 'text-success': valueChanged });

    return (
        <BusinessComponent>
            <></>
            <Info visible={!editingMode}>
                <Col md="auto" className={classes}>
                    {value}
                </Col>
                <Col>
                    <EditOutlined type="button" onClick={() => setEditingMode(true)}/>
                </Col>
            </Info>
            {
                editable && (
                    <Editor visible={editingMode}>
                        <Col md="auto">
                            <Input value={value} onChange={({ target }) => setValue(target.value)}/>
                        </Col>
                        <Col md="auto">
                            <Button className="m-1" variant="outline-success" size="sm" onClick={() => {
                                setEditingMode(false);
                                setStringValue(value);
        
                                if (initValue !== value) {
                                    setValueChanged(true);
                                }
                            }}>
                                <CheckOutlined />
                                Save
                            </Button>
                        </Col>
                        <Col>
                            <Button className="m-1" variant="outline-danger" size="sm" onClick={() => {
                                setEditingMode(false);
                                setStringValue(initValue);
                            }}>
                                Cancel
                            </Button>
                        </Col>
                    </Editor>
                )
            }
        </BusinessComponent>

    );
};

export default String;