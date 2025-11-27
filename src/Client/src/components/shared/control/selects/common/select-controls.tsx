import { Select } from 'antd';
import { MultiControlProps } from '../../multi-mode-control/default-controls';

export const EditorFormItemSelectControl: React.FC<MultiControlProps> = (props) => {
  const { defaultValue, onChange, placeholder, formParams, options } = props;

  if (!formParams) {
    throw Error('EditorFormItemSelectControl: formParams is required but not provided');
  }
  const { key } = formParams;

  const filterOption = (input: string, option?: { label?: any }) => {
    const label = String(option?.label ?? '');
    return label.toLowerCase().includes(input.toLowerCase());
  };

  return (
    <Select
      key={key}
      showSearch
      //  TODO: возможно как-то криво.
      //defaultValue={labelKey ? dataById?.[labelKey] : undefined}
      defaultValue={defaultValue}
      style={{ minWidth: '200px' }}
      placeholder={placeholder}
      filterOption={filterOption}
      onChange={onChange}
      options={options}
    />
  );
};
