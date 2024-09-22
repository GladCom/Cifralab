import React from 'react';
import { Input, Space } from 'antd';
import { SearchOutlined } from '@ant-design/icons';

const InputFilter = ({ placeholder, onChange }) => {
    return (
        <div className="col-3">
            <Space>
                <Input
                    placeholder={placeholder}
                    suffix={<SearchOutlined />}
                    onChange={({target}) => onChange(target.value.toLowerCase())}
                />
            </Space>
        </div>
    );
};

export default InputFilter;