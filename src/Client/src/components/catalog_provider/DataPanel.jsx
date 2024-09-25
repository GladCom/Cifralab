import React, { useState, useCallback, useMemo, useEffect } from 'react';
import _ from 'lodash';
import ListHeader from './ListHeader.jsx';
import Item from './Item.jsx';

const DataPanel = ({ columns, data }) => {

    return (
        <div className="row">
            <ListHeader columns={columns} />
            <ul>
                {data?.map((d) => (
                    <li key={d.id} ><Item columns={columns} data={d} /></li>
                ))}
            </ul>
        </div>
    );
};

export default DataPanel;