import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/personRequestsCrud.js';

import String from '../../components/shared/business/String.jsx';
import RequestStatusSelect from '../../components/shared/business/selects/RequestStatusSelect.jsx';
import EducationProgramSelect from '../../components/shared/business/selects/EducationProgramSelect.jsx';
import EducationTypeSelect from '../../components/shared/business/selects/EducationTypeSelect.jsx';
import StatusEntranceExamsSelect from '../../components/shared/business/selects/StatusEntranceExamsSelect.jsx';
import ScopeOfActivitySelect from '../../components/shared/business/selects/ScopeOfActivitySelect.jsx';
import YesNoSelect from '../../components/shared/business/CheckBox.jsx';
import Snils from '../../components/shared/business/validation/Snils.jsx';

export default {
    detailsLink: 'requests',
    hasDetailsPage: true,
    serverPaged: true,
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
        statusEntranceExams: { name: 'Тестовое задание', type: StatusEntranceExamsSelect, show: true, required: true },
        birthDate: { name: 'Дата рождения', show: true, type: String, required: true },
        //age: { name: 'Возраст', show: false, type: String, required: false },
        address: { name: 'Место проживания', show: true, type: String, required: true },
        phone: { name: 'Телефон', type: Snils, show: true, required: true },
        email: { name: 'E-mail', type: String, show: true, required: true },
        scopeOfActivityLevelOneId: { name: 'Сфера деятельности уровень 1', type: ScopeOfActivitySelect, show: true, required: true },
        scopeOfActivityLevelTwoId: { name: 'Сфера деятельности уровень 2', type: ScopeOfActivitySelect, show: true, required: true },
        agreement: { name: 'Согласие на обработку перс. даннных', type: YesNoSelect, show: true, required: true }
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
            title: 'Ф.И.О. заявителя',
            dataIndex: 'studentFullName',
            key: 'studentFullName',
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
            title: 'Уровень образования',
            dataIndex: 'typeEducation',
            key: 'typeEducation',
        },
        {
            title: 'Программа обучения',
            dataIndex: 'educationProgram',
            key: 'educationProgram',
        },
        {
            title: 'E-mail',
            dataIndex: 'email',
            key: 'email',
        },
        {
            title: 'Статус',
            dataIndex: 'statusRequest',
            key: 'statusRequest',
        },
    ],
};