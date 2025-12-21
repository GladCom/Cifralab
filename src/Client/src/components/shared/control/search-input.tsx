import { Input } from 'antd';
import { SearchOutlined } from '@ant-design/icons';

export interface SearchInputProps {
  placeholder?: string;
  onSearch?: (value: string) => void;
}

export const SearchInput: React.FC<SearchInputProps> = ({ placeholder = 'Поиск...', onSearch }) => {
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const newValue = e.target.value;
    onSearch?.(newValue);
  };

  return <Input placeholder={placeholder} prefix={<SearchOutlined />} onChange={handleChange} allowClear />;
};
