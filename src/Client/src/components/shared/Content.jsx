import React from 'react';
import { Layout } from 'antd';

const { Content } = Layout;
const contentStyle = {
    backgroundColor: '#fff',
    overflow: 'auto',
};

const MyContent = ({ children }) => {
    return (
        <Content style={contentStyle}>
                {children}
        </Content>
    );
};

export default MyContent;