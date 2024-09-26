import React, { useState, useCallback, useMemo, useEffect } from 'react';
import _ from 'lodash';
import ListHeader from './ListHeader.jsx';
import Item from './Item.jsx';
import RemoveForm from './forms/RemoveForm.jsx';

const DataPanel = ({ columns, data, removeOneAsync, refetch }) => {
    const [showRemoveForm, setShowRemoveForm] = useState(false);
    const [itemId, setItemId] = useState('');
    const [removeItem, queryState] = removeOneAsync();

    return (
        <>
            {
                showRemoveForm 
                && <RemoveForm 
                    show={setShowRemoveForm} 
                    validate={() => removeItem(itemId)}
                    queryState={queryState}
                    refetch={refetch}
                />
            }
            <div className="row">
                <ListHeader columns={columns} />
                <ul>
                    {data?.map((d) => (
                        <li key={d.id}>
                            <Item 
                                columns={columns}
                                data={d}
                                setItem={setItemId}
                                showDialog={setShowRemoveForm}
                            />
                        </li>
                    ))}
                </ul>
            </div>
        </>
    );
};

export default DataPanel;