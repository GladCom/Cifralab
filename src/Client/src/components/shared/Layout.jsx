import React from 'react';
import Footer from './Footer';
import Header from './Header';
import Content from './Content';
import Spinner from '../shared/Spinner.jsx';
import Empty from '../shared/Empty.jsx';

const CustomLayout = ({ title, isLoading, children }) => {
    return (
            <div className="container-fluid h-100">
                <div className="row h-100">
                    {isLoading && <Spinner />}
                    <Header title={title} />
                        <Content>
                            {
                                isLoading ? <Empty /> : children
                            }
                        </Content>
                    <Footer />
                </div>
            </div>

    );
};

export default CustomLayout;