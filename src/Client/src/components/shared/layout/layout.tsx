import Footer from './footer';
import Header from './header';
import Navbar from './navbar';
import Content from './content';
import { Layout as AntLayout } from 'antd';

const headerStyle = {
  textAlign: 'center',
  backgroundColor: '#fff',
};

const layoutStyle = {
  minHeight: '100vh',
};

const footerStyle = {
  textAlign: 'center',
  backgroundColor: '#fff',
  position: 'sticky',
};

interface Props {
  title?: string;
  children: React.ReactNode;
}
const Layout: React.FC<Props> = ({ children, title }) => {
  return (
    <AntLayout style={layoutStyle}>
      <Header title={title} style={headerStyle} />
      <AntLayout hasSider>
        <Navbar width="15%" />
        <Content>{children}</Content>
      </AntLayout>
      <Footer style={footerStyle} />
    </AntLayout>
  );
};

export default Layout;
