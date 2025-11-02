import { Typography, Form, Button, Space } from 'antd';
import { EditOutlined } from '@ant-design/icons';
import {
  MultimodeControlValue,
  ControlWrapperByModeMap,
  DisplayMode,
} from './types';
import { MultimodeControlProps } from './multi-mode-control';

const { Text } = Typography;
const ChangeSymbol = () => <Text>* </Text>;

export const ViewWrapper: React.FC<MultimodeControlProps> = ({ Control, value }) => {
  return <Control value={value} />;
};

export const EditableViewWrapper: React.FC<MultimodeControlProps> = ({ Control, ...props }) => {
  const { isChanged: changed, setDisplayMode } = props;

  return (
    <Space>
      {changed && <ChangeSymbol />}
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

export const EditorWrapper: React.FC<MultimodeControlProps> = ({ Control, ...props }) => {
  const { value, formParams, setValue, setDisplayMode } = props;
  const { key, rules, normalize, hasFeedback } = formParams;

const onSubmit = (formValue: { [key: string]: MultimodeControlValue }) => {
  const newValue = formValue[key];
  if (newValue !== undefined) {
    setValue(newValue);
    setDisplayMode(DisplayMode.EDITABLE_VIEW);
  } else {
    console.error(`Field "${key}" not found in form values. Available fields: ${Object.keys(formValue).join(', ')}`);
    // TODO: показать уведомление пользователю
  }
};

  return (
    <Form layout="inline" name="editModeForm" clearOnDestroy onFinish={(values) => onSubmit(values)}>
      <Form.Item
        key={key}
        name={key}
        //label={name}
        initialValue={value}
        rules={rules}
        normalize={normalize}
        hasFeedback={hasFeedback}
      >
        <Control
          {...{
            ...props,
            defaultValue: value,
          }}
        />
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

export const FormItemWrapper: React.FC<MultimodeControlProps> = ({ Control, ...props }) => {
  const { value, formParams, controlParams: params } = props;
  const { key, name, normalize, hasFeedback, rules } = formParams;
  const { displayOptions } = params;
  const { formItemMode } = displayOptions;

  return (
    formItemMode && (
      <Form.Item
        key={key}
        name={key}
        label={name}
        initialValue={value}
        rules={rules}
        normalize={normalize}
        hasFeedback={hasFeedback}
      >
        <Control {...props} />
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
