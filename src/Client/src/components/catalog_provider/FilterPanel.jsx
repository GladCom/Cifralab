import React, { useState, useCallback, useMemo, useEffect } from 'react';
import _ from 'lodash';

const style = {
    height: '10vh',
    minHeight: '50px',
};

const student = {
    "id": "f45def2e-76ef-4a80-9293-389ee309c975",
        "fullName": "Дорох Дорохович Дорохов",
        "birthDate": "1998-09-14",
        "requests": null,
        "snils": "123-456-108-18",
        "fullNameDocument": null,
        "documentSeries": "1053",
        "documentNumber": "934",
        "nationality": "РФ",
        "groups": null,
        "phone": "8(912)123-456-17",
        "email": "8(912)12345619@mail.ru",
        "groupStudent": null
  };
const FilterPanel = ({ query, columns, setQuery }) => {

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
            {columns.map(({ name, className, style, filter }) => {
                const Filter = filter.type;
                return filter.enable 
                    ? <div className={className}>
                        <Filter
                            name={name}
                            query={query}
                            setQuery={setQuery}
                            className={className}
                            style={style}
                        />
                    </div>
                    : null;
            })}
        </div>
    );
};

export default FilterPanel;