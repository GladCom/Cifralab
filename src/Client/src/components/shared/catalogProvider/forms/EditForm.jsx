import React, { useState, useEffect, useMemo } from 'react';
import { Modal, Form } from "antd";


const EditForm = ({ item, control, config, refetch }) => {
    const { id } = item;
    const [form] = Form.useForm();
    const [itemData, setItemData] = useState(item);
    const { showEditForm, setShowEditForm } = control;
    const { properties, crud } = config;
    const { useGetOneByIdAsync, useEditOneAsync } = crud;
    const { data, error, isLoading, isSuccess, isError, isFetching } = useGetOneByIdAsync(id);

    const [
        editItem,
        { error: editItemError, isLoading: isEdittingItem },
      ] = useEditOneAsync();

    useEffect(() => {
        if (!isLoading && !isFetching) {
            const newData = { ...data };
            delete newData.id;
            setItemData(newData);
        }
    }, [isLoading, isFetching]);

    useEffect(() => {
      
    }, [isSuccess]);

    const onCreate = (formValues) => {
        editItem(formValues);
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
                initialValues={
                    Object.entries(properties).reduce((acc, [key]) => {
                        const value = itemData[key];
                        return { ...acc, [key]: value };
                    }, {})
                }
                clearOnDestroy
                onFinish={(values) => {
                    onCreate(values)
                }}
            >
                {dom}
            </Form>
            )}
        >
            {Object.entries(properties).map(([key, { name, type, show, required }]) => {
                const Input = type;

                return (
                    <Form.Item
                        key={key}
                        name={key}
                        label={name}
                        rules={[{ required, message: 'Please input the title of collection!' }]}
                    >
                        <Input
                            key={key}
                            id={id}
                            //value={itemData[key]}
                            mode='form'
                            setValue={(value) => {
                                form.setFieldsValue({
                                    [key]: value,
                                });
                            }}
                        />
                    </Form.Item>
                );
            })}
        </Modal>
    );
};

export default EditForm;