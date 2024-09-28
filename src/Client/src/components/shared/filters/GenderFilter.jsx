import React, { useState, useCallback } from 'react';
import { Button, Dropdown, Space } from 'antd';
import { WomanOutlined, ManOutlined, DownOutlined, CloseSquareOutlined } from '@ant-design/icons';

const items = [
    {
      label: "муж.",
      key: '1',
      icon: <ManOutlined />,
    },
    {
      label: "жен.",
      key: '2',
      icon: <WomanOutlined />,
    },
    {
        label: "сброс",
        key: '0',
        icon: <CloseSquareOutlined />,
      },
];

const GenderFilter = ({ onChange }) => {
    const [gender, setGender] = useState('пол');

    const onClick = useCallback(({ key }) => {
        const select = {
            1: () => {
                setGender('муж.');
                onChange(1);
            },
            2: () => {
                setGender('жен.');
                onChange(2);
            },
            0: () => {
                setGender('пол');
                onChange(0);
            },
        };
        select[key]();
    });

    const menuProps = {
        items,
        onClick,
    };

    return (
        <div className="col-1">
            <Dropdown menu={menuProps} >
                <Button>
                    <Space>
                    {gender}
                    <DownOutlined />
                    </Space>
                </Button>
            </Dropdown>
        </div>
    );
};

export default GenderFilter;