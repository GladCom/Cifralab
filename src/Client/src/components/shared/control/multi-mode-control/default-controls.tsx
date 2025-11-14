import { Input, Typography } from 'antd';
import { MultimodeControlValue, ControlByModeMap, DisplayMode, EditableControlProps } from './types';
import { ChangeEvent, useCallback } from 'react';

const { Text } = Typography;

export type MultiControlProps = ViewControlProps | EditableViewControlProps | EditableControlProps;

export type ViewControlProps = {
  value: MultimodeControlValue;
};

export const DefaultViewControl: React.FC<ViewControlProps> = ({ value }) => <Text>{value}</Text>;

export type EditableViewControlProps = {
  value: MultimodeControlValue;
};

export const DefaultEditableViewControl: React.FC<EditableViewControlProps> = ({ value }) => <Text>{value}</Text>;

export const DefaultEditorControl: React.FC<EditableControlProps> = ({
  value,
  onChange,
  defaultValue,
  formParams,
  placeholder,
}) => {
  const { key } = formParams;

  const handleChange = useCallback(
    (event: ChangeEvent<HTMLInputElement>) => {
      onChange(event.target.checked);
    },
    [onChange],
  );

  return (
    <Input
      key={key}
      allowClear
      value={String(value ?? 'Неверный тип данных')}
      onChange={handleChange}
      defaultValue={String(defaultValue ?? 'Неверный тип данных')}
      placeholder={placeholder}
      type="textarea"
    />
  );
};

export const DefaultFormItemControl: React.FC<EditableControlProps> = ({
  value,
  onChange,
  formParams,
  placeholder,
}) => {
  const { key } = formParams;

  const handleChange = useCallback(
    (event: ChangeEvent<HTMLInputElement>) => {
      onChange(event.target.value);
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
