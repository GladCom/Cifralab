import React, { useState, useCallback, useMemo, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import FilterPanel from './FilterPanel.jsx';
import RemoveForm from './forms/RemoveForm.jsx';
import EditForm from './forms/EditForm.jsx';
import { Button, Table, ConfigProvider } from 'antd';

const { Column } = Table;

const Catalog = ({ config }) => {
    const { fields, properties, detailsLink, crud, hasDetailsPage, columns, serverPaged, dataConverter } = config;
    const { useGetAllPagedAsync, useRemoveOneAsync, useAddOneAsync, useGetOneByIdAsync, useEditOneAsync } = crud;
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
    const navigate = useNavigate();

    const { 
        data: dataFromServer,
        error,
        isLoading,
        isFetching,
        refetch
    } = useGetAllPagedAsync({ 
        pageNumber: tableParams.pagination.current, 
        pageSize: tableParams.pagination.pageSize, 
        filterDataReq: queryString 
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
            queryString += `&${key}=${value}`
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
        setItem(item);

        if (hasDetailsPage) {
            navigate(`/${detailsLink}/${item.id}`);
        } else {
            setShowEditForm(true);
        }
    });

    return ( 
        <div>
            <FilterPanel
                config={config}
                query={query}
                setQuery={setQuery}
            />
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
                        width='5%'
                        render={(_, record) => (
                            <Button
                                onClick={() => openDetailsInfo(record)}
                            >
                                Править
                            </Button>
                        )}
                    />
                    <Column
                        key="delete"
                        width='5%'
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
            { showEditForm && (
                <EditForm
                    item={item}
                    control={{ showEditForm, setShowEditForm }}
                    config={config}
                    refetch={refetch}
                />
            )}
            { showRemoveForm && (
                <RemoveForm
                    item={item}
                    control={{ showRemoveForm, setShowRemoveForm }}
                    config={config}
                    refetch={refetch}
                />
            )}
        </div>
    );
};

export default Catalog;