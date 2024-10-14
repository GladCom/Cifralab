import React, { useRef, useEffect } from 'react';
import { Modal, Form } from "antd";


const RemoveForm = ({ item, control, config, refetch }) => {
    const { id } = item;
    const [form] = Form.useForm();
    const { crud } = config;
    const { useRemoveOneAsync } = crud;
    const [removeItem, queryState] = useRemoveOneAsync();
    const { showRemoveForm, setShowRemoveForm } = control;


    const onCreate = () => {
        removeItem(id);
        setShowRemoveForm(false);
    };

    return (
        <Modal
            title="Внимание! Вы удаляете запись!"
            open={showRemoveForm}
            onCancel={() => setShowRemoveForm(false)}
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
                clearOnDestroy
                onFinish={onCreate}
            >
                {dom}
            </Form>
            )}
        >
        </Modal>
    );
};

export default RemoveForm;