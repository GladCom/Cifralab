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
} from '../services/requestsApi.js';
import FullNameFilter from '../components/catalog_provider/filters/FullNameFilter.jsx';

const iconStyle = { marginRight: '5px' };

const requestModel = {
    id: 'string',
    studentId: 'string',
    studentFullName: 'string',
    birthDate: 'string',
    address: 'string',
    typeEducation: 'string',
    typeEducationId: 'string',
    email: 'string',
    educationProgramId: 'string',
    educationProgram: 'string',
    statusRequest: 'string',
    statusRequestId: 'string'
};

export const config = {
    columns: [
        {
            info: 'Студент',
            name: 'studentFullName',
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
            info: 'Дата рождения',
            name: 'birthDate',
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
            info: 'Место проживания',
            name: 'address',
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
            info: 'Уровень образования',
            name: 'typeEducation',
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
            info: 'Программа обучения',
            name: 'educationProgram',
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
            info: 'Статус',
            name: 'statusRequest',
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