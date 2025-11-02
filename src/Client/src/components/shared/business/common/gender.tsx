import { Select, Typography } from 'antd';
import { ControlByModeMap, DisplayMode, EditableControlProps, FormParams } from '../multi-mode-control/types';
import { Rule } from 'antd/es/form';
import { MultimodeControl, MultimodeControlProps } from '../multi-mode-control/multi-mode-control';
import { ViewControlProps } from '../multi-mode-control/default-controls';

const { Text } = Typography;

const options = [
  { value: 0, label: 'мужской' },
  { value: 1, label: 'женский' },
];

const keyValueMap: Record<string, string> = {
  0: 'муж.',
  1: 'жен.',
  '': 'Выберите пол',
};

const ViewControl: React.FC<ViewControlProps> = ({ value }) => <Text>{keyValueMap[String(value ?? '')]}</Text>;

const CommonEditorFormItemControl: React.FC<EditableControlProps> = ({ value, onChange, formParams, placeholder }) => {
  const { key } = formParams;

  return (
    <Select
      key={key}
      defaultValue={value}
      variant="filled"
      placeholder={placeholder}
      options={options}
      onChange={onChange}
    />
  );
};

const controlMap: ControlByModeMap = {
  [DisplayMode.VIEW]: ViewControl,
  [DisplayMode.EDITABLE_VIEW]: ViewControl, // Хммм, почему TS не заругался?
  [DisplayMode.EDITOR]: CommonEditorFormItemControl,
  [DisplayMode.FORM_ITEM]: CommonEditorFormItemControl,
};

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо выбрать пол',
  },
];

const formParams: FormParams = {
  key: 'gender',
  name: 'Пол',
  rules: rules,
};

export const Gender: React.FC<MultimodeControlProps> = (props) => (
  <MultimodeControl
    {...props}
    placeholder={'Выберите пол'}
    controlMap={controlMap}
    formParams={formParams}
  />
);
