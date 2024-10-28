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
                    onCreate(values)
                }}
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
                        value={itemData[key]}
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

export default EditForm;