import React, { useState, useMemo } from 'react';
import moment from 'moment';
import Layout from '../shared/Layout';
import FilterPanel from '../shared/filters/FilterPanel.jsx';
import InputFilter from '../shared/filters/InputFilter.jsx';
import DateFilter from '../shared/filters/DateFilter.jsx';
import PhoneFilter from '../shared/filters/PhoneFilter.jsx';
import GenderFilter from '../shared/filters/GenderFilter.jsx';
import StudentsPanel from '../students/StudentsPanel.jsx';
import { useGetStudentsQuery } from '../../services/studentsApi.js';

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
//     const [day, month, year] = birthDate.split('-');
//     const { d, m, y } = date;
//     const parsedBirthDateFromServer = new Date(year, month - 1, day);
//     const parsedBirthDateFromFront = date;
    
// //return true;
//     return parsedBirthDateFromServer.getTime() === date.getTime();
};

const StudentsPage = () => {
    const { data, error, isLoading, refetch } = useGetStudentsQuery();
    const [name, setNameValue] = useState('');
    const [date, setDate] = useState(null);
    const [gender, setGender] = useState(0);
    const [phone, setPhone] = useState('');

    const filteredData = useMemo(() => data?.data.filter((item) => (
        checkName(item, name)
        && checkGender(item, gender)
        //&&checkPhone(item, phone)
        && checkDate(item, date)
    )),[data, name, gender, date]);

    return (
        <Layout title="Студенты" isLoading={isLoading}>
            <FilterPanel>
                <InputFilter placeholder="Ф.И.О. студента" onChange={setNameValue} />
                <GenderFilter placeholder="пол" onChange={setGender} />
                <DateFilter placeholder="дата рождения" onChange={setDate} />
                <PhoneFilter placeholder="телефон" />
            </FilterPanel>
            <StudentsPanel students={filteredData} />
        </Layout>
    );
};

export default StudentsPage;