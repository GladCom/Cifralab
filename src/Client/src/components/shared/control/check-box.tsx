import { Checkbox, CheckboxChangeEvent } from 'antd';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import {
  ControlByModeMap,
  DisplayMode,
  MultiControlProps,
  FormParams,
  MultimodeControlValue,
} from './multi-mode-control/types';
// обьявлена 2 раза import { MultiControlProps } from './multi-mode-control/default-controls';
import { Rule } from 'antd/es/form';
import { useCallback } from 'react';
import _ from 'lodash';

const getSafeBoolean = (value: MultimodeControlValue): boolean => {
  if (typeof value === 'boolean') return value;
  // eslint-disable-next-line no-console
  console.warn('Checkbox received non-boolean value:', {
    value,
    type: typeof value,
  });

  return false;
};

const ViewControl: React.FC<MultiControlProps> = ({ value }) => {
  return <Checkbox checked={getSafeBoolean(value)} disabled={true} />;
};

const CommonEditorFormItemControl: React.FC<MultiControlProps> = ({ value, onChange, formParams }) => {
  const { key } = formParams;

  const handleChange = useCallback(
    (event: CheckboxChangeEvent) => {
      onChange(event.target.checked);
    },
    [onChange],
  );

  return <Checkbox key={key} defaultChecked={getSafeBoolean(value)} onChange={handleChange} />;
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
  key: 'CheckBoxKey!',
  name: 'Да/Нет',
  rules,
};

export const CheckBox: React.FC<MultimodeControlProps> = (props) => {
  const { formParams: externalFormParams } = props;
  const finalFormParams = _.merge(
    {},
    formParams, // база
    externalFormParams, // переопределения
  );
  return <MultimodeControl {...props} value={false} controlMap={controlMap} formParams={finalFormParams} />;
};
