import React, { useState, useCallback, useMemo, useEffect } from 'react';
import Student from './Student.jsx';
import {  Pagination  }  from 'antd';
import {
    UserOutlined,
    PhoneOutlined,
    CalendarOutlined,
    MailOutlined,
  } from '@ant-design/icons';


const StudentsPanel = ({ students }) => {
    const [currentPage, setCurrentPage] = useState(0);
    const [pageSize, setPageSize] = useState(10);

    useEffect(() => setCurrentPage(0), [students]);

    const onShowSizeChange = useCallback((current, pageSize) => {
        setCurrentPage(current - 1);
        setPageSize(pageSize);
    });

    const onCurrentPageChange = useCallback((page, pageSize) => {
        setCurrentPage(page - 1);
        setPageSize(pageSize);
    });

    const studentsOnPage = useMemo(() => (
        getDataForPage(students, currentPage, pageSize, 1)
    ), [students, currentPage, pageSize]);

    return (
        <>
            <div className="row m-1">
                        <div className="col-3">
                            <UserOutlined style={columnNameStyle} />
                            <span>ФИО</span>
                        </div>
                        <div className="col-1">
                            <UserOutlined style={columnNameStyle} />
                            <span>Пол</span>
                        </div>
                        <div className="col-2">
                            <CalendarOutlined style={columnNameStyle} />
                            <span>дата рождения</span>
                        </div>
                        <div className="col-2">
                            <PhoneOutlined style={columnNameStyle} />
                            <span>телефон</span>
                        </div>
                        <div className="col">
                            <MailOutlined style={columnNameStyle} />
                            <span>email</span>
                        </div>
                    </div>
            <ul className="list-group">
            {
                studentsOnPage?.map((s) => (
                    <Student student={s} key={s.id} />
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
                current={currentPage + 1}
                defaultCurrent={1}
                total={students.length}
            />
        </> 
    );
};

export default StudentsPanel;