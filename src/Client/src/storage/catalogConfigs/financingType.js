import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/financingTypeCrud.js';
import String from '../../components/shared/business/String.jsx';

export default {
    detailsLink: 'financingType',
    hasDetailsPage: false,
    serverPaged: false,
    properties: {
        sourceName: { name: 'Тип финансирования', type: String, show: true, required: true },
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
            title: 'Тип финансирования',
            dataIndex: 'sourceName',
            key: 'sourceName',
        },
    ],
    dataConverter: (data) => data,
};