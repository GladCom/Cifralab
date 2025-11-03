import { InputNumber } from 'antd';
import { ControlByModeMap, DisplayMode, EditableControlProps, FormParams } from './multi-mode-control/types';
import { DefaultEditableViewControl, DefaultViewControl } from './multi-mode-control/default-controls';
import { Rule } from 'antd/es/form';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';

const CommonEditorFormItemControl: React.FC<EditableControlProps> = ({ value, onChange, formParams }) => {
  const { key } = formParams;

  // Преобразуем значение в число, обрабатывая null/undefined
  const numericValue = value != null ? Number(value) : undefined;

  return (
    <InputNumber
      key={key}
      min={1}
      max={1000000}
      prefix="₽"
      defaultValue={numericValue}
      onChange={onChange}
      style={{ minWidth: '150px' }}
    />
  );
};

const controlMap: ControlByModeMap = {
  [DisplayMode.VIEW]: DefaultViewControl,
  [DisplayMode.EDITABLE_VIEW]: DefaultEditableViewControl,
  [DisplayMode.EDITOR]: CommonEditorFormItemControl,
  [DisplayMode.FORM_ITEM]: CommonEditorFormItemControl,
};

const rules: Rule[] = [
  {
    required: true,
    message: 'Выберите значение',
  },
];

const formParams: FormParams = {
  key: 'cost!', //  Почему тут восклицательный знак?
  name: 'Стоимость',
  rules: rules,
};

export const Cost: React.FC<MultimodeControlProps> = (props) => {
  return <MultimodeControl {...props} controlMap={controlMap} formParams={formParams} />;
};
