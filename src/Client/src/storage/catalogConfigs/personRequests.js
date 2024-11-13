import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/personRequestsCrud.js';
import { personRequestsModel } from '../models/index.js';
import RequestStatusSelect from '../../components/shared/business/selects/RequestStatusSelect.jsx';
import BirthDate from '../../components/shared/business/BirthDate.jsx';
import CheckBox from '../../components/shared/business/common/CheckBox.jsx';
import EducationProgramSelect from '../../components/shared/business/selects/EducationProgramSelect.jsx';
import StatusEntrancExamsSelect from '../../components/shared/business/selects/StatusEntrancExamsSelect.jsx';
import ScopeOfActivitySelect from '../../components/shared/business/selects/ScopeOfActivitySelect.jsx';

export default {
    detailsLink: 'requests',
    hasDetailsPage: true,
    serverPaged: true,
    properties: personRequestsModel,
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
        {
            title: 'Обучающийся',
            dataIndex: 'trained1',
            key: 'trained',
        }
    ],
    dataConverter: (data) => {
            return data?.map(({ statusRequestId, trained, educationProgramId, scopeOfActivityLevelOneId, scopeOfActivityLevelTwoId, ...props }) => {
            const statusRequest = (
                <RequestStatusSelect value={statusRequestId} mode='info' />
            );
            //const birthDate1 = (
            //    <BirthDate value={birthDate ?? new Date()} mode='info' />
            //);
            const trained1 = (
                <CheckBox value={trained} mode='info' />
            );
            const educationProgram = (
                <EducationProgramSelect value={educationProgramId} mode='info' />
            );
            //const statusEntrancExamsTitle = (
            //    <StatusEntrancExamsSelect value={statusEntrancExams} mode='info' />
            //);
            const scopeOfActivityLevelOne = (
                <ScopeOfActivitySelect value={scopeOfActivityLevelOneId} mode='info' />
            );
            const scopeOfActivityLevelTwo = (
                <ScopeOfActivitySelect value={scopeOfActivityLevelTwoId} mode='info' />
            );
            return { ...props, scopeOfActivityLevelTwo, scopeOfActivityLevelOne, educationProgram, trained1, statusRequest  };
        });
    },
};