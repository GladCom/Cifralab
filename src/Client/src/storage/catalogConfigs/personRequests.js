import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/personRequestsCrud.js';
import { personRequestsModel } from '../models/index.js';

export default {
    detailsLink: 'requests',
    hasDetailsPage: true,
    serverPaged: true,
    properties: personRequestsModel,
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
            title: 'Ф.И.О. заявителя',
            dataIndex: 'studentFullName',
            key: 'studentFullName',
        },
        {
            title: 'Дата рождения',
            dataIndex: 'birthDate',
            key: 'birthDate',
        },
        {
            title: 'Место проживания',
            dataIndex: 'address',
            key: 'address',
        },
        {
            title: 'Уровень образования',
            dataIndex: 'typeEducation',
            key: 'typeEducation',
        },
        {
            title: 'Программа обучения',
            dataIndex: 'educationProgram',
            key: 'educationProgram',
        },
        {
            title: 'E-mail',
            dataIndex: 'email',
            key: 'email',
        },
        {
            title: 'Статус',
            dataIndex: 'statusRequest',
            key: 'statusRequest',
        },
    ],
    dataConverter: (data) => data,
};