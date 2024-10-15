import {
    getAllAsync,
    getAllPagedAsync,
    getOneByIdAsync,
    addOneAsync,
    editOneAsync,
    removeOneAsync,
} from '../crud/scopeOfActivityCrud.js';
import String from '../../components/shared/business/String.jsx';

const iconStyle = { marginRight: '5px' };

export default {
    detailsLink: 'scopeOfActivity',
    hasDetailsPage: false,
    serverPaged: false,
    properties: {
        nameOfScope: { name: 'Сфера деятельности', type: String, show: true, required: true },
        level: { name: 'Уровень', type: String, show: true, required: true }
    },
    fields: [
        {
            info: 'Сфера деятельности',
            property: 'nameOfScope',
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
        {
            info: 'Уровень',
            property: 'level',
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
        }
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