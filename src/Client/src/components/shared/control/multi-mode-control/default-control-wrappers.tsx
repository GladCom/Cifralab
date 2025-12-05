import { Typography, Form, Button, Space } from 'antd';
import { EditOutlined } from '@ant-design/icons';
import {
  MultimodeControlValue,
  ControlWrapperByModeMap,
  DisplayMode,
  ControlByModeMap,
  BaseControlParams,
  FormParams,
} from './types';
import { ComponentType } from 'react';
import { MultiControlProps } from './default-controls';

const { Text } = Typography;
export const ChangeSymbol = () => <Text>* </Text>;

export type MultimodeWrapperControlProps = {
  Control: ComponentType<MultiControlProps>;
  controlMap: ControlByModeMap;
  controlWrapperMap: ControlWrapperByModeMap;
  value: MultimodeControlValue;
  defaultValue?: MultimodeControlValue;
  placeholder?: string;
  displayMode?: DisplayMode;
  isChanged: boolean;
  controlParams: BaseControlParams;
  formParams: FormParams;
  crud?: unknown;
  options?: any;
  setValue: (value: MultimodeControlValue) => void;
  onChange: () => void;
  setDisplayMode: (mode: DisplayMode) => void;
};

export const ViewWrapper: React.FC<MultimodeWrapperControlProps> = ({ Control, value }) => {
  return <Control value={value} />;
};

export const EditableViewWrapper: React.FC<MultimodeWrapperControlProps> = ({ Control, ...props }) => {
  const { isChanged, setDisplayMode } = props;

  return (
    <Space>
      {isChanged && <ChangeSymbol />}
      <Control {...props} />
      <Button
        color="default"
        variant="link"
        icon={<EditOutlined />}
        onClick={() => setDisplayMode(DisplayMode.EDITOR)}
      />
    </Space>
  );
};

export const EditorWrapper: React.FC<MultimodeWrapperControlProps> = ({ Control, ...props }) => {
  const { value, defaultValue, formParams, setValue, setDisplayMode } = props;
  const { key, rules, normalize, hasFeedback } = formParams;

  const onSubmit = (formValue: { [key: string]: MultimodeControlValue }) => {
    const newValue = formValue[key];
    if (newValue !== undefined) {
      setValue(newValue);
      setDisplayMode(DisplayMode.EDITABLE_VIEW);
    } else {
      /* eslint-disable-next-line no-console */
      console.error(`Field "${key}" not found in form values. Available fields: ${Object.keys(formValue).join(', ')}`);
      // TODO: показать уведомление пользователю
    }
  };

  return (
    <Form layout="inline" name="editModeForm" clearOnDestroy onFinish={(values) => onSubmit(values)}>
      <Form.Item
        key={key}
        name={key}
        initialValue={defaultValue || value}
        rules={rules}
        normalize={normalize}
        hasFeedback={hasFeedback}
      >
        <Control {...props} />
      </Form.Item>
      <Form.Item>
        <Space>
          <Button type="primary" htmlType="submit">
            Сохранить
          </Button>
          <Button htmlType="button" onClick={() => setDisplayMode(DisplayMode.EDITABLE_VIEW)}>
            Отмена
          </Button>
        </Space>
      </Form.Item>
    </Form>
  );
};

export const FormItemWrapper: React.FC<MultimodeWrapperControlProps> = (props) => {
  const { Control, value, placeholder, crud, defaultValue, formParams, onChange, controlParams } = props;
  const { key, name, normalize, hasFeedback, rules } = formParams;
  const { displayOptions } = controlParams;
  const { formItemMode } = displayOptions;

  return (
    formItemMode && (
      <Form.Item
        key={key}
        name={key}
        label={name}
        initialValue={defaultValue}
        rules={rules}
        normalize={normalize}
        hasFeedback={hasFeedback}
      >
        <Control
          value={value}
          placeholder={placeholder}
          formParams={formParams}
          crud={crud}
          options={undefined}
          onChange={onChange}
        />
      </Form.Item>
    )
  );
};

export const defaultControlWrapperByModeMap: ControlWrapperByModeMap = {
  [DisplayMode.VIEW]: ViewWrapper,
  [DisplayMode.EDITABLE_VIEW]: EditableViewWrapper,
  [DisplayMode.EDITOR]: EditorWrapper,
  [DisplayMode.FORM_ITEM]: FormItemWrapper,
};
