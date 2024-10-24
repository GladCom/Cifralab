import React, { useState, useCallback, useMemo, useEffect } from 'react';
import _ from 'lodash';
import { Flex, Button, Space } from 'antd';
import { PlusOutlined } from '@ant-design/icons';
import AddOneForm from './forms/AddOneForm.jsx';

const style = {
    height: '10vh',
    minHeight: '50px',
};

const FilterPanel = ({ query, config, setQuery }) => {
    const { properties, crud } = config;
    const [showAddOneForm, setShowAddOneForm] = useState(false);

    return (
        <>
            <Flex style={style} className="border-bottom border-primary">
                <Flex justify="center" align="center" style={{ width: '90%' }}>
                    <span> </span>
                </Flex>
                <Flex justify="center" align="center" style={{ width: '10%' }}>
                    <Button type="primary" onClick={() => setShowAddOneForm(true)}>
                        <PlusOutlined />
                        добавить
                    </Button>
                </Flex>
            </Flex>
            <AddOneForm control={{ showAddOneForm, setShowAddOneForm }} properties={properties} crud={crud} />
        </>
    );
};

export default FilterPanel;