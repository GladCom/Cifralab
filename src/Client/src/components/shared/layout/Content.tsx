import { Layout } from 'antd';

const { Content } = Layout;

const contentStyle = {
  backgroundColor: '#fff',
  overflow: 'auto',
  flex: 1,
};

const MyContent = ({ children }) => {
  return <Content style={contentStyle}>{children}</Content>;
};

export default MyContent;
