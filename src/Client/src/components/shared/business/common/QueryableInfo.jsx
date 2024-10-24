import React from 'react';
import Info from './Info';

const QueryableInfo = ({ value, crud, formParams }) => {
    const { useGetOneByIdAsync } = crud;
    const { key } = formParams;
    const { data, error, isLoading, isFetching, refetch } = useGetOneByIdAsync(value);

    return (
        <Info value={data?.[key]} /> 
    );
};

export default QueryableInfo;