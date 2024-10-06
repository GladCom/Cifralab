import React from 'react';
import {
    useGetFinancingTypeQuery,
    useGetFinancingTypePagedQuery,
    useGetFinancingTypeByIdQuery,
    useAddFinancingTypeMutation,
    useEditFinancingTypeMutation,
    useRemoveFinancingTypeMutation,
} from '../services/financingTypeApi.js';
import String from '../components/shared/business/String.jsx';

const iconStyle = { marginRight: '5px' };

export const config = {
    detailsLink: 'financingType',
    hasDetailsPage: false,
    properties: {
        sourceName: { name: 'Тип финансирования', type: String, show: true, required: true },
    },
    fields: [
        {
            info: 'Тип финансирования',
            property: 'sourceName',
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
        addOneAsync: useAddFinancingTypeMutation,
        removeOneAsync: useRemoveFinancingTypeMutation,
        editOneAsync: useEditFinancingTypeMutation,
        getOneByIdAsync: useGetFinancingTypeByIdQuery,
        getAllAsync: useGetFinancingTypeQuery,
        getAllPagedAsync: useGetFinancingTypePagedQuery, //  TODO: переделать!
    },
};