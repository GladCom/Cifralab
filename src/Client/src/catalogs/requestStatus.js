
import {
    useGetRequestStatusQuery,
    useGetRequestStatusPagedQuery,
    useGetRequestStatusByIdQuery,
    useAddRequestStatusMutation,
    useEditRequestStatusMutation,
    useRemoveRequestStatusMutation,
} from '../services/requestStatusApi.js';
import String from '../components/shared/business/String.jsx';

const iconStyle = { marginRight: '5px' };

export const config = {
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
    catalogData: {
        addOneAsync: useAddRequestStatusMutation,
        removeOneAsync: useRemoveRequestStatusMutation,
        editOneAsync: useEditRequestStatusMutation,
        getOneByIdAsync: useGetRequestStatusByIdQuery,
        getAllAsync: useGetRequestStatusQuery,
        getAllPagedAsync: useGetRequestStatusPagedQuery, //  TODO: переделать!
    },
};