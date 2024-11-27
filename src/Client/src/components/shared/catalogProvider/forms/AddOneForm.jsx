import React from 'react';
import { Modal, Form } from "antd";

const AddOneForm = ({ control, properties, crud }) => {
  const { useAddOneAsync } = crud;
  const { showAddOneForm, setShowAddOneForm } = control;
  const [ addOne, { error, isLoading } ] = useAddOneAsync();
  const [form] = Form.useForm();

  const onSubmit = (formValues) => {
    addOne(formValues);
    setShowAddOneForm(false);
    form.resetFields();
  };

  return (
    <Modal
        title="Добавление новой записи"
        open={showAddOneForm}
        okText="Добавить"
        cancelText="Отмена"
        okButtonProps={{
            autoFocus: true,
            htmlType: 'submit',
        }}
        onCancel={() => setShowAddOneForm(false)}
        modalRender={(dom) => (
        <Form
            layout="horizontal"
            form={form}
            name="form_in_modal"
            scrollToFirstError
            onFinish={(values) => onSubmit(values)}
        >
            {dom}
        </Form>
        )}
    >
        {Object.entries(properties).map(([key, { name, type, formParams, params }]) => {
            const Item = type;

            return (
                <Item
                    key={key}
                    params={params}
                    formParams={{ key, name, ...formParams }}
                    mode='form'
                    setValue={(value) => {
        
                      form.setFieldsValue({
                        [key]: value,
                      });
                    }}
                />
            );
        })}
    </Modal>
  );
};

export default AddOneForm;