import React, { useState, useEffect, useCallback } from 'react';
import { Flex, Button } from 'antd';
import { PlusOutlined } from '@ant-design/icons';
import AddOneForm from '../catalogProvider/forms/AddOneForm.jsx';

const style = {
  height: '7vh',
  minHeight: '50px',
  padding: '1vh',
};

const TablePageHeader = ({ config, title }) => {
  const { properties, crud } = config;
  const [showAddOneForm, setShowAddOneForm] = useState(false);

  return (
    <>
      <Flex style={style} className="border-bottom border-primary">
        <Flex justify="left" align="center" style={{ width: '90%' }}>
          <h3 style={{ margin: '2vh', fontSize: '1.5rem' }}>{title}</h3>
        </Flex>
        <Flex justify="center" align="center" style={{ width: '10%' }}>
          <Button type="primary" onClick={() => setShowAddOneForm(true)}>
            <PlusOutlined />
            добавить
          </Button>
        </Flex>
      </Flex>
      <AddOneForm control={{ showAddOneForm, setShowAddOneForm }} properties={properties} crud={crud} />
    </>
  );
};

export default TablePageHeader;
