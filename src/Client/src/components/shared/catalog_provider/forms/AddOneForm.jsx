import React, { useState, useCallback, useMemo, useEffect } from 'react';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Modal from 'react-bootstrap/Modal';
import InputGroup from 'react-bootstrap/InputGroup';
import Stack from 'react-bootstrap/Stack';

const RequiredSymbol = () => {
  return <span className="text-danger">* </span>;
};

const AddOneForm = ({ show, properties, addOneAsync }) => {
  const [entity, setEntity] = useState({});
  const [ addOne, { error, isLoading } ] = addOneAsync();

  const onSubmitHandle = (e) => {
      e.preventDefault();
      addOne(entity);
      show(false);
  };

  return (
    <Modal show={true} size="lg" centered onHide={() => show(false)}>
      <Form onSubmit={onSubmitHandle}>
        <Modal.Header closeButton>
          <Modal.Title>Добавление новой записи</Modal.Title>
        </Modal.Header>
        <Modal.Body>
            {Object.entries(properties).map(([key, { name, type, show, required }]) => {
              const Input = type;

              return show && (
                <InputGroup hasValidation>
                  <Form.Group as={Stack} className="mb-3" controlId={key} key={key} direction="horizontal" gap={1}>
                    <div>
                      <Form.Label className="mb-0">{required && <RequiredSymbol />}{name}:</Form.Label>
                    </div>
                    <div>
                      <Form.Control
                        as={Input}
                        initValue=''
                        required={required}
                        isInvalid={entity[key] === ''}
                        formMode={true}
                        setValue={(value) => setEntity({ ...entity, [key]: value })}
                      />
                    </div>
                  </Form.Group>
                </InputGroup>
              );
            })}
        </Modal.Body>
        <Modal.Footer>
          <Button type="submit" variant="primary m-3">
            Добавить
          </Button>
          <Button variant="secondary m-3" onClick={() => show(false)}>
            Отмена
          </Button>
        </Modal.Footer>
      </Form>
    </Modal>
  );
};

export default AddOneForm;