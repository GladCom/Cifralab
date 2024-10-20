import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/studentsCrud.js';
import String from '../../components/shared/business/String.jsx';
import Gender from '../../components/shared/business/Gender.jsx';
import Snils from '../../components/shared/business/validation/Snils.jsx';
import Email from '../../components/shared/business/validation/Email.jsx';

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