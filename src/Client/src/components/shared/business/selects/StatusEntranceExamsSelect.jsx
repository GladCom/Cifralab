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
        <Select defaultValue="NotPassed" style={{ width: 120 }} onChange={handleChange}>
            <Option value="NotPassed">Не сдано</Option>
            <Option value="TestTask">Тестовое задание</Option>
            <Option value="Interview">Собеседование</Option>
            <Option value="Done">Выполнено</Option>
            <Option value="disabled" disabled>
                Disabled
            </Option>
        </Select>   
    )
};

export default StatusEntranceExamsSelect;