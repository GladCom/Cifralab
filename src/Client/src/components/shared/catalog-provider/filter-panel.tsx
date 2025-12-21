import { Flex, Select } from 'antd';

const style: React.CSSProperties = {
  height: '10vh',
  padding: '10px',
};

interface Filter {
  key: string;
  // TODO: возможно это должно быть DtoKeys
  backendKey: string;
  label: string;
  placeholder?: string;
  // TODO: пока что это не UseQueryHook. Разобраться и уточнить тип.
  // Проблема решиться когда перейдем с RTK Query на React Query
  useQuery: UseQueryHook | unknown;
  mapOptions?: (data: unknown) => SelectOption[];
}

interface UseQueryResult<T = unknown> {
  data: T;
  isLoading: boolean;
}

interface SelectOption {
  value: string | number;
  label: string;
}

export interface Query {
  [key: string]: string | number | undefined;
}

export interface FilterConfig {
  filters?: Filter[];
}

type UseQueryHook = (params?: Record<string, unknown>) => UseQueryResult;

export type FilterSelectProps = {
  filter: Filter;
  query: Query;
  setQuery: React.Dispatch<React.SetStateAction<Query>>;
};

const FilterSelect: React.FC<FilterSelectProps> = ({ filter, query, setQuery }) => {
  const { backendKey, label, placeholder, useQuery, mapOptions } = filter;
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
      filterOption={(input, option) => (option?.label ?? '').toLowerCase().includes(input.toLowerCase())}
      options={options}
    />
  );
};

export type FilterPanelProps = {
  config?: FilterConfig;
  query: Query;
  setQuery: React.Dispatch<React.SetStateAction<Query>>;
};

const FilterPanel: React.FC<FilterPanelProps> = ({ config, query, setQuery }) => {
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
