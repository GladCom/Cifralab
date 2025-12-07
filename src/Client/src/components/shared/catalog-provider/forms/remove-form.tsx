import { Modal, Form, Result } from 'antd';

const RemoveForm = ({ item, control, config }) => {
  const { id } = item;
  const [form] = Form.useForm();
  const { crud } = config;
  const { useRemoveOneAsync } = crud;
  const [removeItem] = useRemoveOneAsync();
  const { showRemoveForm, setShowRemoveForm } = control;

  const onSubmit = () => {
    removeItem(id);
    setShowRemoveForm(false);
  };

  const onCancel = () => {
    setShowRemoveForm(false);
  };

  return (
    <Modal
      title="Внимание!"
      open={showRemoveForm}
      okText="Всеравно удалить"
      cancelText="Отмена"
      onCancel={onCancel}
      destroyOnHidden
      okButtonProps={{
        autoFocus: false,
        danger: true,
        htmlType: 'submit',
      }}
      modalRender={(dom) => (
        <Form layout="horizontal" form={form} name="form_in_modal" clearOnDestroy onFinish={onSubmit}>
          {dom}
        </Form>
      )}
    >
      <Result status="warning" title="Вы удаляете запись" extra={<p>Вы уверены, что хотите удалить эту запись?</p>} />
    </Modal>
  );
};

export default RemoveForm;
