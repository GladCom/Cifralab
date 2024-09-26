import {
    UserOutlined,
    PhoneOutlined,
    CalendarOutlined,
    MailOutlined,
} from '@ant-design/icons';
import {
    useGetStudentsQuery,
    useGetStudentsPagedQuery,
    useAddStudentMutation,
    useRemoveStudentMutation,
    useGetStudentByIdQuery,
} from '../services/studentsApi.js';
import FullNameFilter from '../components/catalog_provider/filters/FullNameFilter.jsx';

const iconStyle = { marginRight: '5px' };

const studentModel = {
    family: 'string',
    
};

export const config = {
    columns: [
        {
            info: 'ФИО',
            name: 'family',
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
            info: 'пол',
            name: 'gender',
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
        addNewAsync: useAddStudentMutation,
        removeOneAsync: useRemoveStudentMutation,
        getOneByIdAsync: useGetStudentByIdQuery,
        getAllAsync: useGetStudentsQuery,
        getAllPagedAsync: useGetStudentsPagedQuery,
    },
};