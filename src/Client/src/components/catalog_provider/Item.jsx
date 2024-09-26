import React from 'react';
import Button from 'react-bootstrap/Button'

const Item = ({ columns, data, setItem, showDialog }) => {
    const { id } = data;
    return (
        <div className="row border-bottom" key={id}>
            {columns.map((c) => (
                <div className={c.className}>
                    <span>{data[c.name]}</span>
                </div>
            ))}
            <div className="col-1 ms-auto">
                <Button
                    variant="outline-danger"
                    onClick={() => {
                        setItem(id);
                        showDialog(true);
                    }}
                >
                    Удалить
                </Button>
            </div>
        </div>
    );
};

export default Item;