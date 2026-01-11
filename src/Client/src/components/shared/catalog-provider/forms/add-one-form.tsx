import { Modal, Form, message } from 'antd';
import { DisplayMode } from '../../control/multi-mode-control/types';
import { MultimodeControlProps } from '../../control/multi-mode-control/multi-mode-control';
import { ComponentType } from 'react';
import { FormModel } from '../../../../storage/form-model/types';

interface FormValues {
  [key: string]: string | number | boolean | Date | null;
}

interface AddOneResult {
  loading: boolean;
}

interface CrudOperations {
  useAddOneAsync: () => [(values: FormValues) => Promise<void>, AddOneResult];
}

type AddOneFormProps = {
  visibilityControl: {
    showAddOneForm: boolean;
    setShowAddOneForm: React.Dispatch<React.SetStateAction<boolean>>;
  };
  formModel: FormModel;
  crud: CrudOperations;
};

export const AddOneForm: React.FC<AddOneFormProps> = ({ visibilityControl, formModel, crud }) => {
  const { useAddOneAsync } = crud;
  const { showAddOneForm, setShowAddOneForm } = visibilityControl;
  const [addOne] = useAddOneAsync();
  const [form] = Form.useForm();

  const validateDates = (values: FormValues) => {
    const { startDate, endDate } = values as {
      startDate?: string | Date;
      endDate?: string | Date;
    };

    if (startDate && endDate) {
      const start = new Date(startDate);
      const end = new Date(endDate);

      if (start > end) {
        return {
          isValid: false,
          message: 'Дата начала не может быть позже даты окончания',
        };
      }
    }

    return { isValid: true };
  };

  const onSubmit = (formValues: FormValues) => {
    const validation = validateDates(formValues);

    if (!validation.isValid) {
      message.error(validation.message);
      return;
    }

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
