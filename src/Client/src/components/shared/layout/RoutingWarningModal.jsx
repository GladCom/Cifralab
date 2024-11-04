import React from 'react';
import { Modal, Form, Result } from "antd";

const RoutingWarningModal = ({ show, blocker }) => {
    const [form] = Form.useForm();

    const onSubmit = (e) => {
        console.log(e)
        blocker.proceed();
    };

    const onCancel = () => {
        blocker.reset();
    };

    return (
        <Modal
            title="Внимание!"
            open={show}
            okText="Всеравно перейти"
            cancelText="Остаться на странице"
            destroyOnClose
            okButtonProps={{
                autoFocus: false,
                danger: true,
                htmlType: 'submit',
            }}
            onCancel={onCancel}
            modalRender={(dom) => (
                <Form
                    layout="horizontal"
                    form={form}
                    name="warning_modal"
                    clearOnDestroy
                    onFinish={onSubmit}
                >
                    {dom}
                </Form>
            )}
        >
            <Result
                status="warning"
                title="Вы покидаете текущую страницу"
                extra={
                    <p>У вас остались не сохраненные изменения</p>
                }
            />
        </Modal>
    );
};

export default RoutingWarningModal;