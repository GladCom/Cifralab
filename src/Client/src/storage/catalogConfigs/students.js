import {
    getAllAsync,
    getAllPagedAsync,
    getOneByIdAsync,
    addOneAsync,
    editOneAsync,
    removeOneAsync,
} from '../crud/studentsCrud.js';
import {
    UserOutlined,
    PhoneOutlined,
    CalendarOutlined,
    MailOutlined,
} from '@ant-design/icons';
import String from '../../components/shared/business/String.jsx';
import Gender from '../../components/shared/business/Gender.jsx';
import Snils from '../../components/shared/business/validation/Snils.jsx';
import Email from '../../components/shared/business/validation/Email.jsx';

const iconStyle = { marginRight: '5px' };

export default {
    detailsLink: 'student',
    hasDetailsPage: true,
    serverPaged: true,
    properties: {
        family: { name: 'Фамилия', type: String, show: true, required: true },
        name: { name: 'Имя', type: String, show: true, required: true },
        patron: { name: 'Отчество', type: String, show: true, required: true },
        birthDate: { name: 'Дата рождения', show: true, type: String, required: true },
        sex: { name: 'Пол', type: Gender, show: true, required: true },
        nationality: { name: 'Гражданство', show: true, type: String, required: true },
        snils: { name: 'Снилс', type: Snils, show: true, required: false },
        address: { name: 'Адрес проживания', show: true, type: String, required: true },
        phone: { name: 'Телефон', type: String, show: true, required: true },
        email: { name: 'E-mail', type: Email, show: true, required: true },
        projects: { name: 'Проекты', type: String, show: true, required: false },
        iT_Experience: { name: 'Опыт в IT', type: String, show: true, required: true },
    },
    fields: [
        {
            info: 'ФИО',
            property: 'fullName',
            component: String,
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
            info: 'Пол',
            property: 'sex',
            component: Gender,
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
        {
            info: 'Адресс',
            property: 'address',
            component: String,
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
    crud: {
        getAllAsync,
        getAllPagedAsync,
        getOneByIdAsync,
        addOneAsync,
        editOneAsync,
        removeOneAsync,
    }
};