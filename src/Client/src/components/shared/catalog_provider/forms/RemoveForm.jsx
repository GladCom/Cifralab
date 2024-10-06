import React, { useRef, useEffect } from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import Error from '../../Error.jsx';


const RemoveForm = ({ show, validate, queryState, refetch }) => {

    const { isSuccess, isError, error } = queryState;

    // useEffect(() => {
    //     if(isSuccess) {
    //         show(false);
    //         refetch();
    //     }
    //     console.log(isSuccess)
    // },[isSuccess]);

    const handleClose = () => {
        show(false);
    };

    return (
        <>
            {isError && <Error e={error} />}
            <Modal show={true} onHide={handleClose} centered>
                <Modal.Header closeButton>
                    <Modal.Title>Внимание!</Modal.Title>
                </Modal.Header>
                <Modal.Body>Вы уверены, что хотите удалить запись?</Modal.Body>
                <Modal.Footer>
                    <Button variant="danger m-3" type="submit" onClick={() => {
                        validate();
                        show(false);
                    }}>
                        Удалить
                    </Button>
                    <Button variant="secondary m-3" onClick={handleClose}>
                        Отмена
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
};

export default RemoveForm;