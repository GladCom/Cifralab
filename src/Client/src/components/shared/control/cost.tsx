import { InputNumber } from 'antd';
import { ControlByModeMap, DisplayMode, FormParams } from './multi-mode-control/types';
import {
  DefaultEditableViewControl,
  DefaultViewControl,
  MultiControlProps,
} from './multi-mode-control/default-controls';
import { Rule } from 'antd/es/form';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import merge from 'lodash/merge';

const CommonEditorFormItemControl: React.FC<MultiControlProps> = ({ value, onChange, formParams }) => {
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
  const { formParams: externalFormParams } = props;
  const finalFormParams = merge(
    {},
    formParams, // база
    externalFormParams, // переопределения
  );

  return <MultimodeControl {...props} controlMap={controlMap} formParams={finalFormParams} />;
};
