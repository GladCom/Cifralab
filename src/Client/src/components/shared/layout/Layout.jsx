import React from 'react';
import Footer from './Footer';
import Header from './Header';
import Navbar from './Navbar';
import Content from './Content';
import { Layout } from 'antd';

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
}

const title = 'Сервис обработки заявок';

const MyLayout = ({ children }) => {
    return (
        <Layout style={layoutStyle}>
            <Header title={title} style={headerStyle}/>
            <Layout hasSider>
                <Navbar width="15%" />
                <Content>{children}</Content>
            </Layout>
            <Footer style={footerStyle} />
        </Layout>
    );
};

export default MyLayout;