import { Select } from 'antd';  
import React, { useState, useEffect } from 'react';

const StatusEntranceExamsSelect = ({ id, mode, value, setValue, required }) => {
    //const { crud } = config;
    const { Option } = Select;
    
    function handleChange(value) {
      //console.log(`selected ${value}`);
      setValue(value);
    };

    return (
        <Select style={{ width: 120 }} onChange={handleChange}>
            <Option value={0}>Не сдано</Option>
            <Option value={1}>Тестовое задание</Option>
            <Option value={2}>Собеседование</Option>
            <Option value={3}>Выполнено</Option>
        </Select>   
    )
};

export default StatusEntranceExamsSelect;