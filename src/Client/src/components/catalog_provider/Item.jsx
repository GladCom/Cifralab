import React from 'react';

const Item = ({ columns, data }) => {
    return (
        <div>
            {columns.map((c) => <span>{data[c.name]}</span>)}
        </div>
    );
};

export default Item;