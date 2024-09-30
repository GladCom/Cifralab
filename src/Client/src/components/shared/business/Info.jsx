import React, { useState, useCallback } from 'react';
import Stack from 'react-bootstrap/Stack';

const ChangeSymbol = () => (<span className="">* </span>);

const Info = ({ changed, editIcon, value, setEditingMode, editable }) => {
    const EditIcon = editIcon;

    return (
        <Stack direction="horizontal" className="m-3">
            <div className="me-1">
                {changed && (<ChangeSymbol />)}
                { value }
            </div>
            { editable && (
                <div type="button" onClick={() => setEditingMode(true)}>
                    <EditIcon />
                </div>
            )}
        </Stack>
    );
};

export default Info;