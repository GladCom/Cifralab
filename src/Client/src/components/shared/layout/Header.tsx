import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { actions as userActions } from '../../../storage/slices/userSlice';
import Logo from './Logo';
import { Flex, Layout, Button, Typography } from 'antd';

const { Text, Title } = Typography;

const { Header } = Layout;

const MyHeader = ({ title, style }) => {
  const dispatch = useDispatch();
  const { userName } = useSelector((state) => state.user);

  const onClickHandler = () => {
    dispatch(userActions.logoutUser());
  };

  return (
    <Header style={style} className="border-bottom border-primary">
      <Flex style={{ height: '100%' }}>
        <Flex justify="center" align="center" style={{ width: '15%' }}>
          <Logo />
        </Flex>
        <Flex justify="left" align="center" style={{ width: '50%' }}>
          <Title style={{ margin: '0', fontWeight: 'normal', fontSize: '1.5rem' }}>{title}</Title>
        </Flex>
        <Flex justify="right" align="center" style={{ width: '25%' }}>
          <Text>Пользователь: {userName}</Text>
        </Flex>
        <Flex justify="center" align="center" style={{ width: '10%' }}>
          <Button type="primary" onClick={onClickHandler}>
            Выйти
          </Button>
        </Flex>
      </Flex>
    </Header>
  );
};

export default MyHeader;
