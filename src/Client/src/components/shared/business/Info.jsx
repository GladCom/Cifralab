import React, { useState, useCallback } from 'react';
import Row from 'react-bootstrap/Row';

const Info = ({ visible, children }) => {

    return visible && (
        <Row className="m-3">
            { children }
        </Row>
    );
};

export default Info;