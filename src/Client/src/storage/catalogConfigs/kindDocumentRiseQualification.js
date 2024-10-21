import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/kindDocumentRiseQualificationCrud.js';
import String from '../../components/shared/business/String.jsx';

export default {
    detailsLink: 'kindDocumentRiseQualification',
    hasDetailsPage: false,
    serverPaged: false,
    properties: {
        name: { name: 'Вид документа повышения квалификации', type: String, show: true, required: true },
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
            title: 'Вид документа повышения квалификации',
            dataIndex: 'name',
            key: 'name',
        },
    ],
    dataConverter: (data) => data,
};