import React, { useState, useCallback } from 'react';
import Stack from 'react-bootstrap/Stack';

const Editor = ({ children }) => {

    return (
        <Stack direction="horizontal" className="m-3">
            {React.Children.map(children, (child, i) => (
                <div key={i}>{child}</div>
            ))}
        </Stack>
    );
};

export default Editor;