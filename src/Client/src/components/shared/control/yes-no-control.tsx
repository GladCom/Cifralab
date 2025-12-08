import { useEffect } from 'react';
import { Switch, Typography } from 'antd';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import { ControlByModeMap, DisplayMode, FormParams } from './multi-mode-control/types';
import { Rule } from 'antd/es/form';
import merge from 'lodash/merge';
import { MultiControlProps } from './multi-mode-control/default-controls';

const { Text } = Typography;
const keyValueMap: Record<string, string> = {
  false: 'нет',
  true: 'да',
  null: 'не указано',
  undefined: 'не указано',
};

const ViewControl: React.FC<MultiControlProps> = ({ value }) => {
  const stringValue = String(value ?? 'null');
  return <Text>{keyValueMap[stringValue] || 'не указано'}</Text>;
};

const CommonEditorFormItemControl: React.FC<MultiControlProps> = ({ value, onChange, formParams }) => {
  if (!formParams) {
    throw new Error('CommonEditorFormItemControl: "formParams" is required but was not provided.');
  }

  const { key } = formParams;

  //  Эффект нужен чтобы проинициализировать начальным значением
  useEffect(() => {
    onChange(value || false);
  }, [onChange, value]);

  return <Switch key={key} defaultValue={Boolean(value)} onChange={onChange} defaultChecked={Boolean(value)} />;
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
    message: 'Выберите значение',
  },
];

const formParams: FormParams = {
  key: 'ошибка!',
  name: 'Да/Нет',
  rules: rules,
};

export const YesNoControl: React.FC<MultimodeControlProps> = (props) => {
  const { formParams: externalFormParams } = props;
  const finalFormParams = merge(
    {},
    formParams, // база
    externalFormParams, // переопределения
  );

  return <MultimodeControl {...props} controlMap={controlMap} formParams={finalFormParams} />;
};
