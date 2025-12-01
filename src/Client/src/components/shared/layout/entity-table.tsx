import { useState, useCallback, useEffect, useMemo } from 'react';
import { useNavigate } from 'react-router-dom';
import { Table } from 'antd';
import { TablePageHeader } from '../layout/index';
import FilterPanel from '../catalog-provider/filter-panel';

interface TableColumn {
  title: string;
  dataIndex?: string;
  key?: string;
  sorter?: boolean;
  sorterKey?: string;
  render?: (value: unknown, record: unknown) => React.ReactNode;
}

interface TableParams {
  pagination: {
    current: number;
    pageSize: number;
  };
  sortOrder?: 'ascend' | 'descend';
  sortField?: string;
  sortingField?: string;
}

const EntityTable = ({ config, title }) => {
  const { detailsLink, crud, columns, serverPaged, dataConverter } = config;
  const { useGetAllPagedAsync, useSearchAsync } = crud;

  const [searchText, setSearchText] = useState('');
  const [queryString, setQueryString] = useState('');
  const [query, setQuery] = useState({});
  const [data, setData] = useState();
  const [loading, setLoading] = useState(false);
  const [tableParams, setTableParams] = useState<TableParams>({
    pagination: {
      current: 1,
      pageSize: 10,
    },
    sortOrder: undefined,
    sortField: undefined,
    sortingField: undefined,
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
    sortingField: tableParams.sortingField || undefined,
    isSortAsc: tableParams.sortOrder ? tableParams.sortOrder === 'ascend' : undefined,
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
    tableParams,
    searchResults.data,
    searchText,
    isLoading,
    isFetching,
    serverPaged,
    dataToDisplay,
  ]);

  useEffect(() => {
    const filterObject = {};
    for (const [key, value] of Object.entries(query)) {
      if (value !== undefined && value !== null && value !== '') {
        filterObject[key] = value;
      }
    }
    const filterString = Object.keys(filterObject).length > 0 ? JSON.stringify(filterObject) : '{}';
    setQueryString(`&filterString=${encodeURIComponent(filterString)}`);
    setTableParams((prev) => {
      if (prev.pagination.current === 1) {
        return prev;
      }
      return {
        ...prev,
        pagination: {
          ...prev.pagination,
          current: 1,
        },
      };
    });
  }, [query]);

  const handleTableChange = (pagination, filters, sorter) => {
    const sortOrder = Array.isArray(sorter) ? undefined : sorter?.order;
    const sortField = Array.isArray(sorter) ? undefined : sorter?.field;
    
    let sortingField: string | undefined = undefined;
    if (sortField && columns) {
      const column = (columns as TableColumn[]).find((col) => 
        col.dataIndex === sortField || col.key === sortField
      );
      if (column?.sorterKey) {
        sortingField = column.sorterKey;
      }
    }

    setTableParams((prev) => ({
      pagination,
      sortOrder: sortOrder !== undefined ? sortOrder : undefined,
      sortField: sortField !== undefined ? sortField : undefined,
      sortingField: sortingField,
    }));

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

  const tableColumns = useMemo(() => {
    return (columns as TableColumn[]).map((col) => {
      const column = {
        ...col,
        sorter: col.sorter ? true : false,
        sortOrder: col.sorter && tableParams.sortField === (col.key || col.dataIndex) 
          ? tableParams.sortOrder
          : null,
      };
      return column;
    });
  }, [columns, tableParams.sortField, tableParams.sortOrder]);

  return (
    <>
      <TablePageHeader config={config} title={title} onSearch={setSearchText} />
      <FilterPanel config={config} query={query} setQuery={setQuery} />
      <Table
        rowKey={(record: any) => record.id}
        dataSource={dataConverter(dataToDisplay)}
        pagination={tableParams.pagination}
        loading={loading}
        onChange={handleTableChange}
        columns={tableColumns}
        onRow={(record: any) => ({
          onClick: ({ target }: React.MouseEvent) => {
            if ((target as HTMLElement).tagName.toLowerCase() === 'td') {
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
