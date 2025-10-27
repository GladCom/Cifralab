import { Input, Typography } from 'antd';
import { IControlByMode, MultimodeControl } from './types';
const { Text } = Typography;

const DefaultViewControl: React.FC<MultimodeControl> = ({ value }) => <Text>{value}</Text>;

const DefaultEditableViewControl: React.FC<MultimodeControl> = ({ value }) => <Text>{value}</Text>;

const DefaultEditorControl: React.FC<MultimodeControl> = ({
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

const DefaultFormItemControl: React.FC<MultimodeControl> = ({ value, onChange, formParams, placeholder }) => {
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

const defaultControlByMode: IControlByMode = {
  view: DefaultViewControl,
  editableView: DefaultEditableViewControl,
  formItem: DefaultFormItemControl,
  editor: DefaultEditorControl,
};

export default defaultControlByMode;
