import React, { useState, useCallback, useMemo, useEffect } from 'react';
import { Input, Space } from 'antd';
import { SearchOutlined } from '@ant-design/icons';

const checkName = ({ fullName }, key) => (
    fullName.toLowerCase().includes(key.toLowerCase())
);

const filterNames = (data, name) => data.filter((d) => checkName(d, name));

const FullNameFilter = ({ data, setFilteredData, className, style }) => {

    return (
        <div className={className} style={style}>
            <Space>
                <Input
                    placeholder="ФИО"
                    suffix={<SearchOutlined />}
                    onChange={({target}) => {
                        const { value } = target;
                        const filteredData = filterNames(data, value);
                        setFilteredData(filteredData);
                    }}
                />
            </Space>
        </div>
    );
};

export default FullNameFilter;