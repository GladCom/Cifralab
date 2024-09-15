import React from 'react';
import { Menu } from 'antd';
import { useNavigate } from 'react-router-dom';

const Navbar = ( { className }) => {
    const navigate = useNavigate();
    const items = [
        {
          key: 'sub1',
          label: 'Сервис заявок',
          onClick: () => {navigate('/requests')},
        },
        {
            type: 'divider',
        },
        {
          key: 'sub2',
          label: 'Справочники',
          children: [
            {
              key: '1',
              label: 'Студенты',
              onClick: () => {navigate('/students')},
            },
            {
              key: '2',
              label: 'Группы',
              onClick: () => {navigate('/groups')},
            },
            {
              key: '3',
              label: 'Программы',
              onClick: () => {navigate('/programs')},
            },
          ],
        },
      ];

    return (
      <aside className={className}>
        <Menu 
            defaultSelectedKeys={['1']}
            defaultOpenKeys={['sub1']}
            mode="inline"
            items={items}
        />
      </aside>
    );
};

export default Navbar;