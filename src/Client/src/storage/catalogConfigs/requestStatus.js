import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/requestStatusCrud.js';
import String from '../../components/shared/business/String.jsx';

export default {
    detailsLink: 'statusRequest',
    hasDetailsPage: false,
    serverPaged: false,
    properties: {
        name: { name: 'Статус заявки', type: String, show: true, required: true },
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
            title: 'Статус заявки',
            dataIndex: 'name',
            key: 'name',
        },
    ],
};