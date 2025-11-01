import { Typography, Form, Button, Space } from 'antd';
import { EditOutlined } from '@ant-design/icons';
import {
  BaseControlParams,
  BaseControlValue,
  ControlByModeMap,
  ControlWrapperByModeMap,
  DisplayMode,
  FormParams,
} from './types';
import { ComponentType } from 'react';

const { Text } = Typography;
const ChangeSymbol = () => <Text>* </Text>;

export type MultimodeBaseControlWrapperProps = {
  //  TODO: если поставить вместо any - MultiControlProps, то возникает ошибка, подумать над этим.
  Control: ComponentType<any>;
  controlMap: ControlByModeMap;
  controlWrapperMap: ControlWrapperByModeMap;
  value: BaseControlValue;
  defaultValue: BaseControlValue;
  placeholder: string;
  displayMode: DisplayMode;
  changed: boolean;
  params: BaseControlParams;
  formParams: FormParams;
  setValue: (value: BaseControlValue) => void;
  onChange: () => void;
  setDisplayMode: (mode: DisplayMode) => void;
};

export const ViewWrapper: React.FC<MultimodeBaseControlWrapperProps> = ({ Control, value }) => {
  return <Control value={value} />;
};

export const EditableViewWrapper: React.FC<MultimodeBaseControlWrapperProps> = ({ Control, ...props }) => {
  const { changed, setDisplayMode } = props;

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

export const EditorWrapper: React.FC<MultimodeBaseControlWrapperProps> = ({ Control, ...props }) => {
  const { value, formParams, setValue, setDisplayMode } = props;
  const { key, rules, normalize, hasFeedback } = formParams;

  const onSubmit = (formValue) => {
    setValue(formValue[key]);
    setDisplayMode(DisplayMode.EDITABLE_VIEW);
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

export const FormItemWrapper: React.FC<MultimodeBaseControlWrapperProps> = ({ Control, ...props }) => {
  const { value, formParams, params } = props;
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
