import { Button } from 'antd';
import { useNavigate } from 'react-router-dom';

const TransferToStudentButton = ({ studentId }: { studentId?: string }) => {
  const navigate = useNavigate();
  var url = `/student/${studentId}`;
  if (!studentId) {
    url = '/students';
  }

  return <Button onClick={() => navigate(url)}>Перейти</Button>;
};

export { TransferToStudentButton };
