import React, { useState, useEffect, ComponentType } from 'react';
import { Modal, Form } from 'antd';
import { DisplayMode } from '../../control/multi-mode-control/types';
import { MultimodeControlProps } from '../../control/multi-mode-control/multi-mode-control';

const EditForm = ({ item, control, config }) => {
  const { id } = item;
  const [form] = Form.useForm();
  const [itemData, setItemData] = useState(item);
  const { showEditForm, setShowEditForm } = control;
  const { properties, crud } = config;
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
    setShowEditForm(false);
  };

  return (
    <Modal
      title="Правка"
      open={showEditForm}
      confirmLoading={isLoading || isFetching}
      onCancel={() => setShowEditForm(false)}
      destroyOnClose
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
      {Object.entries(properties).map(([key, { name, type, formParams, params }]) => {
        const Item: ComponentType<MultimodeControlProps> = type;

        return (
          <Item
            key={key}
            value={itemData[key]}
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

export default EditForm;
