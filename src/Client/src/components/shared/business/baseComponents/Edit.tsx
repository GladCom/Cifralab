import React from 'react';
import { Form, Button, Space } from 'antd';

const Edit = ({ Component, props }) => {
  const { value, formParams, setValue, setMode } = props;
  const { key, name, rules, normalize, hasFeedback } = formParams;

  const onSubmit = (formValue) => {
    setValue(formValue[key]);
    setMode('editableInfo');
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
        <Component
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
          <Button htmlType="button" onClick={() => setMode('editableInfo')}>
            Отмена
          </Button>
        </Space>
      </Form.Item>
    </Form>
  );
};

export default Edit;
