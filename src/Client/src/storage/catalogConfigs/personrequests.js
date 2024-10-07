import React from 'react';
import {
    UserOutlined,
    PhoneOutlined,
    CalendarOutlined,
    MailOutlined,
} from '@ant-design/icons';
import {    
    useGetPersonRequestsQuery,
    useGetPersonRequestsPagedQuery,
    useAddPersonRequestMutation,
    useRemovePersonRequestMutation,
    useGetPersonRequestByIdQuery,
} from '../services/requestsAPI.js';

import String from '../../components/shared/business/String.jsx';
import Gender from '../../components/shared/business/Gender.jsx';

const iconStyle = { marginRight: '5px' };

export const config = {
    detailsLink: 'request',
    hasDetailsPage: true,
    properties: {
        family: { name: 'Фамилия', type: String, show: true, required: true },
        name: { name: 'Имя', type: String, show: true, required: true },
        patron: { name: 'Отчество', type: String, show: true, required: true },
        birthDate: { name: 'Дата рождения', show: true, type: String, required: false },
        sex: { name: 'Пол', type: Gender, show: true, required: true },
        nationality: { name: 'Гражданство', show: true, type: String, required: false },
        snils: { name: 'Снилс', type: String, show: true, required: false },
        address: { name: 'Адрес проживания', show: true, type: String, required: true },
        phone: { name: 'Телефон', type: String, show: true, required: true },
        email: { name: 'E-mail', type: String, show: true, required: true },
        projects: { name: 'Проекты', type: String, show: true, required: false },
        iT_Experience: { name: 'Опыт в IT', type: String, show: true, required: true },
    },
    fields: [
        {
            info: 'Ф.И.О. заявителя',
            property: 'studentFullName',
            component: String,
            className: 'col-2',
            style: { },
            icon: {
                type: UserOutlined,
                style: {iconStyle},
            },
            filter: {
                enable: false,
                type: () => {},
            },
        },
        {
            info: 'Дата рождения',
            property: 'birthDate',
            component: String,
            className: 'col-2',
            style: { },
            icon: {
                type: () => {},
                style: {iconStyle},
            },
            filter: {
                enable: false,
                type: () => {},
            },
        },
        {
            info: 'Место проживания',
            property: 'address',
            component: String,
            className: 'col-2',
            style: { },
            icon: {
                type: () => {},
                style: {iconStyle},
            },
            filter: {
                enable: false,
                type: () => {},
            },
        },
        {
            info: 'Уровень образования',
            property: 'typeEducation',
            component: String,
            className: 'col-2',
            style: { },
            icon: {
                type: () => {},
                style: {iconStyle},
            },
            filter: {
                enable: false,
                type: () => {},
            },
        },
        {
            info: 'Программа обучения',
            property: 'educationProgram',
            component: String,
            className: 'col-2',
            style: { },
            icon: {
                type: () => {},
                style: {iconStyle},
            },
            filter: {
                enable: false,
                type: () => {},
            },
        },
        {
            info: 'e-mail',
            property: 'email',
            component: String,
            className: 'col-2',
            style: { },
            icon: {
                type: () => {},
                style: {iconStyle},
            },
            filter: {
                enable: false,
                type: () => {},
            },
        },
        {
            info: 'Статус',
            property: 'statusRequest',
            component: String,
            className: 'col-2',
            style: { },
            icon: {
                type: () => {},
                style: {iconStyle},
            },
            filter: {
                enable: false,
                type: () => {},
            },
        },
    ],

    catalogData: {
        addNewAsync: useAddPersonRequestMutation,
        removeOneAsync: useRemovePersonRequestMutation,
        getOneByIdAsync: useGetPersonRequestByIdQuery,
        getAllAsync: useGetPersonRequestsQuery,
        getAllPagedAsync: useGetPersonRequestsPagedQuery,
    },
};