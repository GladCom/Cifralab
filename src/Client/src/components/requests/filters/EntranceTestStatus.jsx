import React from 'react';
import Dropdown from 'react-bootstrap/Dropdown';
import DropdownButton from 'react-bootstrap/DropdownButton';

const EntranceTestStatus = () => {

    return (
        <div className="col">
            <DropdownButton 
                id="dropdown-basic-button"
                size="sm"
                title="Статус вступительного испытания"
            >
                <Dropdown.Item href="#/action-1">Action</Dropdown.Item>
                <Dropdown.Item href="#/action-2">Another action</Dropdown.Item>
                <Dropdown.Item href="#/action-3">Something else</Dropdown.Item>
            </DropdownButton>
        </div>
    );
};

export default EntranceTestStatus;