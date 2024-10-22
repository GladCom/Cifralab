import React from 'react';
import { Flex } from 'antd';
import logo from '../../assets/images/cyfraLogo.png';

const logoStyle = {
    height: '80%',
};

const Logo = () => {
    return (
        <Flex style={logoStyle} >
            <img src={logo} alt="Логотип Академии цифра" />
        </Flex>
    );
};

export default Logo;