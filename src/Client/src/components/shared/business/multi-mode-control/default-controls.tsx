import { Input, Typography } from 'antd';
import { BaseControlValue, ControlByModeMap as ControlByModeMap, DisplayMode, FormParams } from './types';

const { Text } = Typography;

export type MultiControlProps = ViewControlProps | EditableViewControlProps | EditorControlProps | FormItemControlProps;

export type ViewControlProps = {
  value: BaseControlValue;
};

export const DefaultViewControl: React.FC<ViewControlProps> = ({ value }) => <Text>{value}</Text>;

export type EditableViewControlProps = {
  value: BaseControlValue;
};

export const DefaultEditableViewControl: React.FC<EditableViewControlProps> = ({ value }) => <Text>{value}</Text>;

export type EditorControlProps = {
  value: BaseControlValue;
  defaultValue: BaseControlValue;
  placeholder: string;
  formParams: FormParams;
  onChange: () => void;
};

export const DefaultEditorControl: React.FC<EditorControlProps> = ({
  value,
  onChange,
  defaultValue,
  formParams,
  placeholder,
}) => {
  const { key } = formParams;

  return (
    <Input
      key={key}
      allowClear
      value={value}
      onChange={onChange}
      defaultValue={defaultValue}
      placeholder={placeholder}
      type="textarea"
    />
  );
};

export type FormItemControlProps = {
  value: BaseControlValue;
  placeholder: string;
  formParams: FormParams;
  onChange: () => void;
};

export const DefaultFormItemControl: React.FC<FormItemControlProps> = ({
  value,
  onChange,
  formParams,
  placeholder,
}) => {
  const { key } = formParams;

  return (
    <Input
      key={key}
      allowClear
      value={value}
      onChange={onChange}
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
