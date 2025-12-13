import { Modal, Form } from 'antd';
import { DisplayMode } from '../../control/multi-mode-control/types';
import { MultimodeControlProps } from '../../control/multi-mode-control/multi-mode-control';
import { ComponentType } from 'react';
import { FormModel } from '../../../../storage/form-model/types';

type AddOneFormProps = {
  visibilityControl: {
    showAddOneForm: boolean;
    setShowAddOneForm: React.Dispatch<React.SetStateAction<boolean>>;
  };
  formModel: FormModel;
  crud: unknown;
};

export const AddOneForm: React.FC<AddOneFormProps> = ({ visibilityControl, formModel, crud }) => {
  const { useAddOneAsync } = crud;
  const { showAddOneForm, setShowAddOneForm } = visibilityControl;
  const [addOne] = useAddOneAsync();
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
      {Object.entries(formModel).map(([key, { name, type, formParams, controlParams }]) => {
        const Item: ComponentType<MultimodeControlProps> = type;

        return (
          <Item
            key={key}
            controlParams={controlParams}
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
