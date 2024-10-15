import {
    getAllAsync,
    getAllPagedAsync,
    getOneByIdAsync,
    addOneAsync,
    editOneAsync,
    removeOneAsync,
} from '../crud/educationProgramCrud.js';
import String from '../../components/shared/business/String.jsx';
import YesNoSelect from '../../components/shared/business/YesNoSelect.jsx';
import FEAProgramSelect from '../../components/shared/business/selects/FEAProgramSelect.jsx'
import EducationFormSelect from '../../components/shared/business/selects/EducationFormSelect.jsx'
import KindDocumentRiseQualificationSelect from '../../components/shared/business/selects/KindDocumentRiseQualificationSelect.jsx'
import FinancingTypeSelect from '../../components/shared/business/selects/FinancingTypeSelect.jsx'

export default {
    detailsLink: 'educationProgram',
    hasDetailsPage: true,
    serverPaged: false,
    properties: {
        name: { name: 'Программа обучения', type: String, show: true, required: true },
        cost: { name: 'Стоимость', type: String, show: true, required: true },
        hoursCount: { name: 'Кол-во часов', type: String, show: true, required: true },
        educationFormId: { name: 'Форма образования', type: EducationFormSelect, show: true, required: true },
        kindDocumentRiseQualificationId: { name: 'Вид программы', type: KindDocumentRiseQualificationSelect, show: true, required: true },
        isModularProgram: { name: 'Модульная программа', type: YesNoSelect, show: true, required: true },
        feaProgramId: { name: 'ВЭД программы', type: FEAProgramSelect, show: true, required: true },
        financingTypeId: { name: 'Источник финансирования', type: FinancingTypeSelect, show: true, required: true },
        isCollegeProgram: { name: 'Обязательно наличие ВО', type: YesNoSelect, show: true, required: true },
        isNetworkProgram: { name: 'Сетевая форма', type: YesNoSelect, show: true, required: true },
        isDOTProgram: { name: 'Применение ДОТ', type: YesNoSelect, show: true, required: true },
        isFullDOTProgram: { name: 'Применение ДОТ полностью', type: YesNoSelect, show: true, required: true },
        isArchive: { name: 'В архиве', type: YesNoSelect, show: true, required: true },
    },
    fields: [
        {
            info: 'Программа обучения',
            property: 'name',
            component: String,
            className: 'col-2',
            style: { },
            icon: {
                type: () => {},
                style: {},
            },
            filter: {
                enable: false,
                type: () => {},
            },
        },
        {
            info: 'Вид программы',
            property: 'kindDocumentRiseQualificationId',
            component: String,
            className: 'col-2',
            style: { },
            icon: {
                type: () => {},
                style: {},
            },
            filter: {
                enable: false,
                type: () => {},
            },
        },
        {
            info: 'Форма образования',
            property: 'educationFormId',
            component: String,
            className: 'col-2',
            style: { },
            icon: {
                type: () => {},
                style: {},
            },
            filter: {
                enable: false,
                type: () => {},
            },
        },
        {
            info: 'Кол-во часов',
            property: 'hoursCount',
            component: String,
            className: 'col-2',
            style: { },
            icon: {
                type: () => {},
                style: {},
            },
            filter: {
                enable: false,
                type: () => {},
            },
        },
        {
            info: 'В архиве',
            property: 'isArchive',
            component: String,
            className: 'col-2',
            style: { },
            icon: {
                type: () => {},
                style: {},
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