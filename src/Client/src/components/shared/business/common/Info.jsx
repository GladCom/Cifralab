import React from 'react';
import Stack from 'react-bootstrap/Stack';

const Info = ({ value }) => {

    return (
        <>
            <Stack direction="horizontal" className="m-3">
                <div className="me-1">
                    { value }
                </div>
            </Stack>
        </>
    );
};

export default Info;