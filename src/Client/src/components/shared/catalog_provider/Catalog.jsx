import React, { useState, useCallback, useMemo, useEffect } from 'react';
import FilterPanel from './FilterPanel.jsx';
import DataPanel from './DataPanel.jsx';
import Spinner from '../Spinner.jsx';
import Empty from '../Empty.jsx';
import Error from '../Error.jsx';
import {  Pagination  }  from 'antd';



const Catalog = ({ config }) => {
    const { fields, properties, detailsLink, catalogData, hasDetailsPage } = config;
    const { getAllPagedAsync, removeOneAsync, addOneAsync, getOneByIdAsync, editOneAsync } = catalogData;
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

    const normalizedData = hasDetailsPage ? data?.data : data;

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

    return ( 
        <div>
            <FilterPanel
                columns={fields}
                query={query}
                setQuery={setQuery}
                properties={properties}
                addOneAsync={addOneAsync}
            />
            <DataPanel 
                columns={fields}
                data={normalizedData}
                removeOneAsync={removeOneAsync}
                refetch={refetch}
                detailsLink={detailsLink}
                hasDetailsPage={hasDetailsPage}
                properties={properties}
                getOneByIdAsync={getOneByIdAsync}
                editOneAsync={editOneAsync}
            />
            <br />
            <Pagination
                className="mb-3"
                showSizeChanger
                hideOnSinglePage
                onChange={onCurrentPageChange}
                onShowSizeChange={onShowSizeChange}
                current={pageNumber}
                defaultCurrent={1}
                total={normalizedData?.length}
            />
            {isFetching && <Spinner />}
        </div>
    );
};

export default Catalog;