import React, { useState, useEffect, useRef } from 'react';
import { Checkbox } from 'antd';
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

//  TODO    лучше перенести эту реализацию в компонент в новый режим
const IsArchive = ({ record }) => {
    const { id, isArchive } = record;
    const [editProgram, { isSuccess, isError }] = useEditOneAsync();
    const [status, setStatus] = useState('');
    const checkboxRef = useRef(null);

    useEffect(() => {
        if (isError) {
            setStatus('error');
        }
    }, [isSuccess, isError]);

    const onChange = ({ target }) => {
        const editetProgram = { ...record };
        delete editetProgram.id;
        delete editetProgram.educationForm;
        delete editetProgram.kindDocumentRiseQualification;
        editProgram({ id, item: { ...editetProgram, isArchive: target.checked }});
        checkboxRef.current.blur();
    };

    return (
        <Checkbox
            ref={checkboxRef}
            defaultChecked={isArchive}
            onChange={onChange}
        />
    );
};

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
            dataIndex: 'educationFormId',
            key: 'educationFormId',
            render: (_, record) => {
console.log(record)
                return (
                    <EducationFormSelect  mode='info' />
                );
            },
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
            render: (_, record) => (<IsArchive record={record} />),
        },
    ],
    dataConverter: (data) => {
        return data?.map(({ kindDocumentRiseQualificationId, educationFormId, ...props }) => {
            const kindDocumentRiseQualification = (
                <KindDocumentRiseQualificationSelect value={kindDocumentRiseQualificationId} mode='info' />
            );
            // const educationForm = (
            //     <EducationFormSelect value={educationFormId} mode='info' />
            // );
            return { ...props, kindDocumentRiseQualification, };
        });
    },
};