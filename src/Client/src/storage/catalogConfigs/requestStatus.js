import {
    getAllAsync,
    getAllPagedAsync,
    getOneByIdAsync,
    addOneAsync,
    editOneAsync,
    removeOneAsync,
} from '../crud/requestStatusCrud.js';
import String from '../../components/shared/business/String.jsx';

const iconStyle = { marginRight: '5px' };

export default {
    detailsLink: 'statusRequest',
    hasDetailsPage: false,
    properties: {
        name: { name: 'Статус заявки', type: String, show: true, required: true },
    },
    fields: [
        {
            info: 'Статус заявки',
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