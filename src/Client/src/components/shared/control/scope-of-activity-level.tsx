import { InputNumber } from 'antd';
import { ControlByModeMap, DisplayMode, FormParams } from './multi-mode-control/types';
import { Rule } from 'antd/es/form';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import { DefaultEditableViewControl, DefaultViewControl, MultiControlProps } from './multi-mode-control/default-controls';

const CommonEditorFormItemControl: React.FC<MultiControlProps> = ({ value, onChange, formParams }) => {
  if (!formParams) {
    throw new Error('CommonEditorFormItemControl: "formParams" is required but was not provided.');
  }

  const { key } = formParams;
  // Преобразуем значение в число
  const numericValue = value != null ? Number(value) : 1;

  return (
    <InputNumber
      key={key}
      min={1}
      max={2}
      defaultValue={numericValue}
      onChange={onChange}
      style={{ minWidth: '100px' }}
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
    message: 'Необходимо указать уровень',
  },
];

const formParams: FormParams = {
  key: 'level',
  name: 'Уровень сферы деятельности',
  rules: rules,
};

export const ScopeOfActivityLevel: React.FC<MultimodeControlProps> = (props) => {
  return <MultimodeControl {...props} controlMap={controlMap} formParams={formParams} />;
};
