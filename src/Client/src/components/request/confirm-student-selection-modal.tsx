import { Modal, Result, Button } from 'antd';

type ConfirmStudentSelectionModalProps = {
  show: boolean;
  studentFullName: string;
  isSubmitting?: boolean;
  onConfirm: () => void | Promise<void>;
  onCancel: () => void;
};

const ConfirmStudentSelectionModal = ({
  show,
  studentFullName,
  isSubmitting = false,
  onConfirm,
  onCancel,
}: ConfirmStudentSelectionModalProps) => {
  const handleOk = async () => {
    if (isSubmitting) {
      return;
    }
    await onConfirm();
  };

  return (
    <Modal
      title="Внимание!"
      open={show}
      centered
      destroyOnHidden
      footer={[
        <Button key="cancel" onClick={onCancel} disabled={isSubmitting}>
          Отмена
        </Button>,
        <Button key="confirm" type="primary" danger loading={isSubmitting} disabled={isSubmitting} onClick={handleOk}>
          Подтвердить
        </Button>,
      ]}
      onCancel={onCancel}
    >
      <Result
        status="warning"
        title="Вы уверены, что хотите выбрать студента:"
        extra={<p style={{ fontSize: '16px', fontWeight: 'bold' }}>{studentFullName}</p>}
      />
    </Modal>
  );
};

export { ConfirmStudentSelectionModal };
