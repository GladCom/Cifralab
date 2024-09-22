import React, { useState, useCallback, useMemo, useEffect } from 'react';
import _ from 'lodash';
import ListHeader from './ListHeader.jsx';
import Item from './Item.jsx';
import {  Pagination  }  from 'antd';
import { getDataForPage } from '../../services/paginator.js';

const DataPanel = ({ columns, data }) => {
    const [currentPage, setCurrentPage] = useState(0);
    const [pageSize, setPageSize] = useState(10);

    useEffect(() => setCurrentPage(0), [data]);

    const onShowSizeChange = useCallback((current, pageSize) => {
        setCurrentPage(current - 1);
        setPageSize(pageSize);
    });

    const onCurrentPageChange = useCallback((page, pageSize) => {
        setCurrentPage(page - 1);
        setPageSize(pageSize);
    });

    const itemsOnPage = useMemo(() => (
        getDataForPage(data, currentPage, pageSize, 1)
    ), [data, currentPage, pageSize]);

    return (
        <div className="row">
            <ListHeader columns={columns} />
            <ul>
                {itemsOnPage?.map((d) => (
                    <li key={_.uniqueId()} ><Item columns={columns} data={d} /></li>
                ))}
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
                total={data?.length}
            />
        </div>
    );
};

export default DataPanel;