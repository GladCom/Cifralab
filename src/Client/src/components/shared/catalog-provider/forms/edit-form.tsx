import { useState, useEffect, ComponentType } from 'react';
import { Modal, Form } from 'antd';
import { DisplayMode } from '../../control/multi-mode-control/types';
import { MultimodeControlProps } from '../../control/multi-mode-control/multi-mode-control';
import { EntityTableConfig } from '../../layout/entity-table';

type EditFormProps = {
  item: any;
  visibilityControl: {
    visible: boolean;
    setVisible: React.Dispatch<React.SetStateAction<boolean>>;
  }
  config: EntityTableConfig;
};

export const EditForm: React.FC<EditFormProps> = ({ item, visibilityControl, config }) => {
  const { id } = item;
  const [form] = Form.useForm();
  const [itemData, setItemData] = useState(item);
  const { visible, setVisible } = visibilityControl;
  const { formModel, crud } = config;
  const { useGetOneByIdAsync, useEditOneAsync } = crud;
  const { data, isLoading, isSuccess, isFetching } = useGetOneByIdAsync(id);
  const [editItem, { error: _editItemError, isLoading: _isEdittingItem }] = useEditOneAsync();

  useEffect(() => {
    if (!isLoading && !isFetching && data) {
      const newData = { ...data };
      delete newData.id;
      setItemData(newData);
    }
  }, [isLoading, isFetching, data]);

  useEffect(() => {}, [isSuccess]);

  const onCreate = (formValues) => {
    editItem({ id, item: formValues });
    setVisible(false);
  };

  return (
    <Modal
      title="Правка"
      open={visible}
      confirmLoading={isLoading || isFetching}
      onCancel={() => setVisible(false)}
      destroyOnHidden
      okButtonProps={{
        autoFocus: true,
        htmlType: 'submit',
      }}
      modalRender={(dom) => (
        <Form
          layout="horizontal"
          form={form}
          name="form_in_modal"
          scrollToFirstError
          clearOnDestroy
          onFinish={(values) => {
            onCreate(values);
          }}
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
            value={itemData[key]}
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
