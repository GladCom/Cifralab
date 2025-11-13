import React, { useState, useCallback, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { Table } from 'antd';
import { TablePageHeader } from '../layout/index';
import FilterPanel from '../catalog-provider/filter-panel';

const EntityTable = ({ config, title }) => {
  const { fields, properties, detailsLink, crud, columns, serverPaged, dataConverter } = config;
  const { useGetAllPagedAsync, useRemoveOneAsync, useAddOneAsync, useGetOneByIdAsync, useEditOneAsync, useSearchAsync } = crud;

  const [searchText, setSearchText] = useState('');
  const [queryString, setQueryString] = useState('');
  const [query, setQuery] = useState({});
  const [data, setData] = useState();
  const [loading, setLoading] = useState(false);
  const [tableParams, setTableParams] = useState({
    pagination: {
      current: 1,
      pageSize: 10,
    },
  });
  const navigate = useNavigate();

  const {
    data: dataFromServer,
    error,
    isLoading,
    isFetching,
    refetch,
  } = useGetAllPagedAsync({
    pageNumber: tableParams.pagination.current,
    pageSize: tableParams.pagination.pageSize,
    filterDataReq: queryString,
  });


  const searchHook = useSearchAsync ? useSearchAsync(searchText) : { data: null };

  const isSearching = !!searchText.trim();
  const dataToDisplay = isSearching
    ? searchHook?.data
    : serverPaged
      ? dataFromServer?.data
      : dataFromServer;

  useEffect(() => {
    if (!isLoading && !isFetching) {
      const total = serverPaged
        ? dataFromServer?.totalCount
        : dataFromServer?.length;
      setData(dataToDisplay);
      setLoading(false);
      setTableParams({
        ...tableParams,
        pagination: {
          ...tableParams.pagination,
          total,
          position: ['bottomLeft'],
        },
      });
    }
  }, [
    dataFromServer,
    searchHook?.data,
    searchText,
    tableParams.pagination?.current,
    tableParams.pagination?.pageSize,
  ]);

  useEffect(() => {
    let queryString = '';
    for (const [key, value] of Object.entries(query)) {
      queryString += `&${key}=${value}`;
    }
    setQueryString(queryString);
  }, [query]);

  const handleTableChange = (pagination, filters, sorter) => {
    setTableParams({
      pagination,
      filters,
      sortOrder: Array.isArray(sorter) ? undefined : sorter.order,
      sortField: Array.isArray(sorter) ? undefined : sorter.field,
    });

    // `dataSource` is useless since `pageSize` changed
    if (pagination.pageSize !== tableParams.pagination?.pageSize) {
      setData([]);
    }
  };

  const openDetailsInfo = useCallback((item) => {
    navigate(`/${detailsLink}/${item.id}`);
  }, []);

  return (
    <>
      <TablePageHeader
        config={config}
        title={title}
        onSearch={setSearchText}
      />
      <FilterPanel config={config} query={query} setQuery={setQuery} />
      <Table
        rowKey={(record) => record.id}
        dataSource={dataConverter(dataToDisplay)}
        pagination={tableParams.pagination}
        loading={loading}
        onChange={handleTableChange}
        columns={columns}
        onRow={(record) => ({
          onClick: ({ target }) => {
            if (target.tagName.toLowerCase() === 'td') {
              openDetailsInfo(record);
            }
          },
          style: { cursor: 'pointer' },
        })}
      />
    </>
  );
};

export default EntityTable;
