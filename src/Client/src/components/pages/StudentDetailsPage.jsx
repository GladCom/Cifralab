import React, { useState, useEffect } from 'react';
import Layout from '../shared/Layout';
import { useParams } from 'react-router-dom';
import { useGetStudentByIdQuery } from '../../services/studentsApi.js';

const StudentDetailsPage = () => {
    const { id } = useParams();
    const [student, setStudent] = useState();
    const { data, error, isLoading, refetch } = useGetStudentByIdQuery(id);
    
    useEffect(() => {
        if (!isLoading) {
            setStudent(data.data[0]);
        }
    }, [isLoading]);

    return (
        <Layout title="Персональные данные студента" isLoading={isLoading}>
            <span>{student?.fullName}</span>
            <br />
            <span>{student?.birthDate}</span>
            <br />
            <span>{student?.gender}</span>
            <br />
            <span>{student?.snils}</span>
            <br />
            <span>{student?.phone}</span>
            <br />
            <span>{student?.address}</span>
            <br />
            <span>{student?.email}</span>
        </Layout>
    );
};

export default StudentDetailsPage;