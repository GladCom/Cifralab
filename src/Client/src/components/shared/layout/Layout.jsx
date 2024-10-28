import React from 'react';
import Footer from './Footer';
import Header from './Header';
import Navbar from './Navbar';
import Content from './Content';
import Notification from './Notification';
import { Layout } from 'antd';

const headerStyle = {
    textAlign: 'center',
    backgroundColor: '#fff',
    height: '10%',
};

const layoutStyle = {
    height: '100%',
};

const footerStyle = {
    textAlign: 'center',
    backgroundColor: '#fff',
    height: '10%',
};


const MyLayout = ({ title, children }) => {
    return (
        <Layout style={layoutStyle}>
            <Notification />
            <Header title={title} style={headerStyle}/>
                <Layout>
                    <Navbar width="10%" />
                    <Content>{children}</Content>
                </Layout>
            <Footer style={footerStyle} />
      </Layout>
    );
};

export default MyLayout;