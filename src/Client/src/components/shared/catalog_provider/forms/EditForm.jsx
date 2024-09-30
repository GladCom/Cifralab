import React, { useState, useEffect } from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import Error from '../../Error.jsx';
import Spinner from '../../Spinner.jsx';
import Empty from '../../Empty.jsx';


const EditForm = ({ id, show, properties, getOneByIdAsync, editOneAsync, refetch }) => {
    const [itemData, setItemData] = useState({});
    const { data, error, isLoading, isFetching } = getOneByIdAsync(id);

    const [
        editItem,
        { error: editItemError, isLoading: isEdittingItem },
      ] = editOneAsync();

    const handleClose = () => {
        show(false);
    };

    useEffect(() => {
        if (!isLoading && !isFetching) {
            const newData = { ...data };
            delete newData.id;
            setItemData(newData);
        }
    }, [isLoading, isFetching]);

    if (isLoading || isFetching) {
        return (
            <>
                <Spinner />
                <Empty />
            </>
        );
    }

    if (error) {
        return <Error e={error} />;
    }

    return (
        <Modal show={true} onHide={handleClose} centered>
            <Modal.Header closeButton>
                <Modal.Title>Правка</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                {
                    Object.entries(properties).map(([key, { name, type, show, required }]) => {
                        const Input = type;
                        return show && (
                            <>
                                <div>{name}</div>
                                <Input
                                    key={key}
                                    initValue={itemData[key]}
                                    editable={true}
                                    required={required}
                                    setValue={(value) => {
                                        setItemData({ ...itemData, [key]: value })
                                    }}
                                />
                            </>
                        );
                    })
                }
            </Modal.Body>
            <Modal.Footer>
                <Button variant="success m-3" type="submit" onClick={() => {
                    editItem({ id, item: itemData });
                    show(false);
                    refetch();
                }}>
                    Править
                </Button>
                <Button variant="secondary m-3" onClick={handleClose}>
                    Отмена
                </Button>
            </Modal.Footer>
        </Modal>
    );
};

export default EditForm;