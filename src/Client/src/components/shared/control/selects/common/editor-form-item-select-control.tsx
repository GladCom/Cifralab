import { Select } from 'antd';
import { EditableControlProps } from '../../multi-mode-control/types';
import { useMemo } from 'react';

type EditorFormItemSelectControlProps = EditableControlProps & {
  crud: any;
};

export const EditorFormItemSelectControl: React.FC<EditorFormItemSelectControlProps> = (props) => {
  const { value, onChange, placeholder, formParams, crud } = props;
  const { key, labelKey } = formParams;
  const { useGetOneByIdAsync, useGetAllAsync } = crud;
  const { data: dataById } = useGetOneByIdAsync(value);
  const { data: allData } = useGetAllAsync();

  const options = useMemo(() => {
    if (!labelKey) {
      console.error('EditorFormItemSelectControl: labelKey is required but not provided');
      return [];
    }

    //  TODO: добавить типизацию для d.
    return (allData || []).map((d) => ({
      value: d.id,
      label: String(d[labelKey] ?? ''),
    }));
  }, [allData, labelKey]);

  const filterOption = (input: string, option?: { label?: any }) => {
    const label = String(option?.label ?? '');
    return label.toLowerCase().includes(input.toLowerCase());
  };

  return (
    <Select
      key={key}
      showSearch
      //  TODO: возможно как-то криво.
      defaultValue={labelKey ? dataById?.[labelKey] : undefined}
      style={{ minWidth: '200px' }}
      placeholder={placeholder}
      filterOption={filterOption}
      onChange={onChange}
      options={options}
    />
  );
};
