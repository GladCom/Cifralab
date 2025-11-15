import { useState } from 'react';
import { Flex, Button } from 'antd';
import { PlusOutlined } from '@ant-design/icons';
import { AddOneForm } from '../catalog-provider/forms/add-one-form';

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
      <AddOneForm visibilityControl={{ showAddOneForm, setShowAddOneForm }} formModel={properties} crud={crud} />
    </>
  );
};

export default TablePageHeader;
