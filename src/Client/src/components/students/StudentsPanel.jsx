import React, { useState, useCallback, useMemo } from 'react';
import Student from './Student.jsx';
import {  Pagination  }  from 'antd';
import { getDataForPage } from '../../services/paginator.js';
import {
    UserOutlined,
    PhoneOutlined,
    CalendarOutlined,
    MailOutlined,
  } from '@ant-design/icons';

const StudentsPanel = ({ students }) => {
    const [currentPage, setCurrentPage] = useState(0);
    const [pageSize, setPageSize] = useState(10);

    const studentsOnPage = useMemo((
        () => getDataForPage(students, currentPage, pageSize, 1)
    ), [students, currentPage, pageSize]);

    const onShowSizeChange = useCallback((current, pageSize) => {
        setCurrentPage(current - 1);
        setPageSize(pageSize);
    });

    const onCurrentPageChange = useCallback((page, pageSize) => {
        setCurrentPage(page - 1);
        setPageSize(pageSize);
    });

    return (
        <>
            <div className="row m-1">
                        <div className="col">
                            <UserOutlined style={{ 'margin-right': '5px' }} />
                            <span>ФИО</span>
                        </div>
                        <div className="col">
                            <CalendarOutlined style={{ 'margin-right': '5px' }} />
                            <span>дата рождения</span>
                        </div>
                        <div className="col">
                            <PhoneOutlined style={{ 'margin-right': '5px' }} />
                            <span>телефон</span>
                        </div>
                        <div className="col">
                            <MailOutlined style={{ 'margin-right': '5px' }} />
                            <span>email</span>
                        </div>
                    </div>
            <ul className="list-group">
            {
                studentsOnPage?.map((s) => (
                    <Student student={s} />
                ))
            }
            </ul>
            <br />
            <Pagination
                className="mb-3"
                showSizeChanger
                hideOnSinglePage
                onChange={onCurrentPageChange}
                onShowSizeChange={onShowSizeChange}
                defaultCurrent={1}
                total={students.length}
            />
        </> 
    );
};

export default StudentsPanel;