import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/feaProgramCrud.js';
import String from '../../components/shared/business/String.jsx';

export default {
    detailsLink: 'feaProgram',
    hasDetailsPage: false,
    properties: {
        name: { name: 'Вэд программа', type: String, show: true, required: true },
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
            title: 'ВЭД программа',
            dataIndex: 'name',
            key: 'name',
        },
    ],
};