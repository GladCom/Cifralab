import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/financingTypeCrud.js';
import String from '../../components/shared/business/String.jsx';

const iconStyle = { marginRight: '5px' };

export default {
    detailsLink: 'financingType',
    hasDetailsPage: false,
    properties: {
        sourceName: { name: 'Тип финансирования', type: String, show: true, required: true },
    },
    fields: [
        {
            info: 'Тип финансирования',
            property: 'sourceName',
            component: String,
            className: 'col',
            style: { },
            icon: {
                type: () => {},
                style: {iconStyle},
            },
            filter: {
                enable: false,
                type: () => {},
            },
        },
    ],
    crud: {
        useGetAllAsync,
        useGetAllPagedAsync,
        useGetOneByIdAsync,
        useAddOneAsync,
        useEditOneAsync,
        useRemoveOneAsync,
    }
};