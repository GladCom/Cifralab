import React, { useMemo, useState } from 'react';
import { Button, Flex, Select, Space } from 'antd';

const containerStyle = {
  padding: '12px 20px',
  minHeight: '60px',
};

const isEmptyValue = (value) => {
  if (value === undefined || value === null) {
    return true;
  }

  if (typeof value === 'string') {
    return value.trim() === '';
  }

  if (Array.isArray(value)) {
    return value.length === 0;
  }

  return false;
};

const FilterPanel = ({ config, setQuery }) => {
  const filters = useMemo(() => config?.filters ?? [], [config?.filters]);
  const [values, setValues] = useState({});

  const buildFilterPayload = (nextValues) => {
    return filters.reduce((acc, filter) => {
      const { key, backendKey, transformValue } = filter;
      const currentValue = nextValues[key];

      if (isEmptyValue(currentValue)) {
        return acc;
      }

      const normalizedValue = transformValue ? transformValue(currentValue) : currentValue;

      if (!isEmptyValue(normalizedValue)) {
        acc[backendKey] = normalizedValue;
      }

      return acc;
    }, {});
  };

  const applyFilters = (nextState) => {
    const payload = buildFilterPayload(nextState);

    if (Object.keys(payload).length === 0) {
      setQuery({});
      return;
    }

    setQuery({
      filterString: JSON.stringify(payload),
    });
  };

  const handleChange = (key, value) => {
    setValues((prev) => {
      const next = { ...prev };

      if (isEmptyValue(value)) {
        delete next[key];
      } else {
        next[key] = value;
      }

      applyFilters(next);
      return next;
    });
  };

  const handleReset = () => {
    setValues({});
    setQuery({});
  };

  if (filters.length === 0) {
    return null;
  }

  return (
    <Flex style={containerStyle} className="border-bottom border-primary" align="center" gap={16}>
      <Space wrap>
        {filters.map(({ key, label, placeholder, useQuery, mapOptions, mode, allowClear = true }) => {
          const { data, isLoading, isFetching } = useQuery();
          const options = mapOptions ? mapOptions(data) : data ?? [];

          return (
            <Select
              key={key}
              style={{ minWidth: 220 }}
              placeholder={placeholder ?? label}
              loading={isLoading || isFetching}
              value={values[key]}
              allowClear={allowClear}
              options={options}
              onChange={(value) => handleChange(key, value)}
              mode={mode}
              optionFilterProp="label"
              showSearch
            />
          );
        })}
      </Space>
      <Button onClick={handleReset} disabled={Object.keys(values).length === 0}>
        Сбросить
      </Button>
    </Flex>
  );
};

export default FilterPanel;
