import { Select, Typography } from 'antd';
import { ViewControlProps } from '../multi-mode-control/default-controls';
import { ControlByModeMap, DisplayMode, EditableControlProps, FormParams } from '../multi-mode-control/types';
import { Rule } from 'antd/es/form';
import { MultimodeControl, MultimodeControlProps } from '../multi-mode-control/multi-mode-control';

const { Text } = Typography;

const options = [
  { value: 0, label: 'Не сдано' },
  { value: 1, label: 'Тестовое задание' },
  { value: 2, label: 'Собеседование' },
  { value: 3, label: 'Выполнено' },
];

const keyValueMap = {
  0: 'Не сдано',
  1: 'Тестовое задание',
  2: 'Собеседование',
  3: 'Выполнено',
};

const ViewControl: React.FC<ViewControlProps> = ({ value }) => <Text>{keyValueMap[value]}</Text>;

const CommonEditorFormItemControl: React.FC<EditableControlProps> = ({ value, onChange, formParams }) => {
  const { key } = formParams;

  return <Select key={key} defaultValue={value} style={{ minWidth: '200px' }} options={options} onChange={onChange} />;
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
    message: 'Необходимо заполнить это поле',
  },
];

const formParams: FormParams = {
  key: 'StatusEntrancExamsSelectKey!',
  labelKey: 'statusEntrancExams',
  name: 'Выберите значение',
  rules,
};

export const StatusEntrancExamsSelect: React.FC<MultimodeControlProps> = (props) => {
  return <MultimodeControl {...props} controlMap={controlMap} formParams={formParams} />;
};
