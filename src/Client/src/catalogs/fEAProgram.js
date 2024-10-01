import React from 'react';
import {
    useGetFEAProgramQuery,
    useGetFEAProgramPagedQuery,
    useGetFEAProgramByIdQuery,
    useAddFEAProgramMutation,
    useEditFEAProgramMutation,
    useRemoveFEAProgramMutation,
} from '../services/fEAProgramApi.js';
import String from '../components/shared/business/String.jsx';

const iconStyle = { marginRight: '5px' };

export const config = {
    detailsLink: 'fEAProgram',
    hasDetailsPage: false,
    properties: {
        name: { name: 'Вэд программа', type: String, show: true, required: true },
    },
    fields: [
        {
            info: 'Вэд программа',
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
        addOneAsync: useAddFEAProgramMutation,
        removeOneAsync: useRemoveFEAProgramMutation,
        editOneAsync: useEditFEAProgramMutation,
        getOneByIdAsync: useGetFEAProgramByIdQuery,
        getAllAsync: useGetFEAProgramQuery,
        getAllPagedAsync: useGetFEAProgramPagedQuery, //  TODO: переделать!
    },
};