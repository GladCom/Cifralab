import { Input, Typography } from 'antd';
import { MultimodeControlValue, ControlByModeMap, DisplayMode, FormParams } from './types';
import { ChangeEvent, useCallback } from 'react';

const { Text } = Typography;

export type MultiControlProps = {
  value: MultimodeControlValue;
  defaultValue?: MultimodeControlValue;
  placeholder?: string;
  formParams?: FormParams;
  crud?: unknown;
  options?: unknown;
  //  TODO: a точно ли тут надо передавать значение а не событие?
  onChange?: (value: MultimodeControlValue) => void;
  setValue?: (value: MultimodeControlValue) => void;
};

export const DefaultViewControl: React.FC<MultiControlProps> = ({ value }) => <Text>{value}</Text>;

export const DefaultEditableViewControl: React.FC<MultiControlProps> = ({ value }) => <Text>{value}</Text>;

export const DefaultEditorControl: React.FC<MultiControlProps> = ({ value, onChange, defaultValue, placeholder }) => {
  const handleChange = useCallback(
    (event: ChangeEvent<HTMLInputElement>) => {
      onChange && onChange(event.target.value);
    },
    [onChange],
  );

  return (
    <Input
      allowClear
      value={String(value ?? '')}
      onChange={handleChange}
      defaultValue={String(defaultValue ?? '')}
      placeholder={placeholder}
      type="textarea"
    />
  );
};

export const DefaultFormItemControl: React.FC<MultiControlProps> = ({ value, onChange, formParams, placeholder }) => {
  if (!formParams) {
    throw Error('EditorFormItemSelectControl: formParams is required but not provided');
  }

  const { key } = formParams;

  const handleChange = useCallback(
    (event: ChangeEvent<HTMLInputElement>) => {
      onChange && onChange(event.target.value);
    },
    [onChange],
  );

  return (
    <Input
      key={key}
      allowClear
      value={String(value ?? '')}
      onChange={handleChange}
      defaultValue=""
      placeholder={placeholder}
      type="textarea"
    />
  );
};

export const defaultControlByModeMap: ControlByModeMap = {
  [DisplayMode.VIEW]: DefaultViewControl,
  [DisplayMode.EDITABLE_VIEW]: DefaultEditableViewControl,
  [DisplayMode.EDITOR]: DefaultEditorControl,
  [DisplayMode.FORM_ITEM]: DefaultFormItemControl,
};
