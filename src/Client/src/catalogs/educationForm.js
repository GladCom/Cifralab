import React from 'react';
import {
    useGetEducationFormQuery,
    useGetEducationFormPagedQuery,
    useGetEducationFormByIdQuery,
    useAddEducationFormMutation,
    useEditEducationFormMutation,
    useRemoveEducationFormMutation,
} from '../services/educationFormApi.js';
import String from '../components/shared/business/String.jsx';

const iconStyle = { marginRight: '5px' };

export const config = {
    detailsLink: 'educationForm',
    hasDetailsPage: false,
    properties: {
        name: { name: 'Форма образования', type: String, show: true, required: true },
    },
    fields: [
        {
            info: 'Форма образования',
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
        addOneAsync: useAddEducationFormMutation,
        removeOneAsync: useRemoveEducationFormMutation,
        editOneAsync: useEditEducationFormMutation,
        getOneByIdAsync: useGetEducationFormByIdQuery,
        getAllAsync: useGetEducationFormQuery,
        getAllPagedAsync: useGetEducationFormPagedQuery, //  TODO: переделать!
    },
};