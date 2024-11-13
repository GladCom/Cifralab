import React from 'react';
import { Form } from 'antd';

const DefaultForm = ({ Component, props }) => {
    const { value, formParams, params } = props;
    const { key, name, normalize, hasFeedback, rules } = formParams;
    const { show } = params;
    const { form } = show;
console.log(rules)
    return form && (
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