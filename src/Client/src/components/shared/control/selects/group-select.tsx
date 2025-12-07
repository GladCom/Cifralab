import { Rule } from 'antd/es/form';
import config from '../../../../storage/catalog-config/group';
import { ControlByModeMap, ControlWrapperByModeMap, DisplayMode, FormParams } from '../multi-mode-control/types';
import { QueryableSelectControl } from './common/queryable-select-control';
import { Select } from 'antd';
import { MultimodeControlProps } from '../multi-mode-control/multi-mode-control';
import { MultiControlProps } from '../multi-mode-control/default-controls';

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const formParams: FormParams = {
  key: 'GroupSelectKey',
  labelKey: 'name',
  name: 'Группы',
  rules,
};

export const MultiSelectEditorControl: React.FC<MultiControlProps> = ({ value, onChange, placeholder, options, setValue}) => {

    const handleChange = (newValue: any) => {
        if (onChange) {
            onChange(newValue);
        }
        if (setValue) {
            setValue(newValue);
        }
    };

  return (
    <Select
      mode="multiple"
      allowClear
      showSearch
      style={{ minWidth: 200, width: '100%' }}
      placeholder={placeholder}
      value={value}
      onChange={handleChange}
      options={options}
      filterOption={(input, option) => (option?.label ?? '').toLowerCase().includes(input.toLowerCase())}
    />
  );
};

const controlMap: ControlByModeMap = {
  [DisplayMode.VIEW]: MultiSelectEditorControl,
  [DisplayMode.EDITABLE_VIEW]: MultiSelectEditorControl,
  [DisplayMode.EDITOR]: MultiSelectEditorControl,
  [DisplayMode.FORM_ITEM]: MultiSelectEditorControl,
};

export const GroupMultiSelect: React.FC<MultimodeControlProps> = (props) => {
  const { crud } = config;
  const { formParams: externalFormParams } = props;
  const finalFormParams = _.merge(
    {},
    formParams, // база
    externalFormParams, // переопределения
  );

  return  <QueryableSelectControl
      {...props}
      crud={crud}
      controlMap={controlMap}
      formParams={finalFormParams}
  />;
};
