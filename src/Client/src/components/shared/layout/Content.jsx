import React from 'react';
import { Layout } from 'antd';

const { Content } = Layout;

const contentStyle = {
    backgroundColor: '#fff',
    padding: '24px',
    overflow: 'auto',
    flex: 1,
};

const MyContent = ({ children }) => {
    return (
        <Content style={contentStyle}>
                {children}
        </Content>
    );
};

export default MyContent;