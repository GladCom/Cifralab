import React, { useState, useCallback, useMemo, useEffect } from 'react';
import FilterPanel from './FilterPanel.jsx';
import DataPanel from './DataPanel.jsx';
import Spinner from '../shared/Spinner.jsx';
import Empty from '../shared/Empty.jsx';



const Catalog = ({ config }) => {
    const { columns, catalogData } = config;
    const { getAsync } = catalogData;
    const { data, error, isLoading, refetch } = getAsync();
    const [filteredData, setFilteredData] = useState([]);

    if (isLoading) {
        return (
            <>
                <Spinner />
                <Empty />
            </>
        );
    }

    return ( 
        <div>
            <FilterPanel
                columns={columns}
                notFilteredData={data.data}
                filterData={setFilteredData}
            />
            <DataPanel columns={columns} data={filteredData} />
        </div>
    );
};

export default Catalog;