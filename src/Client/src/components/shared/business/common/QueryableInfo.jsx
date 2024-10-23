import React from 'react';
import Info from './Info';

const QueryableInfo = ({ id, crud, formParams }) => {
    const { useGetOneByIdAsync } = crud;
    const { key } = formParams;
    const { data, error, isLoading, isFetching, refetch } = useGetOneByIdAsync(id);

    return (
        <Info value={data?.[key]} /> 
    );
};

export default QueryableInfo;