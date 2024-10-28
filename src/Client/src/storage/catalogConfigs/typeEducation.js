import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/typeEducationCrud.js';
import typeEducationModel from '../models/typeEducation.js';

export default {
    detailsLink: 'typeEducation',
    hasDetailsPage: false,
    serverPaged: false,
    properties: typeEducationModel,
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
    dataConverter: (data) => data,
};