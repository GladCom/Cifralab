import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/scopeOfActivityCrud.js';
import String from '../../components/shared/business/String.jsx';

export default {
    detailsLink: 'scopeOfActivity',
    hasDetailsPage: false,
    serverPaged: false,
    properties: {
        nameOfScope: { name: 'Сфера деятельности', type: String, show: true, required: true },
        level: { name: 'Уровень', type: String, show: true, required: true }
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
};