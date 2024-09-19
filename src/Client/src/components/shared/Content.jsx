import React from 'react';
import Navbar from './Navbar';

const contentStyle = {
    'min-height': '80%',
};

const Content = ({ children }) => {
    return (
        <div className='row' style={contentStyle}>
            <Navbar className="col-2 border-right border-primary"/>
            <section className='col-10'>
                {children}
            </section>
        </div>
    );
};

export default Content;