import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/groupsCrud.js';
import String from '../../components/shared/business/String.jsx';
import EducationProgramSelect from '../../components/shared/business/selects/EducationProgramSelect.jsx'

export default {
    detailsLink: 'group',
    hasDetailsPage: true,
    serverPaged: false,
    properties: {
        name: { name: 'Наименование группы', type: String, show: true, required: true },
        educationProgramId: { name: 'Программа обучения', type: EducationProgramSelect, show: true, required: true },
        startDate: { name: 'Дата начала', type: String, show: true, required: true },
        endDate: { name: 'Дата окончания', type: String, show: true, required: true },
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
            title: 'Группа',
            dataIndex: 'name',
            key: 'name',
        },
        {
            title: 'Программа обучения',
            dataIndex: 'educationProgramId',
            key: 'educationProgramId',
        },
        {
            title: 'Дата начала',
            dataIndex: 'startDate',
            key: 'startDate',
        },
        {
            title: 'Дата окончания',
            dataIndex: 'endDate',
            key: 'endDate',
        },
        {
            title: 'В архив',
            key: 'nameOfGroup',
        },
    ],
};