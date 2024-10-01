import React from 'react';
import {
    useGetKindOrderQuery,
    useGetKindOrderPagedQuery,
    useGetKindOrderByIdQuery,
    useAddKindOrderMutation,
    useEditKindOrderMutation,
    useRemoveKindOrderMutation,
} from '../services/kindOrderApi.js';
import String from '../components/shared/business/String.jsx';

const iconStyle = { marginRight: '5px' };

export const config = {
    detailsLink: 'kindOrder',
    hasDetailsPage: false,
    properties: {
        name: { name: 'Тип приказа', type: String, show: true, required: true },
    },
    fields: [
        {
            info: 'Тип приказа',
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
        addOneAsync: useAddKindOrderMutation,
        removeOneAsync: useRemoveKindOrderMutation,
        editOneAsync: useEditKindOrderMutation,
        getOneByIdAsync: useGetKindOrderByIdQuery,
        getAllAsync: useGetKindOrderQuery,
        getAllPagedAsync: useGetKindOrderPagedQuery, //  TODO: переделать!
    },
};