import React from 'react';
import {
    useGetKindDocumentRiseQualificationQuery,
    useGetKindDocumentRiseQualificationPagedQuery,
    useGetKindDocumentRiseQualificationByIdQuery,
    useAddKindDocumentRiseQualificationMutation,
    useEditKindDocumentRiseQualificationMutation,
    useRemoveKindDocumentRiseQualificationMutation,
} from '../services/kindDocumentRiseQualificationApi.js';
import String from '../components/shared/business/String.jsx';

const iconStyle = { marginRight: '5px' };

export const config = {
    detailsLink: 'kindDocumentRiseQualification',
    hasDetailsPage: false,
    properties: {
        name: { name: 'Вид документа повышения квалификации', type: String, show: true, required: true },
    },
    fields: [
        {
            info: 'Вид документа повышения квалификации',
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
        addOneAsync: useAddKindDocumentRiseQualificationMutation,
        removeOneAsync: useRemoveKindDocumentRiseQualificationMutation,
        editOneAsync: useEditKindDocumentRiseQualificationMutation,
        getOneByIdAsync: useGetKindDocumentRiseQualificationByIdQuery,
        getAllAsync: useGetKindDocumentRiseQualificationQuery,
        getAllPagedAsync: useGetKindDocumentRiseQualificationPagedQuery, //  TODO: переделать!
    },
};