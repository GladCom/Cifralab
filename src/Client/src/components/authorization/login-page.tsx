import { useState } from 'react';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { actions as userActions } from '../../storage/slice/user-slice';
import { LockOutlined, UserOutlined } from '@ant-design/icons';
import { Button, Checkbox, Form, Input, Flex, Tooltip } from 'antd';
import { ValidateStatus } from 'antd/es/form/FormItem';

const containerStyle = {
  background: 'linear-gradient(to bottom right, #e968a4, #005aff)',
};

type ValidationState = {
  status?: ValidateStatus;
  message?: string;
};

const LoginPage = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const [validationState, setValidationState] = useState<ValidationState>({});

  const onSubmit = ({ username, password, remember }) => {
    if (username !== 'user' || password !== '123') {
      setValidationState({
        status: 'error',
        message: 'Неправильный логин или пароль',
      });
      return;
    }

    const newUserData = { userName: 'user', token: 'sdfsdfsfg4332422v42v', remember };
    dispatch(userActions.loginUser(newUserData));
    navigate('/requests');
  };

  return (
    <Flex className="container-fluid vh-100" style={containerStyle} align="center" justify="center">
      <Flex align="center" justify="center" style={{ backgroundColor: 'white', padding: '2%', borderRadius: '2%' }}>
        <Form
          name="login"
          initialValues={{
            remember: true,
          }}
          style={{
            maxWidth: 360,
          }}
          onFinish={onSubmit}
        >
          <Tooltip title="Попробуйте user">
            <Form.Item
              name="username"
              validateStatus={validationState.status}
              help={validationState.message}
              rules={[
                {
                  required: true,
                  message: 'Пожалуйста, введите логин',
                },
              ]}
            >
              <Input prefix={<UserOutlined />} allowClear placeholder="Логин пользователя" />
            </Form.Item>
          </Tooltip>
          <Tooltip title="Попробуйте 123">
            <Form.Item
              name="password"
              validateStatus={validationState.status}
              help={validationState.message}
              rules={[
                {
                  required: true,
                  message: 'Пожалуйства введите пароль',
                },
              ]}
            >
              <Input prefix={<LockOutlined />} type="password" allowClear placeholder="Пароль" />
            </Form.Item>
          </Tooltip>
          <Form.Item>
            <Flex justify="space-between" align="center">
              <Form.Item name="remember" valuePropName="checked" noStyle>
                <Checkbox>Запомнить меня</Checkbox>
              </Form.Item>
            </Flex>
          </Form.Item>
          <Form.Item>
            <Button block type="primary" htmlType="submit">
              Войти
            </Button>
          </Form.Item>
        </Form>
      </Flex>
    </Flex>
  );
};

export default LoginPage;
