import {
    UserOutlined,
    PhoneOutlined,
    CalendarOutlined,
    MailOutlined,
} from '@ant-design/icons';
import {
    useGetRequestsQuery,
    useGetRequestsPagedQuery,
    useAddRequestMutation,
    useRemoveRequestMutation,
    useGetRequestByIdQuery,
} from '../services/requestsApi.js';
import FullNameFilter from '../components/catalog_provider/filters/FullNameFilter.jsx';

const iconStyle = { marginRight: '5px' };

const requestModel = {
    student: 'string',
    educationProgram: 'string',
    documentRiseQualification: 'string',
    email: 'string',
    phone: 'string'
};

export const config = {
    columns: [
        {
            info: 'Студент',
            name: 'student',
            className: 'col-2',
            style: { },
            icon: {
                type: UserOutlined,
                style: {iconStyle},
            },
            filter: {
                enable: false,
                type: () => {},
            },
        },
        {
            info: 'Программа обучения',
            name: 'educationProgram',
            className: 'col-2',
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
        addNewAsync: useAddRequestMutation,
        removeOneAsync: useRemoveRequestMutation,
        getOneByIdAsync: useGetRequestByIdQuery,
        getAllAsync: useGetRequestsQuery,
        getAllPagedAsync: useGetRequestsPagedQuery,
    },
};