import { InputNumber } from 'antd';
import { DefaultEditableViewControl, DefaultViewControl } from './multi-mode-control/default-controls';
import { ControlByModeMap, DisplayMode, MultiControlProps, FormParams } from './multi-mode-control/types';
import { Rule } from 'antd/es/form';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import _ from 'lodash';

const CommonEditorFormItemControl: React.FC<MultiControlProps> = ({ value, onChange, formParams }) => {
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
  const finalFormParams = _.merge(
    {},
    formParams, // база
    externalFormParams, // переопределения
  );

  return <MultimodeControl {...props} controlMap={controlMap} formParams={finalFormParams} />;
};
