import React from 'react';
import { Form } from 'antd';

const DefaultForm = ({ Component, props }) => {
    const { value, formParams } = props;
    const { key, name, normalize, hasFeedback, rules } = formParams;

    return (
        <Form.Item
            key={key}
            name={key}
            label={name}
            initialValue={value}
            rules={rules}
            normalize={normalize}
            hasFeedback={hasFeedback}
        >
            <Component
                {...props}
            />
        </Form.Item>
    );
};

export default DefaultForm;