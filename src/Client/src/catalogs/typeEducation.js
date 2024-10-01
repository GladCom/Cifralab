import {
    useGetTypeEducationQuery,
    useGetTypeEducationPagedQuery,
    useGetTypeEducationByIdQuery,
    useAddTypeEducationMutation,
    useEditTypeEducationMutation,
    useRemoveTypeEducationMutation,
} from '../services/typeEducationApi.js';
import String from '../components/shared/business/String.jsx';

const iconStyle = { marginRight: '5px' };

export const config = {
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
    catalogData: {
        addOneAsync: useAddTypeEducationMutation,
        removeOneAsync: useRemoveTypeEducationMutation,
        editOneAsync: useEditTypeEducationMutation,
        getOneByIdAsync: useGetTypeEducationByIdQuery,
        getAllAsync: useGetTypeEducationQuery,
        getAllPagedAsync: useGetTypeEducationPagedQuery, //  TODO: переделать!
    },
};