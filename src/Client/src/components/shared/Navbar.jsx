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
          key: 'sub2',
          icon: <ContactsOutlined />,
          label: 'Студенты',
          onClick: () => {navigate('/students')},
        },
        {
            type: 'divider',
        },
        {
          key: 'sub3',
          icon: <ReadOutlined />,
          label: 'Справочники',
          children: [
            {
              key: '1',
              icon: <TeamOutlined />,
              label: 'Группы',
              onClick: () => {navigate('/groups')},
            },
            {
              key: '2',
              icon: <FilePptOutlined />,
              label: 'Программы',
              onClick: () => {navigate('/programs')},
            },
            {
              key: '3',
              icon: <ReadOutlined />,
              label: 'Формы образования',
              onClick: () => {navigate('/educationForm')},
            },
            {
              key: '4',
              icon: <ReadOutlined />,
              label: 'Статусы заявки',
              onClick: () => {navigate('/statusRequest')},
            },
            {
              key: '5',
              icon: <ReadOutlined />,
              label: 'Типы образования',
              onClick: () => {navigate('/typeEducation')},
            },
            {
              key: '6',
              icon: <ReadOutlined />,
              label: 'Статусы студента',
              onClick: () => {navigate('/studentStatus')},
            },
            {
              key: '7',
              icon: <ReadOutlined />,
              label: 'Типы приказов',
              onClick: () => {navigate('/kindOrder')},
            },
            {
              key: '8',
              icon: <ReadOutlined />,
              label: 'Виды документа повышения квалификации',
              onClick: () => {navigate('/kindDocumentRiseQualification')},
            },
            {
              key: '9',
              icon: <ReadOutlined />,
              label: 'Типы финансирования',
              onClick: () => {navigate('/financingType')},
            },
            {
              key: '10',
              icon: <ReadOutlined />,
              label: 'ВЭД программы',
              onClick: () => {navigate('/fEAProgram')},
            },
          ],
        },
        {
          type: 'divider',
        },
        {
          key: 'sub4',
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