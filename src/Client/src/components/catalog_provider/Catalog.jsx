import React, { useState, useCallback, useMemo, useEffect } from 'react';
import FilterPanel from './FilterPanel.jsx';
import DataPanel from './DataPanel.jsx';
import Spinner from '../shared/Spinner.jsx';
import Empty from '../shared/Empty.jsx';
import Error from '../shared/Error.jsx';
import {  Pagination  }  from 'antd';



const Catalog = ({ config }) => {
    const { columns, catalogData } = config;
    const { getAllPagedAsync } = catalogData;
    const [pageNumber, setPageNumber] = useState(1);
    const [pageSize, setPageSize] = useState(10);
    const [queryString, setQueryString] = useState('');
    const [query, setQuery] = useState({});

    const { 
        data,
        error,
        isLoading,
        isFetching,
        refetch
    } = getAllPagedAsync({ pageNumber, pageSize, filterDataReq: queryString });

    const onShowSizeChange = useCallback((current, pageSize) => {
        setPageNumber(current);
        setPageSize(pageSize);
    });

    const onCurrentPageChange = useCallback((page, pageSize) => {
        setPageNumber(page);
        setPageSize(pageSize);
    });

    useEffect(() => {
        let queryString = '';
        for (const [key, value] of Object.entries(query)) {
            queryString += `&${key}=${value}`
        }
        setPageNumber(1);
        setQueryString(queryString);
    }, [query]);

    if (isLoading) {
        return (
            <>
                <Spinner />
                <Empty />
            </>
        );
    }

    if (error) {
        return <Error e={error} />;
    }
console.log(data)
    return ( 
        <div>
            <FilterPanel
                columns={columns}
                query={query}
                notFilteredData={data.data}
                setQuery={setQuery}
            />
            <DataPanel columns={columns} data={data?.data} />
            <br />
            <Pagination
                className="mb-3"
                showSizeChanger
                hideOnSinglePage
                onChange={onCurrentPageChange}
                onShowSizeChange={onShowSizeChange}
                current={pageNumber}
                defaultCurrent={1}
                total={data?.totalCount}
            />
            {isFetching && <Spinner />}
        </div>
    );
};

export default Catalog;