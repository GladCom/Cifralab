import React, { useState, useCallback, useEffect, useMemo } from 'react';
import { useNavigate } from 'react-router-dom';
import { Table } from 'antd';
import { TablePageHeader } from '../layout/index';
import FilterPanel from '../catalog-provider/filter-panel';

const EntityTable = ({ config, title }) => {
  const { detailsLink, crud, columns, serverPaged, dataConverter } = config;
  const { useGetAllPagedAsync, useSearchAsync } = crud;

  const [searchText, setSearchText] = useState('');
  const [queryString, setQueryString] = useState('');
  const [query, setQuery] = useState({});
  const [data, setData] = useState();
  const [tableParams, setTableParams] = useState({
    pagination: {
      current: 1,
      pageSize: 10,
    },
    sortOrder: undefined,
    sortField: undefined,
    sortBackendField: undefined,
  });
  const navigate = useNavigate();

  const sorterFieldMap = useMemo(() => {
    return (columns ?? []).reduce((acc, column) => {
      const backendField = column?.sorterKey;

      if (!backendField) {
        return acc;
      }

      const identifiers = [column?.dataIndex, column?.key].filter(Boolean);

      identifiers.forEach((identifier) => {
        acc[identifier] = backendField;
      });

      return acc;
    }, {});
  }, [columns]);

  const {
    data: dataFromServer,
    isLoading,
    isFetching,
  } = useGetAllPagedAsync({
    pageNumber: tableParams.pagination.current,
    pageSize: tableParams.pagination.pageSize,
    filterDataReq: queryString,
  });

  const searchResults = useSearchAsync ? useSearchAsync(searchText) : { data: null };

  const isSearching = !!searchText.trim();
  const dataToDisplay = isSearching ? searchResults?.data : serverPaged ? dataFromServer?.data : dataFromServer;

  useEffect(() => {
    if (!isLoading && !isFetching) {
      const total = serverPaged ? dataFromServer?.totalCount : dataFromServer?.length;
      setData(normalizedData);

      setTableParams((prev) => ({
        ...prev,
        pagination: {
          ...prev.pagination,
          total,
          position: ['bottomLeft'],
        },
      }));
    }
  }, [
    dataFromServer,
    isLoading,
    isFetching,
  ]);

  useEffect(() => {
    const params = new URLSearchParams();

    Object.entries(query).forEach(([key, value]) => {
      if (value !== undefined && value !== null) {
        params.set(key, String(value));
      }
    });

    if (tableParams.sortBackendField) {
      params.set('sortingField', tableParams.sortBackendField);
      const isSortAsc = tableParams.sortOrder === 'descend' ? 'false' : 'true';
      params.set('isSortAsc', isSortAsc);
    }

    const paramsString = params.toString();
    setQueryString(paramsString ? `&${paramsString}` : '');
  }, [query, tableParams.sortBackendField, tableParams.sortOrder]);

  const handleTableChange = (pagination, filters, sorter) => {
    const sortOrder = sorter?.order;
    const sortKey = sorter?.field ?? sorter?.columnKey;
    const backendField = sortKey ? sorterFieldMap[sortKey] : undefined;

    setTableParams((prev) => ({
      pagination: {
        ...pagination,
        position: pagination.position ?? prev.pagination?.position,
      },
      filters,
      sortOrder,
      sortField: sortKey,
      sortBackendField: backendField,
    }));

    if (pagination.pageSize !== tableParams.pagination?.pageSize) {
      setData([]);
    }
  };

  const openDetailsInfo = useCallback((item) => {
    navigate(`/${detailsLink}/${item.id}`);
  }, []);

  return (
    <>
      <TablePageHeader config={config} title={title} onSearch={setSearchText} />
      <FilterPanel config={config} query={query} setQuery={setQuery} />
      <Table
        rowKey={(record) => record.id}
        dataSource={dataConverter(dataToDisplay)}
        pagination={tableParams.pagination}
        loading={isLoading || isFetching}
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
