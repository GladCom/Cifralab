import React, { useState, useCallback, useMemo, useEffect } from 'react';
import _ from 'lodash';

const style = {
    height: '10vh',
    minHeight: '50px',
};

const FilterPanel = ({ columns, notFilteredData, filterData }) => {
    const [filteredData, setFilteredData] = useState(notFilteredData);

    useEffect(() => filterData(filteredData), [filteredData]);

    return (
        <div className="
            row 
            d-flex
            align-items-center 
            w-100
            text-center
            border-bottom
            border-primary"
            style={style}
        >
            {columns.map(({ className, style, filter }) => {
                const Filter = filter.type;
                return filter.enable 
                    ? <Filter
                        data={filteredData}
                        setFilteredData={setFilteredData}
                        className={className}
                        style={style}
                    />
                    : null;
            })}
        </div>
    );
};

export default FilterPanel;