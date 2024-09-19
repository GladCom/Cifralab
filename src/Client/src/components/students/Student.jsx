import React from 'react';
import { useNavigate } from "react-router-dom";

const Student = ({ student }) => {
    const navigate = useNavigate();

    return (
        <li
            className="row m-1 list-group-item list-group-item-action"
            key={student.id}
            onClick={() => navigate(`/students/${student.id}`)}
            style={{ cursor: 'pointer' }}
        >
            <div className="row">
                <div className="col">{student.fullName}</div>
                <div className="col">{student.birthDate}</div>
                <div className="col">{student.phone}</div>
                <div className="col">{student.email}</div>
            </div>
        </li>
    );
};

export default Student;