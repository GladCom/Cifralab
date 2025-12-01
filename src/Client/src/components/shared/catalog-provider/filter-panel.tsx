import { Flex, Select } from 'antd';
import { FilterSelectProps, FilterPanelProps } from './filters/filter';

const style = {
  height: '10vh',  
  padding: '10px',
};

const FilterSelect = ({ filter, query, setQuery }: FilterSelectProps) => {
  const { key, backendKey, label, placeholder, useQuery, mapOptions } = filter;
  const { data, isLoading } = useQuery({});
  const options = mapOptions ? mapOptions(data) : [];
  const currentValue = query[backendKey];

  const handleChange = (value: string | number | undefined) => {
    setQuery((prevQuery) => {
      const newQuery = { ...prevQuery };
      if (value === undefined || value === null || value === '') {
        delete newQuery[backendKey];
      } else {
        newQuery[backendKey] = value;
      }
      return newQuery;
    });
  };

  return (
    <Select
      showSearch
      style={{ minWidth: '200px' }}
      placeholder={placeholder || label}
      value={currentValue}
      onChange={handleChange}
      loading={isLoading}
      allowClear
      filterOption={(input, option) =>
        (option?.label ?? '').toLowerCase().includes(input.toLowerCase())
      }
      options={options}
    />
  );
};

const FilterPanel = ({ config, query, setQuery }: FilterPanelProps) => {
  const { filters } = config || {};

  if (!filters || filters.length === 0) {
    return null;
  }

  return (
    <Flex style={style} className="border-bottom border-primary" gap="middle" wrap="wrap">
      {filters.map((filter) => (
        <Flex key={filter.key} vertical gap="small">
          <span style={{ fontSize: '12px', fontWeight: '500' }}>{filter.label}</span>
          <FilterSelect filter={filter} query={query} setQuery={setQuery} />
        </Flex>
      ))}
    </Flex>
  );
};

export default FilterPanel;
