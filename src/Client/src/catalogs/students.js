import {
    UserOutlined,
    PhoneOutlined,
    CalendarOutlined,
    MailOutlined,
} from '@ant-design/icons';
import { useGetStudentsQuery } from '../services/studentsApi.js';
import { useGetStudentsPagedQuery, useAddStudentMutation } from '../services/studentsApi.js';
import FullNameFilter from '../components/catalog_provider/filters/FullNameFilter.jsx';

const iconStyle = { marginRight: '5px' };

export const config = {
    columns: [
        {
            info: 'ФИО',
            name: 'fullName',
            className: 'col-2',
            style: { },
            icon: {
                type: UserOutlined,
                style: {iconStyle},
            },
            filter: {
                enable: true,
                type: FullNameFilter,
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
        getAllAsync: useGetStudentsQuery,
        getAllPagedAsync: useGetStudentsPagedQuery,
        addStudent: useAddStudentMutation,
    },
};