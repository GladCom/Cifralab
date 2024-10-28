import React from 'react';
import { Modal, Form } from "antd";

const AddOneForm = ({ control, properties, crud }) => {
  const { useAddOneAsync } = crud;
  const { showAddOneForm, setShowAddOneForm } = control;
  const [ addOne, { error, isLoading } ] = useAddOneAsync();
  const [form] = Form.useForm();

  const onCreate = (formValues) => {
    //console.log(formValues)
    addOne(formValues);
    setShowAddOneForm(false);
  };

  return (
    <Modal
        title="Добавление новой записи"
        open={showAddOneForm}
        //confirmLoading={() => true}
        okText="Добавить"
        cancelText="Отмена"
        destroyOnClose
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
            initialValues={Object.entries(properties).reduce((acc, [key]) => ({ ...acc, [key]: '' }), {}) }
            clearOnDestroy
            onFinish={(values) => onCreate(values)}
        >
            {dom}
        </Form>
        )}
    >
        {Object.entries(properties).map(([key, { name, type, formParams }]) => {
            const Item = type;

            return (
                <Item
                    key={key}
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