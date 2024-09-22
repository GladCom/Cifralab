import React, { useState, useMemo } from 'react';
import moment from 'moment';
import Layout from '../shared/Layout';
import Catalog from '../catalog_provider/Catalog.jsx';
import { config } from '../../catalogs/students.js'

const checkName = ({ fullName }, key) => (
    fullName.toLowerCase().includes(key.toLowerCase())
);

const checkGender = ({ gender }, key) => {
    const select = {
        1: () => gender === "male",
        2: () => gender === "female",
        0: () => true,
    };
    return select[key]();
};

const checkPhone = ({ phone }, key) => {
    
};

const checkDate = ({ birthDate }, date) => {
    if (date === null)
        return true;

    const parsedDate = moment(birthDate, "DD-MM-YYYY");
    return date.isSame(parsedDate, 'day');
};

const StudentsPage = () => {
    // const [name, setNameValue] = useState('');
    // const [date, setDate] = useState(null);
    // const [gender, setGender] = useState(0);
    // const [phone, setPhone] = useState('');

    // const filteredData = useMemo(() => data?.data.filter((item) => (
    //     checkName(item, name)
    //     && checkGender(item, gender)
    //     //&&checkPhone(item, phone)
    //     && checkDate(item, date)
    // )),[data, name, gender, date]);


    return (
        <Layout title="Студенты">
            <Catalog config={config} />
        </Layout>
    );
};

export default StudentsPage;