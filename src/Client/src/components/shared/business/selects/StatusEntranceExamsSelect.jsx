import { Select } from 'antd';  
import React, { useState, useEffect } from 'react';

const StatusEntranceExamsSelect = ({ id, mode, value, setValue, required }) => {
    //const { crud } = config;
    const { Option } = Select;
    
    function handleChange(value) {
      console.log(`selected ${value}`);
      setValue(value);
    };

    return (
        <Select defaultValue="0" style={{ width: 120 }} onChange={handleChange}>
            <Option value="1">Не сдано</Option>
            <Option value="2">Тестовое задание</Option>
            <Option value="3">Собеседование</Option>
            <Option value="4">Выполнено</Option>
        </Select>   
    )
};

export default StatusEntranceExamsSelect;