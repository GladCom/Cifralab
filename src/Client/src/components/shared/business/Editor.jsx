import React, { useState, useCallback } from 'react';
import Row from 'react-bootstrap/Row';

const Editor = ({ visible, setValue, children }) => {

    return visible && (
        <Row className="d-flex align-items-center m-3">
            {children}
        </Row>
    );
};

export default Editor;