import React from 'react';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import overlayStyle from './overlayStyle.js';

const formStyle = {
  width: '500px',
  height: '500px',
};

const AddOneForm = ({ show }) => {
  return (
    <div style={overlayStyle}>
      <Form className="border rounded bg-white">
        <Button variant="primary m-3" type="submit">
          Добавить
        </Button>
        <Button variant="secondary m-3" onClick={() => show(false)}>
          Отмена
        </Button>
      </Form>
    </div>
  );
};

export default AddOneForm;