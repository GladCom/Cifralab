import React, { useState, useEffect, useCallback } from 'react';
import { Row, Col, Space } from 'antd';

const rowStyle = { alignItems: 'center' };

const DetailsPageData = ({ items, data, editData, setIsChanged }) => {
    return (
        <Space direction="vertical" size={0} style={{ display: 'flex' }}>
            {Object.entries(items).map(([key, { name, type, formParams }]) => {
                const Item = type;

                return (
                    <Row style={rowStyle} key={key}>
                        <Col span={3}>{name}</Col>
                        <Col span={8}>
                            <Item
                                key={key}
                                name={key}
                                value={data[key]}
                                mode='editableInfo'
                                formParams={{ key, name, ...formParams }}
                                setValue={(value) => {
                                    editData({
                                        ...data,
                                        [key]: value
                                    });
                                    setIsChanged(true);
                                }}
                            />
                        </Col>
                    </Row>
                );
            })}
        </Space>
    );
};

export default DetailsPageData;