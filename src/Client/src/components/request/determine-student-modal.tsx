import { useState } from 'react';
import { Modal, Spin, Row, Col, Button } from 'antd';
import { Student } from '../../storage/service/types';

type StudentWithId = Student & { id?: string };

type DetermineStudentModalProps = {
  open: boolean;
  onClose: () => void;
  students?: StudentWithId[] | null;
  isLoading?: boolean;
};

const DetermineStudentModal = ({ open, onClose, students, isLoading }: DetermineStudentModalProps) => {
  const [selectedStudentId, setSelectedStudentId] = useState<string | null>(null);

  const getStudentFullName = (student: StudentWithId): string => {
    if (student.fullName) {
      return student.fullName;
    }
    const parts = [student.family, student.name, student.patron].filter(Boolean);
    return parts.length > 0 ? parts.join(' ') : 'Не указано';
  };

  const handleStudentClick = (studentId: string | undefined) => {
    if (studentId) {
      setSelectedStudentId(studentId);
    }
  };

  const handleConfirm = () => {
    onClose();
  };

  return (
    <Modal
      title="Определить студента"
      open={open}
      onCancel={onClose}
      onOk={onClose}
      okText="Закрыть"
      width={400}
      centered
      cancelButtonProps={{ style: { display: 'none' } }}
      footer={[
        <Button
          key="confirm"
          type="primary"
          onClick={handleConfirm}
          disabled={!selectedStudentId}
          style={{ marginRight: '8px' }}
        >
          Подтвердить
        </Button>,
        <Button key="close" onClick={onClose}>
          Закрыть
        </Button>,
      ]}
    >
      <Spin spinning={isLoading || false}>
        {students && students.length > 0 ? (
          <Row gutter={[0, 12]} style={{ marginTop: '0' }}>
            {students.map((student) => {
              const studentId = student.id;
              const isSelected = selectedStudentId === studentId;
              return (
                <Col key={studentId} span={24}>
                  <div
                    onClick={() => handleStudentClick(student.id || studentId)}
                    style={{
                      padding: '16px',
                      border: `2px solid ${isSelected ? '#52c41a' : '#d9d9d9'}`,
                      borderRadius: '8px',
                      cursor: 'pointer',
                      backgroundColor: isSelected ? '#f6ffed' : '#fff',
                      transition: 'all 0.3s',
                      minHeight: '80px',
                      display: 'grid',
                      alignItems: 'center',
                      justifyContent: 'center',
                      textAlign: 'center',
                    }}
                  >
                    <div style={{ fontWeight: isSelected ? 'bold' : 'normal' }}>{getStudentFullName(student)}</div>
                    <div style={{ fontSize: '12px', color: 'grey' }}>{student.phone}</div>
                    <div style={{ fontSize: '12px', color: 'grey' }}>{student.email}</div>
                    <div style={{ fontSize: '12px', color: 'grey' }}>{student.address}</div>
                  </div>
                </Col>
              );
            })}
          </Row>
        ) : (
          <div style={{ textAlign: 'center', padding: '40px' }}>
            {isLoading ? 'Загрузка...' : 'Похожие студенты не найдены'}
          </div>
        )}
      </Spin>
    </Modal>
  );
};

export { DetermineStudentModal };
