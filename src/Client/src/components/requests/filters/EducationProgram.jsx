import React from 'react';
import Dropdown from 'react-bootstrap/Dropdown';
import DropdownButton from 'react-bootstrap/DropdownButton';

const EducationProgram = () => {

    return (
        <div className="col">
            <DropdownButton 
                id="dropdown-basic-button"
                size="sm"
                title="Программа"
            >
                <Dropdown.Item href="#/action-1">Action</Dropdown.Item>
                <Dropdown.Item href="#/action-2">Another action</Dropdown.Item>
                <Dropdown.Item href="#/action-3">Something else</Dropdown.Item>
            </DropdownButton>
        </div>
    );
};

export default EducationProgram;