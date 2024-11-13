import React, { useState, useEffect, useCallback } from 'react';
import { Menu, Flex, Layout } from 'antd';
import { useNavigate, useLocation } from 'react-router-dom';
import useMenuConfig from './menuConfig.js';

const { Sider } = Layout;

const siderStyle = {
  textAlign: 'center',
  backgroundColor: '#fff',
};

const Navbar = ({ width }) => {
    const { selectedKey, openedKey, menuItems } = useMenuConfig();

    return (
      <Sider width={width} style={siderStyle}>
        <Menu
            mode="inline"
            items={menuItems}
            defaultSelectedKeys={[selectedKey]}
            defaultOpenKeys={[openedKey]}
        />
      </Sider>
    );
};

export default Navbar;