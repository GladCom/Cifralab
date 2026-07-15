import { Layout } from 'antd';

const { Content: AntContent } = Layout;

const contentStyle = {
  backgroundColor: '#fff',
  overflow: 'auto',
  flex: 1,
};

export const Content = ({ children }) => {
  return <AntContent style={contentStyle}>{children}</AntContent>;
};
