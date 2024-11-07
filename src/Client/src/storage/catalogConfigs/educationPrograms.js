import {
    useGetAllAsync,
    useGetAllPagedAsync,
    useGetOneByIdAsync,
    useAddOneAsync,
    useEditOneAsync,
    useRemoveOneAsync,
} from '../crud/educationProgramCrud.js';
import { educationProgramsModel } from '../models/index.js';
import EducationFormSelect from '../../components/shared/business/selects/EducationFormSelect.jsx'
import KindDocumentRiseQualificationSelect from '../../components/shared/business/selects/KindDocumentRiseQualificationSelect.jsx'

export default {
    detailsLink: 'educationProgram',
    hasDetailsPage: true,
    serverPaged: false,
    properties: educationProgramsModel,
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
            title: 'Программа обучения',
            dataIndex: 'name',
            key: 'name',
        },
        {
            title: 'Вид программы',
            dataIndex: 'kindDocumentRiseQualification',
            key: 'kindDocumentRiseQualification',
        },
        {
            title: 'Форма обучения',
            dataIndex: 'educationForm',
            key: 'educationForm',
        },
        {
            title: 'Кол-во часов',
            dataIndex: 'hoursCount',
            key: 'hoursCount',
        },
        {
            title: 'В архив',
            dataIndex: 'isArchive',
            key: 'archive',
        },
    ],
    dataConverter: (data) => {
        return data?.map(({ kindDocumentRiseQualificationId, educationFormId, ...props }) => {
            const kindDocumentRiseQualification = (
                <KindDocumentRiseQualificationSelect value={kindDocumentRiseQualificationId} mode='info' />
            );
            const educationForm = (
                <EducationFormSelect value={educationFormId} mode='info' />
            );
            return { ...props, kindDocumentRiseQualification, educationForm };
        });
    },
};