import {
    UserOutlined,
    PhoneOutlined,
    CalendarOutlined,
    MailOutlined,
} from '@ant-design/icons';
import {
    useGetPersonRequestsQuery,
    useGetPersonRequestsPagedQuery,
    useAddPersonRequestMutation,
    useRemovePersonRequestMutation,
    useGetPersonRequestByIdQuery,
} from '../services/requestsAPI.js';
import FullNameFilter from '../components/catalog_provider/filters/FullNameFilter.jsx';

const iconStyle = { marginRight: '5px' };

const requestModel = {
    studentfamily: 'string',
    email: 'string',
    phone: 'string'
};

export const config = {
    columns: [
        {
            info: 'Студент',
            name: 'studentfamily',
            className: 'col-2',
            style: { },
            icon: {
                type: UserOutlined,
                style: {iconStyle},
            },
            filter: {
                enable: false,
                type: () => {},
            }
        },
        {
            info: 'Почта',
            name: 'email',
            className: 'col-2',
            style: { },
            icon: {
                type: UserOutlined,
                style: {iconStyle},
            },
            filter: {
                enable: false,
                type: () => {},
            }
        },
        {
            info: 'Телефон',
            name: 'phone',
            className: 'col-2',
            style: { },
            icon: {
                type: UserOutlined,
                style: {iconStyle},
            },
            filter: {
                enable: false,
                type: () => {},
            }
        }
    ],
    catalogData: {
        addNewAsync: useAddPersonRequestMutation,
        removeOneAsync: useRemovePersonRequestMutation,
        getOneByIdAsync: useGetPersonRequestByIdQuery,
        getAllAsync: useGetPersonRequestsQuery,
        getAllPagedAsync: useGetPersonRequestsPagedQuery,
    },
};