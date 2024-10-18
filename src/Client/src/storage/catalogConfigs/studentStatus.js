import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/studentStatusCrud.js';
import String from '../../components/shared/business/String.jsx';

export default {
    detailsLink: 'studentStatus',
    hasDetailsPage: false,
    serverPaged: false,
    properties: {
        name: { name: 'Статус студента', type: String, show: true, required: true },
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
            title: 'Статус студента',
            dataIndex: 'name',
            key: 'name',
        },
    ],
};