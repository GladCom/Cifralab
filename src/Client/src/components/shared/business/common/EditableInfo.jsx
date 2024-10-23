import React from 'react';
import { EditOutlined } from '@ant-design/icons';
import Stack from 'react-bootstrap/Stack';

const ChangeSymbol = () => (<span className="">* </span>);

const EditableInfo = ({ value, changed, setMode }) => {

    return (
        <>
            <Stack direction="horizontal" className="m-3">
                <div className="me-1">
                    {changed && (<ChangeSymbol />)}
                    { value }
                </div>
                <div type="button" onClick={() => setMode('edit')}>
                    <EditOutlined />
                </div>
            </Stack>
        </>
    );
};

export default EditableInfo;