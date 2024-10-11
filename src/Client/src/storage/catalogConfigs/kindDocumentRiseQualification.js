import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/kindDocumentRiseQualificationCrud.js';
import String from '../../components/shared/business/String.jsx';

const iconStyle = { marginRight: '5px' };

export default {
    detailsLink: 'kindDocumentRiseQualification',
    hasDetailsPage: false,
    properties: {
        name: { name: 'Вид документа повышения квалификации', type: String, show: true, required: true },
    },
    fields: [
        {
            info: 'Вид документа повышения квалификации',
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