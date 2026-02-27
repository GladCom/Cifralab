import { Flex, Layout, Typography } from 'antd';

const { Footer: AntFooter } = Layout;
const { Text } = Typography;

export const Footer = ({ style }) => {
  return (
    <AntFooter style={style} className="border-top border-primary">
      <Flex align="center" justify="center">
        <Text>Академия Цифра © 2024</Text>
      </Flex>
    </AntFooter>
  );
};
