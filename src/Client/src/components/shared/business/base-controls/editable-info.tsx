import { Typography, Button, Space } from 'antd';
import { EditOutlined } from '@ant-design/icons';
const { Text } = Typography;

const ChangeSymbol = () => <Text>* </Text>;

const EditableInfo = ({ Component, props }) => {
  const { changed, setMode } = props;

  return (
    <Space>
      {changed && <ChangeSymbol />}
      <Component {...props} />
      <Button color="default" variant="link" icon={<EditOutlined />} onClick={() => setMode('edit')} />
    </Space>
  );
};

export default EditableInfo;
