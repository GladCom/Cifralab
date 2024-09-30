import React, { useState, useCallback } from 'react';
import Row from 'react-bootstrap/Row';

const BusinessComponent = ({ children }) => {

    return (
        <Row className="auto d-flex justify-content-start">
            {children}
        </Row>
    );
};

export default BusinessComponent;