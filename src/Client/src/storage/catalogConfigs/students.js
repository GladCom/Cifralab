import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/studentsCrud.js';
import { studentsModel } from '../models/index.js';

export default {
    detailsLink: 'student',
    hasDetailsPage: true,
    serverPaged: true,
    properties: studentsModel,
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
            title: 'Ф.И.О. обучающегося',
            dataIndex: 'fullName',
            key: 'fullName',
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
            title: 'Программа обучения',
            dataIndex: 'groups[0].educationProgramId',
            key: 'educationProgram',
        },
        {
            title: 'Группа',
            dataIndex: 'groups[0].name',
            key: 'nameOfGroup',
        },
        {
            title: 'Год обучения',
            dataIndex: 'groups[0].endDate',
            key: 'yaerOfEducation',
        },
        {
            title: 'Статус заявки',
            dataIndex: 'requests[0].statusRequestId',
            key: 'statusReques',
        },
    ],
    dataConverter: (data) => data,
};