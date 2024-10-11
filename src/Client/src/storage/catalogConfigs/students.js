import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/studentsCrud.js';
import {
    UserOutlined,
    PhoneOutlined,
    CalendarOutlined,
    MailOutlined,
} from '@ant-design/icons';
import { Button, Space } from "antd";
import String from '../../components/shared/business/String.jsx';
import Gender from '../../components/shared/business/Gender.jsx';

const iconStyle = { marginRight: '5px' };

export default {
    detailsLink: 'student',
    hasDetailsPage: true,
    properties: {
        family: { name: 'Фамилия', type: String, show: true, required: true },
        name: { name: 'Имя', type: String, show: true, required: true },
        patron: { name: 'Отчество', type: String, show: true, required: true },
        birthDate: { name: 'Дата рождения', show: true, type: String, required: false },
        sex: { name: 'Пол', type: Gender, show: true, required: true },
        nationality: { name: 'Гражданство', show: true, type: String, required: false },
        snils: { name: 'Снилс', type: String, show: true, required: false },
        address: { name: 'Адрес проживания', show: true, type: String, required: true },
        phone: { name: 'Телефон', type: String, show: true, required: true },
        email: { name: 'E-mail', type: String, show: true, required: true },
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
        useGetAllAsync,
        useGetAllPagedAsync,
        useGetOneByIdAsync,
        useAddOneAsync,
        useEditOneAsync,
        useRemoveOneAsync,
    },
    columns: [
        {
            title: 'Ф.И.О. обучающегося',
            dataIndex: 'fullName',
            key: 'fullName',
        },
        {
            title: 'Дата рождения',
            dataIndex: 'birthDate',
            key: 'birthDate',
        },
        {
            title: 'Место проживания',
            dataIndex: 'address',
            key: 'address',
        },
        {
            title: 'Программа обучения',
            dataIndex: 'groups[0].educationProgramId',
            key: 'educationProgram',
        },
        {
            title: 'Группа',
            dataIndex: 'groups[0].name',
            key: 'nameOfGroup',
        },
        {
            title: 'Год обучения',
            dataIndex: 'groups[0].endDate',
            key: 'yaerOfEducation',
        },
        {
            title: 'Статус заявки',
            dataIndex: 'requests[0].statusRequestId',
            key: 'statusReques',
        },
    ],
};