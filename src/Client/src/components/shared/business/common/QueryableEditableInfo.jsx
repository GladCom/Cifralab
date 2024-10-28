import React from 'react';
import EditableInfo from './EditableInfo.jsx';


const QueryableEditableInfo = ({ value, changed, setMode, crud, formParams }) => {
    const { useGetOneByIdAsync } = crud;
    const { labelKey } = formParams;
    const { data, error, isLoading, isFetching, refetch } = useGetOneByIdAsync(value);
    
    return (
        <EditableInfo
            value={data?.[labelKey]}
            changed={changed}
            setMode={setMode}
        />
    );
};

export default QueryableEditableInfo;