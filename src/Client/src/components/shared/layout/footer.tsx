import { Flex, Layout, Typography } from 'antd';

const { Footer } = Layout;
const { Text } = Typography;

const MyFooter = ({ style }) => {
  return (
    <Footer style={style} className="border-top border-primary">
      <Flex align="center" justify="center">
        <Text>Академия Цифра © 2024</Text>
      </Flex>
    </Footer>
  );
};

export default MyFooter;
