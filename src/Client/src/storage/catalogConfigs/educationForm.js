import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/educationFormCrud.js';
import { educationFormModel } from '../models/index.js';

export default {
    detailsLink: 'educationForm',
    hasDetailsPage: false,
    serverPaged: false,
    properties: educationFormModel,
    crud: {
        useGetAllAsync,
        useGetAllPagedAsync,
        useGetOneByIdAsync,
        useAddOneAsync,
        useEditOneAsync,
        useRemoveOneAsync,
    },
    columns: [
        {
            title: 'Форма образования',
            dataIndex: 'name',
            key: 'name',
        },
    ],
    dataConverter: (data) => data,
};