import { useState, useCallback, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import FilterPanel from './filter-panel';
import RemoveForm from './forms/remove-form';
import EditForm from './forms/edit-form';
import { Button, Table, ConfigProvider } from 'antd';
import TablePageHeader from '../layout/table-page-header';
/* Много исправлений проверить на работоспособность и корректность*/
const { Column } = Table;

const Catalog = ({ config, title }) => {
  const { detailsLink, crud, hasDetailsPage, columns, serverPaged, dataConverter } = config;
  const { useGetAllPagedAsync } = crud;
  const navigate = useNavigate();

  // переменные
  const [item, setItem] = useState({});
  const [queryString, setQueryString] = useState('');
  const [showEditForm, setShowEditForm] = useState(false);
  const [showRemoveForm, setShowRemoveForm] = useState(false);
  const [query, setQuery] = useState({});
  const [data, setData] = useState();
  const [loading, setLoading] = useState(false);
  const [tableParams, setTableParams] = useState({
    pagination: {
      current: 1,
      pageSize: 10,
    },
  });

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

  // Вынесенная переменная totalCount
  const totalCount = serverPaged ? dataFromServer?.totalCount : dataFromServer?.length;

  useEffect(() => {
    if (!isLoading && !isFetching) {
      const normalizedData = serverPaged ? dataFromServer?.data : dataFromServer;
      setData(normalizedData);
      setLoading(false);
      setTableParams((prev) => ({
        ...prev,
        pagination: {
          ...prev.pagination,
          total: totalCount,
          position: ['bottomLeft'],
        },
      }));
    }
  }, [dataFromServer, isLoading, isFetching, serverPaged, totalCount]);

  useEffect(() => {
    let qs = '';
    for (const [key, value] of Object.entries(query)) {
      qs += `&${key}=${value}`;
    }
    setQueryString(qs);
  }, [query]);

  // Обработчик смены таблицы
  const handleTableChange = (pagination, filters, sorter) => {
    setTableParams((prev) => ({
      ...prev,
      pagination,
      filters,
      sortOrder: Array.isArray(sorter) ? undefined : sorter?.order,
      sortField: Array.isArray(sorter) ? undefined : sorter?.field,
    }));

    if (pagination.pageSize !== tableParams.pagination?.pageSize) {
      setData([]);
    }
  };

  const openDetailsInfo = useCallback(
    (item) => {
      setItem(item);
      if (hasDetailsPage) {
        navigate(`/${detailsLink}/${item.id}`);
      } else {
        setShowEditForm(true);
      }
    },
    [hasDetailsPage, navigate, detailsLink],
  );

  // Обработка ошибок: показываем только если есть ошибка
  if (error) {
    return (
      <div style={{ padding: '20px', color: 'red', fontWeight: 'bold' }}>
        Произошла ошибка: {error.message || String(error)}
      </div>
    );
  }

  return (
    <>
      <TablePageHeader config={config} title={title} />
      <FilterPanel config={config} query={query} setQuery={setQuery} />
      <Table
        rowKey={(record) => record.id}
        dataSource={dataConverter(data)}
        pagination={tableParams.pagination}
        loading={loading}
        onChange={handleTableChange}
      >
        {columns.map((c) => (
          <Column title={c.title} dataIndex={c.dataIndex} key={c.key} />
        ))}
        <ConfigProvider
          theme={{
            components: {
              Button: {
                paddingBlock: 1,
              },
            },
          }}
        >
          <Column
            key="edit"
            width="5%"
            render={(_, record) => <Button onClick={() => openDetailsInfo(record)}>Править</Button>}
          />
          <Column
            key="delete"
            width="5%"
            render={(_, record) => (
              <Button
                color="danger"
                variant="outlined"
                onClick={() => {
                  setItem(record);
                  setShowRemoveForm(true);
                }}
              >
                Удалить
              </Button>
            )}
          />
        </ConfigProvider>
      </Table>
      {showEditForm && (
        <EditForm item={item} control={{ showEditForm, setShowEditForm }} config={config} refetch={refetch} />
      )}
      {showRemoveForm && (
        <RemoveForm item={item} control={{ showRemoveForm, setShowRemoveForm }} config={config} refetch={refetch} />
      )}
    </>
  );
};

export default Catalog;
