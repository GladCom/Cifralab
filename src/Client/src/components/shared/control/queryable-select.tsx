import { Typography, Select } from 'antd';
import { ControlByModeMap, DisplayMode, EditableControlProps, FormParams } from './multi-mode-control/types';
import { Rule } from 'antd/es/form';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import { ViewControlProps } from './multi-mode-control/default-controls';

const { Text } = Typography;

const ViewControl: React.FC<ViewControlProps> = ({ dataById, formParams }) => {
  const { labelKey } = formParams;

  return <Text>{dataById?.[labelKey]}</Text>;
};

const CommonEditorFormItemControl: React.FC<EditableControlProps> = ({ onChange, placeholder, formParams, dataById, allData }) => {
  const { key, labelKey } = formParams;

  return (
    <Select
      key={key}
      showSearch
      defaultValue={dataById?.[labelKey]}
      style={{ minWidth: '200px' }}
      placeholder={placeholder}
      filterOption={(input, option) => (option?.label ?? '').toLowerCase().includes(input.toLowerCase())}
      onChange={onChange}
      options={(allData || []).map((d) => ({
        value: d.id,
        label: d[labelKey],
      }))}
    />
  );
};

const controlMap: ControlByModeMap = {
  [DisplayMode.VIEW]: ViewControl,
  [DisplayMode.EDITABLE_VIEW]: ViewControl,
  [DisplayMode.EDITOR]: CommonEditorFormItemControl,
  [DisplayMode.FORM_ITEM]: CommonEditorFormItemControl,
};

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо выбрать значение',
  },
];

const formParams: FormParams = {
  key: 'defaultKey!',
  labelKey: 'name',
  name: 'Какой-то список',
  rules,
};

export const QueryableSelect: React.FC<MultimodeControlProps> = (props) => {
  return <MultimodeControl {...props} placeholder={'Выберите значение'} controlMap={controlMap} formParams={formParams} />;
};
