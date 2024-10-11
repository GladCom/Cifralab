import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/groupsCrud.js';
import String from '../../components/shared/business/String.jsx';
import EducationProgramSelect from '../../components/shared/business/selects/EducationProgramSelect.jsx'

const iconStyle = { marginRight: '5px' };

export default {
    detailsLink: 'group',
    hasDetailsPage: true,
    properties: {
        name: { name: 'Наименование группы', type: String, show: true, required: true },
        educationProgramId: { name: 'Программа обучения', type: EducationProgramSelect, show: true, required: true },
        startDate: { name: 'Дата начала', type: String, show: true, required: true },
        endDate: { name: 'Дата окончания', type: String, show: true, required: true },
    },
    fields: [
        {
            info: 'Группа',
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
        {
            info: 'Программа обучения',
            property: 'educationProgramId',
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
            info: 'Дата начала',
            property: 'startDate',
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
            info: 'Дата окончания',
            property: 'endDate',
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