import { useState, useCallback, useEffect, useMemo } from 'react';
import { useNavigate } from 'react-router-dom';
import { Table } from 'antd';
import type { ColumnType, TablePaginationConfig } from 'antd/es/table';
import { TablePageHeader } from '../layout/index';
import FilterPanel, { Query, FilterConfig } from '../catalog-provider/filter-panel';

type TableColumn = ColumnType<unknown> & {
  sorterKey?: string;
};

type TableParams = {
  pagination: TablePaginationConfig;
  sortOrder?: 'ascend' | 'descend';
  sortField?: string;
  sortingField?: string;
};

type SorterParams = { order?: 'ascend' | 'descend'; field?: string | number | readonly (string | number)[] };

type DataWithDataField = {
  data?: unknown;
};

type TableRecord = {
  id: string | number;
  [key: string]: unknown;
};

function isDataWithDataField(value: unknown): value is DataWithDataField {
  return typeof value === 'object' && value !== null && 'data' in value;
}

function isHTMLElement(value: unknown): value is HTMLElement {
  return value instanceof HTMLElement;
}

function isTableRecord(value: unknown): value is TableRecord {
  return typeof value === 'object' && value !== null && 'id' in value;
}

export type EntityTableConfig = {
  detailsLink: string;
  crud: {
    useGetAllPagedAsync: (params?: unknown) => { data?: unknown; isLoading: boolean; isFetching: boolean };
    useSearchAsync: (searchText: string) => { data?: unknown } | null;
  };
  columns: TableColumn[];
  serverPaged: boolean;
  dataConverter: (data: unknown) => unknown[];
  properties?: unknown;
  searchPlaceholder?: string;
} & FilterConfig;

type EntityTableProps = {
  config: EntityTableConfig;
  title: string;
};

const EntityTable = ({ config, title }: EntityTableProps) => {
  const { detailsLink, crud, columns, serverPaged, dataConverter } = config;
  const { useGetAllPagedAsync, useSearchAsync } = crud;

  const [searchText, setSearchText] = useState('');
  const [queryString, setQueryString] = useState('');
  const [query, setQuery] = useState<Query>({});
  //  TODO: data не используется? Скорей всего надо исправлять.
  const [_data, setData] = useState();
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
  const dataToDisplay: unknown = isSearching
    ? searchResults?.data
    : serverPaged
      ? isDataWithDataField(dataFromServer)
        ? dataFromServer.data
        : undefined
      : dataFromServer;

  useEffect(() => {
    if (!isLoading && !isFetching) {
      //  const total = serverPaged ? dataFromServer?.totalCount : dataFromServer?.length;
      setData(dataToDisplay);
      setLoading(false);
      setTableParams((prev) => ({
        ...prev,
        //...tableParams,
        pagination: {
          ...prev.pagination,
          //...tableParams.pagination,
          // TODO: этих полей нет в сигнатуре, проработать этот вопрос.
          //total,
          //position: ['bottomLeft'],
        },
      }));
    }
  }, [dataFromServer, searchResults.data, searchText, isLoading, isFetching, serverPaged, dataToDisplay, queryString]);

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

  const handleTableChange = (
    pagination: TablePaginationConfig,
    filters: Record<string, unknown>,
    sortParams: SorterParams | SorterParams[],
  ) => {
    const sortInfo = Array.isArray(sortParams) ? sortParams[0] : sortParams;
    const sortOrder = sortInfo?.order;
    const sortFieldRaw = sortInfo?.field;
    const sortField = sortFieldRaw
      ? Array.isArray(sortFieldRaw)
        ? sortFieldRaw[0]?.toString()
        : String(sortFieldRaw)
      : undefined;

    const column = sortField ? columns.find((col) => col.dataIndex === sortField || col.key === sortField) : undefined;

    setTableParams((_prev) => ({
      pagination,
      sortOrder,
      sortField,
      sortingField: column?.sorterKey,
    }));

    // `dataSource` is useless since `pageSize` changed
    if (pagination.pageSize !== tableParams.pagination?.pageSize) {
      setData(undefined);
    }
  };

  const openDetailsInfo = useCallback(
    (item: TableRecord) => {
      navigate(`/${detailsLink}/${item.id}`);
    },
    [detailsLink, navigate],
  );

  const tableColumns = useMemo(() => {
    return columns.map((col) => {
      const column = {
        ...col,
        sorter: col.sorter ? true : false,
        sortOrder: col.sorter && tableParams.sortField === (col.key || col.dataIndex) ? tableParams.sortOrder : null,
      };
      return column;
    });
  }, [columns, tableParams.sortField, tableParams.sortOrder]);

  return (
    <>
      <TablePageHeader config={config} title={title} onSearch={setSearchText} />
      <FilterPanel config={config} query={query} setQuery={setQuery} />
      <Table
        rowKey={(record: unknown) => {
          if (isTableRecord(record)) {
            return String(record.id);
          }
          return '';
        }}
        dataSource={dataConverter(dataToDisplay)}
        pagination={tableParams.pagination}
        loading={loading}
        onChange={handleTableChange}
        columns={tableColumns}
        onRow={(record: unknown) => ({
          onClick: ({ target }: React.MouseEvent) => {
            if (isHTMLElement(target) && target.tagName.toLowerCase() === 'td') {
              if (isTableRecord(record)) {
                openDetailsInfo(record);
              }
            }
          },
          style: { cursor: 'pointer' },
        })}
      />
    </>
  );
};

export default EntityTable;
