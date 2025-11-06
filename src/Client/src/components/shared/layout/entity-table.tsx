import React, { useState, useCallback, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { Table } from 'antd';
import { TablePageHeader } from '../layout/index';
import FilterPanel from '../catalog-provider/filter-panel';

const EntityTable = ({ config, title }) => {
  const { fields, properties, detailsLink, crud, columns, serverPaged, dataConverter } = config;
  const { useGetAllPagedAsync, useRemoveOneAsync, useAddOneAsync, useGetOneByIdAsync, useEditOneAsync } = crud;
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

  useEffect(() => {
    if (!isLoading && !isFetching) {
      const normalizedData = serverPaged ? dataFromServer?.data : dataFromServer;
      const total = serverPaged ? dataFromServer?.totalCount : dataFromServer?.length;
      setData(normalizedData);
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
    tableParams.pagination?.current,
    tableParams.pagination?.pageSize,
    tableParams?.sortOrder,
    tableParams?.sortField,
    JSON.stringify(tableParams.filters),
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
  });

  return (
    <>
      <TablePageHeader config={config} title={title} setQuery={setQuery} />
      <FilterPanel config={config} query={query} setQuery={setQuery} />
      <Table
        rowKey={(record) => record.id}
        dataSource={dataConverter(data)}
        pagination={tableParams.pagination}
        loading={loading}
        onChange={handleTableChange}
        columns={columns}
        onRow={(record) => {
          return {
            onClick: ({ target }) => {
              if (target.tagName.toLowerCase() === 'td') {
                openDetailsInfo(record);
              }
            },
            style: { cursor: 'pointer' },
          };
        }}
      />
    </>
  );
};

export default EntityTable;
