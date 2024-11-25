import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/kindEducationProgramCrud.js';
import kindEducationProgramModel from '../models/kindEducationProgram.js';

export default {
    detailsLink: 'kindEducationProgram',
    hasDetailsPage: false,
    serverPaged: false,
    properties: kindEducationProgramModel,
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
            title: 'Вид программы',
            dataIndex: 'name',
            key: 'name',
        },
    ],
    dataConverter: (data) => data,
};