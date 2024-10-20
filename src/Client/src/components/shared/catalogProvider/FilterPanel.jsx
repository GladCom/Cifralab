import React, { useState, useCallback, useMemo, useEffect } from 'react';
import _ from 'lodash';
import Button from 'react-bootstrap/Button';
import { PlusOutlined } from '@ant-design/icons';
import AddOneForm from './forms/AddOneForm.jsx';

const style = {
    height: '10vh',
    minHeight: '50px',
};

const classes = "row d-flex align-items-center w-100 text-center border-bottom border-primary";

const FilterPanel = ({ query, config, setQuery }) => {
    const { properties, crud } = config;
    const [showAddOneForm, setShowAddOneForm] = useState(false);

    return (
        <>
            <div className={classes} style={style}>
                {/* {fields.map(({ name, className, style, filter }) => {
                    const Filter = filter.type;
                    return filter.enable 
                        ? <div className={className}>
                            <Filter
                                name={name}
                                query={query}
                                setQuery={setQuery}
                                style={style}
                            />
                        </div>
                        : null;
                })} */}
                <div className="col-2 ms-auto">
                    <Button variant="outline-primary" onClick={() => setShowAddOneForm(true)}>
                        <PlusOutlined />
                        добавить
                    </Button>
                </div>
            </div>
            <AddOneForm control={{ showAddOneForm, setShowAddOneForm }} properties={properties} crud={crud} />
        </>
    );
};

export default FilterPanel;