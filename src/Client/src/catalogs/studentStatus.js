import React from 'react';
import {
    useGetStudentStatusQuery,
    useGetStudentStatusPagedQuery,
    useGetStudentStatusByIdQuery,
    useAddStudentStatusMutation,
    useEditStudentStatusMutation,
    useRemoveStudentStatusMutation,
} from '../services/studentStatusApi.js';
import String from '../components/shared/business/String.jsx';

const iconStyle = { marginRight: '5px' };

export const config = {
    detailsLink: 'studentStatus',
    hasDetailsPage: false,
    properties: {
        name: { name: 'Статус студента', type: String, show: true, required: true },
    },
    fields: [
        {
            info: 'Статус студента',
            property: 'name',
            component: String,
            className: 'col',
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
        addOneAsync: useAddStudentStatusMutation,
        removeOneAsync: useRemoveStudentStatusMutation,
        editOneAsync: useEditStudentStatusMutation,
        getOneByIdAsync: useGetStudentStatusByIdQuery,
        getAllAsync: useGetStudentStatusQuery,
        getAllPagedAsync: useGetStudentStatusPagedQuery, //  TODO: переделать!
    },
};