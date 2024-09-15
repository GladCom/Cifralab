import React from 'react';
import Navbar from './Navbar';

const contentStyle = {
    height: '80vh',
};

const Content = ({ children }) => {
    return (
        <div className='row vh-75' style={contentStyle}>
            <Navbar className="col-2"/>
            <section className='col-10'>
                {children}
            </section>
        </div>
    );
};

export default Content;