import React from 'react';
import { Menu, Layout } from 'antd';
import useMenuConfig from './menu-config';

const { Sider } = Layout;

const siderStyle = {
  textAlign: 'center',
  backgroundColor: '#fff',
};

const Navbar = ({ width }) => {
  const { selectedKey, openedKey, menuItems } = useMenuConfig();

  return (
    <Sider width={width} style={siderStyle}>
      <Menu mode="inline" items={menuItems} defaultSelectedKeys={[selectedKey]} defaultOpenKeys={[openedKey]} />
    </Sider>
  );
};

export default Navbar;
