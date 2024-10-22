import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/educationFormCrud.js';
import String from '../../components/shared/business/String.jsx';

export default {
    detailsLink: 'educationForm',
    hasDetailsPage: false,
    serverPaged: false,
    properties: {
        name: { name: 'Форма образования', type: String, show: true, required: true },
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
};