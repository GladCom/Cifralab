import React from 'react';
import logo from '../../assets/images/cyfraLogo.png';

const logoStyle = {
    maxHeight: '50px',
};

const Logo = () => {
    return (
        <div className="col-2 d-flex justify-content-center">
            <img src={logo} alt="Логотип Академии цифра" style={logoStyle} />
        </div>
    );
};

export default Logo;