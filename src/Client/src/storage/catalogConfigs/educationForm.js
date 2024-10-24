import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/educationFormCrud.js';
import String from '../../components/shared/business/String.jsx';

const rules = [
    {
        required: true,
        message: 'Необходимо заполнить это поле',
    },
];

const formParams = {
    key: 'name',
    name: 'Форма образования',
    rules,
};

export default {
    detailsLink: 'educationForm',
    hasDetailsPage: false,
    serverPaged: false,
    properties: {
        name: { name: 'Форма образования', type: String, show: true, formParams },
    },
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