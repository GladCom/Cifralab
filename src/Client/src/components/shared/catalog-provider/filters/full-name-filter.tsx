import React from 'react';
import { Input, Space } from 'antd';
import { SearchOutlined } from '@ant-design/icons';

const FullNameFilter = ({ name, query, setQuery }) => {
  return (
    <>
      <Space>
        <Input
          placeholder="ФИО"
          suffix={<SearchOutlined />}
          onChange={({ target }) => {
            const { value } = target;
            setQuery({ ...query, [name]: value });
          }}
        />
      </Space>
    </>
  );
};

export default FullNameFilter;
