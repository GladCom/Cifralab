import { Form, Button, Space } from 'antd';
import { MultimodeControl } from './types';

const EditorWrapper: React.FC<MultimodeControl> = ({ Control, ...props }) => {
  const { value, formParams, setValue, setDisplayMode } = props;
  const { key, rules, normalize, hasFeedback } = formParams;

  const onSubmit = (formValue) => {
    setValue(formValue[key]);
    setDisplayMode('editableView');
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
          <Button htmlType="button" onClick={() => setDisplayMode('editableView')}>
            Отмена
          </Button>
        </Space>
      </Form.Item>
    </Form>
  );
};

export default EditorWrapper;
