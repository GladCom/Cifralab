import { Form } from 'antd';
import { MultimodeBaseControlWrapper } from './types';

export const FormItemWrapper: React.FC<MultimodeBaseControlWrapper> = ({ Control, ...props }) => {
  const { value, formParams, params } = props;
  const { key, name, normalize, hasFeedback, rules } = formParams;
  const { show } = params;
  const { form } = show;

  return (
    form && (
      <Form.Item
        key={key}
        name={key}
        label={name}
        initialValue={value}
        rules={rules}
        normalize={normalize}
        hasFeedback={hasFeedback}
      >
        <Control {...props} />
      </Form.Item>
    )
  );
};
