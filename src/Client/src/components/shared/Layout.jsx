import React from 'react';
import Footer from './Footer';
import Header from './Header';
import Content from './Content';

const CustomLayout = ({ title, children }) => {
    return (
            <div className="container-fluid h-100">
                <div className="row h-100">
                    <Header title={title} />
                        <Content>
                            {children}
                        </Content>
                    <Footer />
                </div>
            </div>

    );
};

export default CustomLayout;