import { Modal, Form, Result } from 'antd';
import { EntityTableConfig } from '../../layout/entity-table';

type RemoveFormProps = {
  item: any;
  visibilityControl: {
    visible: boolean;
    setVisible: React.Dispatch<React.SetStateAction<boolean>>;
  };
  config: EntityTableConfig;
};

export const RemoveForm: React.FC<RemoveFormProps> = ({ item, visibilityControl, config }) => {
  const { id } = item;
  const [form] = Form.useForm();
  const { crud } = config;
  const { useRemoveOneAsync } = crud;
  const [removeItem] = useRemoveOneAsync();
  const { visible, setVisible } = visibilityControl;

  const onSubmit = () => {
    removeItem(id);
    setVisible(false);
  };

  const onCancel = () => {
    setVisible(false);
  };

  return (
    <Modal
      title="Внимание!"
      open={visible}
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
