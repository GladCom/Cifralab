import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/typeEducationCrud.js';
import String from '../../components/shared/business/String.jsx';

const iconStyle = { marginRight: '5px' };

export default {
    detailsLink: 'typeEducation',
    hasDetailsPage: false,
    properties: {
        name: { name: 'Тип образования', type: String, show: true, required: true },
    },
    fields: [
        {
            info: 'Тип образования',
            property: 'name',
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