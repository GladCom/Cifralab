import React from 'react';
import Button from 'react-bootstrap/Button';
import { CheckOutlined } from '@ant-design/icons';

const YesNoButtons = ({ setValue, onClick }) => (
  <>
    <Button
      className="m-1"
      variant="outline-success"
      size="sm"
      onClick={() => {
        setValue();
        onClick();
      }}
    >
      <CheckOutlined />
      Save
    </Button>
    <Button className="m-1" variant="outline-danger" size="sm" onClick={onClick}>
      Cancel
    </Button>
  </>
);

export default YesNoButtons;
