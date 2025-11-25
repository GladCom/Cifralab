import React, { useState } from 'react';
import { Flex, Button } from 'antd';
import { PlusOutlined } from '@ant-design/icons';
import AddOneForm from '../catalog-provider/forms/add-one-form';
import { SearchInput } from '../business/common/search-input';

const style = {
  height: '7vh',
  minHeight: '50px',
  padding: '1vh',
};

const TablePageHeader = ({ config, title, onSearch }) => {
  const { properties, crud, searchPlaceholder } = config;
  const [showAddOneForm, setShowAddOneForm] = useState(false);

  return (
    <>
      <Flex
        style={style}
        className="border-bottom border-primary"
        justify="space-between"
        align="center"
      >
        <h3 style={styles.title}>{title}</h3>

        <Flex justify="flex-end" align="center" gap={8}>
          {searchPlaceholder && (
            <SearchInput
              placeholder={searchPlaceholder}
              onSearch={onSearch}
            />
          )}
          <Button type="primary" onClick={() => setShowAddOneForm(true)}>
            <PlusOutlined />
            добавить
          </Button>
        </Flex>
      </Flex>

      <AddOneForm
        control={{ showAddOneForm, setShowAddOneForm }}
        properties={properties}
        crud={crud}
      />
    </>
  );
};

const styles = {
  title: {
    margin: '2vh',
    fontSize: '1.5rem',
    flex: 1,
  } as const,
};

export default TablePageHeader;
