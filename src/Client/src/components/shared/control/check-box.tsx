import { Checkbox, CheckboxChangeEvent } from 'antd';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import { ControlByModeMap, DisplayMode, EditableControlProps, FormParams, MultimodeControlValue } from './multi-mode-control/types';
import { ViewControlProps } from './multi-mode-control/default-controls';
import { Rule } from 'antd/es/form';
import { useCallback } from 'react';

const getSafeBoolean = (value: MultimodeControlValue): boolean => {
  if (typeof value === 'boolean') return value;

  console.warn(`Checkbox received non-boolean value:`, {
    value,
    type: typeof value
  });

  return false;
};

const ViewControl: React.FC<ViewControlProps> = ({ value }) => {
  return <Checkbox checked={getSafeBoolean(value)} disabled={true} />;
};

const CommonEditorFormItemControl: React.FC<EditableControlProps> = ({ value, onChange, formParams }) => {
  const { key } = formParams;

  const handleChange = useCallback((event: CheckboxChangeEvent) => {
    onChange(event.target.checked);
  }, [onChange]);

  return (
    <Checkbox
      key={key}
      defaultChecked={getSafeBoolean(value)}
      onChange={handleChange}
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
    message: 'Необходимо установить значение',
  },
];

const formParams: FormParams = {
  key: 'name',
  name: 'Да/Нет',
  rules,
};

export const CheckBox: React.FC<MultimodeControlProps> = (props) => (
  <MultimodeControl
    {...props}
    controlMap={controlMap}
    formParams={formParams}
  />
);
