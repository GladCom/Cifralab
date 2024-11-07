import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/financingTypeCrud.js';
import financingTypeModel from '../models/financingType.js';

export default {
    detailsLink: 'financingType',
    hasDetailsPage: false,
    serverPaged: false,
    properties: financingTypeModel,
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