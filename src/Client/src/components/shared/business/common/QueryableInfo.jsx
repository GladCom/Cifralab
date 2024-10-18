import React from 'react';
import Info from './Info';

const QueryableInfo = ({ id, crud, property }) => {
    const { useGetOneByIdAsync } = crud;
    const { data, error, isLoading, isFetching, refetch } = useGetOneByIdAsync(id);

    return (
        <Info value={data?.[property]} /> 
    );
};

export default QueryableInfo;