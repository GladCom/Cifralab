import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/requestStatusCrud.js';
import { requestStatusModel } from '../models/index.js';

export default {
    detailsLink: 'statusRequest',
    hasDetailsPage: false,
    serverPaged: false,
    properties: requestStatusModel,
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
    dataConverter: (data) => data,
};