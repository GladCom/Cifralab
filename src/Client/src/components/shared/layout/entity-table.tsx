import { useState, useCallback, useEffect, useMemo } from 'react';
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
  const [loading, setLoading] = useState(false);
  const [tableParams, setTableParams] = useState({
    pagination: {
      current: 1,
      pageSize: 10,
    },
    // sortOrder: undefined,
    // sortField: undefined,
    // sortBackendField: undefined,
  });
  const navigate = useNavigate();

  const {
    data: dataFromServer,
    isLoading,
    isFetching,
  } = useGetAllPagedAsync({
    pageNumber: tableParams.pagination.current,
    pageSize: tableParams.pagination.pageSize,
    filterDataReq: queryString,
  });

  const searchResults = useSearchAsync(searchText) || { data: null };
  const isSearching = !!searchText.trim();
  const dataToDisplay = isSearching ? searchResults?.data : serverPaged ? dataFromServer?.data : dataFromServer;

  useEffect(() => {
    if (!isLoading && !isFetching) {
      //  const total = serverPaged ? dataFromServer?.totalCount : dataFromServer?.length;
      setData(dataToDisplay);
      setLoading(false);
      setTableParams({
        ...tableParams,
        pagination: {
          ...tableParams.pagination,
          // TODO: этих полей нет в сигнатуре, проработать этот вопрос.
          //total,
          //position: ['bottomLeft'],
        },
      });
    }
  }, [
    dataFromServer,
    tableParams.pagination.pageSize,
    searchResults.data,
    searchText,
    isLoading,
    isFetching,
    serverPaged,
    dataToDisplay,
  ]);

  useEffect(() => {
    let queryString = '';
    for (const [key, value] of Object.entries(query)) {
      queryString += `&${key}=${value}`;
    }
    setQueryString(queryString);
  }, [query]);

  const handleTableChange = (pagination) => {
    setTableParams({
      pagination,
      // TODO: этих полей нет в сигнатуре, проработать этот вопрос.
      //  filters,
      //  sortOrder: Array.isArray(sorter) ? undefined : sorter.order,
      //  sortField: Array.isArray(sorter) ? undefined : sorter.field,
    });

    // `dataSource` is useless since `pageSize` changed
    if (pagination.pageSize !== tableParams.pagination?.pageSize) {
      setData(undefined);
    }
  };

  const openDetailsInfo = useCallback(
    (item) => {
      navigate(`/${detailsLink}/${item.id}`);
    },
    [detailsLink, navigate],
  );

  return (
    <>
      <TablePageHeader config={config} title={title} onSearch={setSearchText} />
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
