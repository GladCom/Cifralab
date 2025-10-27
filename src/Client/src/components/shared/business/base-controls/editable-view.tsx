import { Typography, Button, Space } from 'antd';
import { EditOutlined } from '@ant-design/icons';
import { MultimodeControl } from './types';
const { Text } = Typography;

const ChangeSymbol = () => <Text>* </Text>;

const EditableView: React.FC<MultimodeControl> = ({ Control, ...props }) => {
  const { changed, setMode } = props;

  return (
    <Space>
      {changed && <ChangeSymbol />}
      <Control {...props} />
      <Button color="default" variant="link" icon={<EditOutlined />} onClick={() => setMode('edit')} />
    </Space>
  );
};

export default EditableView;
