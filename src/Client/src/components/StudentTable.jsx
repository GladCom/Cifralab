import React, { useEffect, useState } from 'react'
import DataTable from '../common/DataTable';
import { json } from 'react-router-dom';

const columns = [
    { field: 'id', headerName: 'User ID', width: 150 },
    { field: 'fullName', headerName: 'Name', width: 150 },
    { field: 'birthDate', headerName: 'Username', width: 150 },
];

const userTableStyles = {
    height: '650px',
};

const StudentTable = ({ onError }) => {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        fetch('http://localhost:5137/Student/paged?page=0&size=20')
            .then((response) => response.json())
            .then((json) => setUsers(json.data))
            .catch(() => console.log({users}))

    }, []);

    return (
        <DataTable
            rows={users}
            columns={columns}
            loading={!users.length}
            sx={userTableStyles}
        >
            <iframe src="https://chromedino.com/" frameborder="0" scrolling="no" width="100%" height="100%" loading="lazy" style="position: absolute; width: 100%; height: 100%; z-index: 999;"></iframe>
        </DataTable>
    );
};

export default StudentTable;