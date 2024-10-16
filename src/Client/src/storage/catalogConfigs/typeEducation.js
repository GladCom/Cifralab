import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/typeEducationCrud.js';
import String from '../../components/shared/business/String.jsx';

export default {
    detailsLink: 'typeEducation',
    hasDetailsPage: false,
    serverPaged: false,
    properties: {
        name: { name: 'Тип образования', type: String, show: true, required: true },
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
            title: 'Тип образования',
            dataIndex: 'name',
            key: 'name',
        },
    ],
};