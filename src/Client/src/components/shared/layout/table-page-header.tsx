import { useState } from 'react';
import { Flex, Button } from 'antd';
import { PlusOutlined } from '@ant-design/icons';
import { AddOneForm } from '../catalog-provider/forms/add-one-form';
import { SearchInput } from '../control/search-input';
import { EntityTableConfig } from './entity-table';
import Spinner from './spinner';

const containerStyle = {
  height: '7vh',
  minHeight: '50px',
  padding: '1vh',
};

const headerStyle = {
  title: {
    margin: '2vh',
    fontSize: '1.5rem',
    flex: 1,
  } as const,
};

type TablePageHeaderProps = {
  config: EntityTableConfig;
  title: string;
  // TODO: уточнить типизацию
  onSearch?: (value: unknown) => void;
};

export const TablePageHeader: React.FC<TablePageHeaderProps> = ({ config, title, onSearch }) => {
  const { formModel, crud, searchPlaceholder } = config;
  const [showAddOneForm, setShowAddOneForm] = useState(false);

  if (!formModel) {
    return <Spinner />;
  }

  return (
    <>
      <Flex style={containerStyle} className="border-bottom border-primary" justify="space-between" align="center">
        <h3 style={headerStyle.title}>{title}</h3>

        <Flex justify="flex-end" align="center" gap={8}>
          {searchPlaceholder && <SearchInput placeholder={searchPlaceholder} onSearch={onSearch} />}
          <Button type="primary" onClick={() => setShowAddOneForm(true)}>
            <PlusOutlined />
            добавить
          </Button>
        </Flex>
      </Flex>
      <AddOneForm visibilityControl={{ showAddOneForm, setShowAddOneForm }} formModel={formModel} crud={crud} />
    </>
  );
};
