import { Modal, Form } from 'antd';
import { DisplayMode } from '../../control/multi-mode-control/types';
import { MultimodeControlProps } from '../../control/multi-mode-control/multi-mode-control';
import { ComponentType } from 'react';

const AddOneForm = ({ control, properties, crud }) => {
  const { useAddOneAsync } = crud;
  const { showAddOneForm, setShowAddOneForm } = control;
  const [addOne, { error, isLoading }] = useAddOneAsync();
  const [form] = Form.useForm();

  const onSubmit = (formValues) => {
    addOne(formValues);
    setShowAddOneForm(false);
    form.resetFields();
  };

  const onCancel = () => {
    setShowAddOneForm(false);
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
      onCancel={onCancel}
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
        const Item: ComponentType<MultimodeControlProps> = type;

        return (
          <Item
            key={key}
            controlParams={params}
            formParams={{ key, name, ...formParams }}
            displayMode={DisplayMode.FORM_ITEM}
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
