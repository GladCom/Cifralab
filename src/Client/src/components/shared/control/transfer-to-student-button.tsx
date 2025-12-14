import { Button } from 'antd';
import { useNavigate } from 'react-router-dom';

const TransferToStudentButton = ({ studentId }: { studentId?: string }) => {
  const navigate = useNavigate();

  if (!studentId) {
    return null;
  }

  return <Button onClick={() => navigate(`/student/${studentId}`)}>Перейти</Button>;
};

export { TransferToStudentButton };
