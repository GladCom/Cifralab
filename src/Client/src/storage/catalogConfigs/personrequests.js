import {
    getAllAsync,
    getAllPagedAsync,
    getOneByIdAsync,
    addOneAsync,
    editOneAsync,
    removeOneAsync,
} from '../crud/personrequestsCrud.js';
import {
    UserOutlined,
    PhoneOutlined,
    CalendarOutlined,
    MailOutlined,
} from '@ant-design/icons';

import String from '../../components/shared/business/String.jsx';
import RequestStatusSelect from '../../components/shared/business/selects/RequestStatusSelect.jsx';
import EducationProgramSelect from '../../components/shared/business/selects/EducationProgramSelect.jsx';
import EducationTypeSelect from '../../components/shared/business/selects/EducationTypeSelect.jsx';
import StatusEntranceExamsSelect from '../../components/shared/business/selects/StatusEntranceExamsSelect.jsx';
import ScopeOfActivitySelect from '../../components/shared/business/selects/ScopeOfActivitySelect.jsx';
import YesNoSelect from '../../components/shared/business/CheckBox.jsx';
const iconStyle = { marginRight: '5px' };

export const config = {
    detailsLink: 'RequestDetailPage',
    hasDetailsPage: true,
    properties: {
        family: { name: 'Фамилия', type: String, show: true, required: true },
        name: { name: 'Имя', type: String, show: true, required: true },
        patron: { name: 'Отчество', type: String, show: true, required: true },
        //statusRequestId : { name: 'Статус', type: RequestStatusSelect, show: true, required: true },
        educationProgramId : { name: 'Программа', type: EducationProgramSelect, show: true, required: true },
        typeEducationId : { name: 'Уровень образования', type: EducationTypeSelect, show: true, required: true },
        iT_Experience: { name: 'Опыт в IT', type: String, show: true, required: true },
        speciality: { name: 'Специальность', type: String, show: true, required: true },                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
        projects: { name: 'Проекты', type: String, show: true, required: true },
        statusEntrancExams: { name: 'Тестовое задание', type: StatusEntranceExamsSelect, show: true, required: true },
        birthDate: { name: 'Дата рождения', show: true, type: String, required: true },
        //age: { name: 'Возраст', show: false, type: String, required: false },
        address: { name: 'Место проживания', show: true, type: String, required: true },
        phone: { name: 'Телефон', type: String, show: true, required: true },
        email: { name: 'E-mail', type: String, show: true, required: true },
        scopeOfActivityLevelOneId: { name: 'Сфера деятельности уровень 1', type: ScopeOfActivitySelect, show: true, required: true },
        scopeOfActivityLevelTwoId: { name: 'Сфера деятельности уровень 2', type: ScopeOfActivitySelect, show: true, required: true },
        agreement: { name: 'Согласие на обработку перс. даннных', type: YesNoSelect, show: true, required: true }
    },
    fields: [
        {
            info: 'Ф.И.О. заявителя',
            property: 'studentFullName',
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
            info: 'Дата рождения',
            property: 'birthDate',
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
        {
            info: 'Место проживания',
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
        {
            info: 'Уровень образования',
            property: 'typeEducation',
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
        {
            info: 'Программа обучения',
            property: 'educationProgram',
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
        {
            info: 'e-mail',
            property: 'email',
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
        {
            info: 'Статус',
            property: 'statusRequest',
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