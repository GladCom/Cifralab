import {
    getAllAsync,
    getAllPagedAsync,
    getOneByIdAsync,
    addOneAsync,
    editOneAsync,
    removeOneAsync,
} from '../crud/educationFormCrud.js';
import String from '../../components/shared/business/String.jsx';

const iconStyle = { marginRight: '5px' };

export default {
    detailsLink: 'educationForm',
    hasDetailsPage: false,
    serverPaged: false,
    properties: {
        name: { name: 'Форма образования', type: String, show: true, required: true },
    },
    fields: [
        {
            info: 'Форма образования',
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
        getAllAsync,
        getAllPagedAsync,
        getOneByIdAsync,
        addOneAsync,
        editOneAsync,
        removeOneAsync,
    }
};