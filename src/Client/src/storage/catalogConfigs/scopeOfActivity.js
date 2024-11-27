import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/scopeOfActivityCrud.js';
import scopeOfActivityModel from '../models/scopeOfActivity.js';

const iconStyle = { marginRight: '5px' };

export default {
    detailsLink: 'scopeOfActivity',
    hasDetailsPage: false,
    serverPaged: false,
    properties: scopeOfActivityModel,
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
            title: 'Сфера деятельности',
            dataIndex: 'nameOfScope',
            key: 'nameOfScope',
        },
        {
            title: 'Уровень',
            dataIndex: 'level',
            key: 'level',
        },
    ],
    dataConverter: (data) => data,
};