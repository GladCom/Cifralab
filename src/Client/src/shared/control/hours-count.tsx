import { InputNumber } from 'antd';
import {
  DefaultEditableViewControl,
  DefaultViewControl,
  MultiControlProps,
} from './multi-mode-control/default-controls';
import { ControlByModeMap, DisplayMode, FormParams } from './multi-mode-control/types';
import { Rule } from 'antd/es/form';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import merge from 'lodash/merge';

const CommonEditorFormItemControl: React.FC<MultiControlProps> = ({ value, onChange, formParams }) => {
  if (!formParams) {
    throw new Error('CommonEditorFormItemControl: "formParams" is required but was not provided.');
  }

  const { key } = formParams;
  // Преобразуем значение в число, обрабатывая null/undefined
  const numericValue = value != null ? Number(value) : undefined;

  return (
    <InputNumber
      key={key}
      min={1}
      max={10000}
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
    message: 'Необходимо указать кол-во часов',
  },
];

const formParams: FormParams = {
  key: 'hoursCount',
  name: 'Кол-во часов',
  rules: rules,
};

export const HoursCount: React.FC<MultimodeControlProps> = (props) => {
  const { formParams: externalFormParams } = props;
  const finalFormParams = merge(
    {},
    formParams, // база
    externalFormParams, // переопределения
  );

  return <MultimodeControl {...props} controlMap={controlMap} formParams={finalFormParams} />;
};
