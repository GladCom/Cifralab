import Footer from './footer';
import Header from './header';
import Navbar from './navbar';
import Content from './content';
import { Layout as AntLayout } from 'antd';
import { PropsWithChildren } from 'react';

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

const defaultTitle = 'Сервис обработки заявок';

type LayoutProps = PropsWithChildren<{
  title?: string;
}>;

export const Layout: React.FC<LayoutProps> = ({ title, children }) => {
  return (
    <AntLayout style={layoutStyle}>
      <Header title={title ?? defaultTitle} style={headerStyle} />
      <AntLayout hasSider>
        <Navbar width="15%" />
        <Content>{children}</Content>
      </AntLayout>
      <Footer style={footerStyle} />
    </AntLayout>
  );
};
