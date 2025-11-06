import React, { useState } from 'react';
import { Input } from 'antd';
import { SearchOutlined } from '@ant-design/icons';

export interface SearchInputProps {
  placeholder?: string;
  onSearch?: (value: string) => void;
  width?: number;
}

export const SearchInput: React.FC<SearchInputProps> = ({
  placeholder = 'Поиск...',
  onSearch,
  width = 280,
}) => {
  const [value, setValue] = useState('');

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const newValue = e.target.value;
    setValue(newValue);
    onSearch?.(newValue);
  };

  return (
    <Input
      value={value}
      placeholder={placeholder}
      prefix={<SearchOutlined />}
      onChange={handleChange}
      style={{ width }}
      allowClear
    />
  );
};
