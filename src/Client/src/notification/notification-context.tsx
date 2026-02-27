import React, { createContext } from 'react';
import { notification } from 'antd';

export const NotificationContext = createContext('NotificationContext');

export const NotificationProvider = ({ children }) => {
  const [api, contextHolder] = notification.useNotification();

  return (
    <NotificationContext.Provider value={api}>
      {contextHolder}
      {children}
    </NotificationContext.Provider>
  );
};
