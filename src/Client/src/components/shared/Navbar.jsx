import React from 'react';
import { Menu } from 'antd';
import { useNavigate } from 'react-router-dom';
import {
  SendOutlined,
  TeamOutlined, 
  ReadOutlined,
  FileDoneOutlined,
  ContactsOutlined,

  FilePptOutlined,
} from '@ant-design/icons';

const Navbar = ( { className }) => {
    const navigate = useNavigate();
    const items = [
        {
          key: 'sub1',
          icon: <SendOutlined />,
          label: 'Сервис заявок',
          onClick: () => {navigate('/requests')},
        },
        {
            type: 'divider',
        },
        {
          key: 'sub2',
          icon: <ReadOutlined />,
          label: 'Справочники',
          children: [
            {
              key: '1',
              icon: <ContactsOutlined />,
              label: 'Студенты',
              onClick: () => {navigate('/students')},
            },
            {
              key: '2',
              icon: <TeamOutlined />,
              label: 'Группы',
              onClick: () => {navigate('/groups')},
            },
            {
              key: '3',
              icon: <FilePptOutlined />,
              label: 'Программы',
              onClick: () => {navigate('/programs')},
            },
            {
              key: '4',
              icon: <ContactsOutlined />,
              label: 'Заявки',
              onClick: () => {navigate('/requests')},
            },
          ],
        },
        {
          type: 'divider',
        },
        {
          key: 'sub3',
          icon: <FileDoneOutlined />,
          label: 'Отчеты',
          onClick: () => {navigate('/requests')},
        },
        {
          type: 'divider',
        },
      ];

    return (
      <aside className={className}>
        <Menu 
            mode="inline"
            items={items}
        />
      </aside>
    );
};

export default Navbar;