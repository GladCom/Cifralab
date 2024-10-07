import React from 'react';
import Info from './Info';

const QueryableInfo = ({ id, crud, property }) => {
    const { getOneByIdAsync } = crud;
    const { data, error, isLoading, isFetching, refetch } = getOneByIdAsync(id);

    return (
        <Info value={data?.[property]} /> 
    );
};

export default QueryableInfo;