import React from 'react';
import EditableInfo from './EditableInfo.jsx';


const QueryableEditableInfo = ({ id, changed, setMode, crud, property }) => {
    const { getOneByIdAsync } = crud;
    const { data, error, isLoading, isFetching, refetch } = getOneByIdAsync(id);

    return (
        <EditableInfo
            value={data?.[property]}
            changed={changed}
            setMode={setMode}
        />
    );
};

export default QueryableEditableInfo;