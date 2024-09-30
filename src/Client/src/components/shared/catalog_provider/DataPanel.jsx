import React, { useState, useCallback, useMemo, useEffect } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import _ from 'lodash';
import ListHeader from './ListHeader.jsx';
import Item from './Item.jsx';
import RemoveForm from './forms/RemoveForm.jsx';
import EditForm from './forms/EditForm.jsx';

const DataPanel = ({ columns, detailsLink, data, removeOneAsync, refetch, hasDetailsPage, properties, getOneByIdAsync, editOneAsync }) => {
    const [showRemoveForm, setShowRemoveForm] = useState(false);
    const [showEditForm, setShowEditForm] = useState(false);
    const [itemId, setItemId] = useState('');
    const [removeItem, queryState] = removeOneAsync();
    const navigate = useNavigate();

    const openDetailsInfo = useCallback((id) => {
        if (hasDetailsPage) {
            navigate(`/${detailsLink}/${id}`);
        } else {
            setShowEditForm(true);
        }
    });

    return (
        <>
            { showEditForm && (<EditForm id={itemId} show={setShowEditForm} getOneByIdAsync={getOneByIdAsync} editOneAsync={editOneAsync} properties={properties} refetch={refetch} />)}
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
                {data?.map((d) => (
                    <Item
                        key={d.id}
                        columns={columns}
                        data={d}
                        setItem={setItemId}
                        showDialog={setShowRemoveForm}
                        onClick={openDetailsInfo}
                    />
                ))}
            </div>
        </>
    );
};

export default DataPanel;