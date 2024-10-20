import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/kindOrderCrud.js';
import String from '../../components/shared/business/String.jsx';

export default {
    detailsLink: 'kindOrder',
    hasDetailsPage: false,
    serverPaged: false,
    properties: {
        name: { name: 'Тип приказа', type: String, show: true, required: true },
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
            title: 'Тип приказа',
            dataIndex: 'name',
            key: 'name',
        },
    ],
};