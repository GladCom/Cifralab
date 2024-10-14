import React, { useRef, useEffect } from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';


const RemoveForm = ({ item, control, config, refetch }) => {
    const { showRemoveForm, setShowRemoveForm } = control;

    const handleClose = () => {
        setShowRemoveForm(false);
    };

    return (
        <>
            <Modal show={showRemoveForm} onHide={handleClose} centered>
                <Modal.Header closeButton>
                    <Modal.Title>Внимание!</Modal.Title>
                </Modal.Header>
                <Modal.Body>Вы уверены, что хотите удалить запись?</Modal.Body>
                <Modal.Footer>
                    <Button variant="danger m-3" type="submit" onClick={() => {

                        setShowRemoveForm(false);
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