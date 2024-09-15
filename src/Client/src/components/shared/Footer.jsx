import React from 'react';

const footerStyle = {
    height: '10vh',
};

const Footer = () => {
    return (
        <footer className="
            row
            d-flex align-items-center
            w-100
            text-center
            border-top
            border-primary
            p-6
        " style={footerStyle}>
            <span>Академия Цифра (c) 2024</span>
        </footer>
    );
};

export default Footer;