import React, { createContext } from 'react';
import { notification } from 'antd';

const NotificationContext = createContext();

export const NotificationProvider = ({ children }) => {
    const [api, contextHolder] = notification.useNotification();

    return (
        <NotificationContext.Provider value={api}>
            {contextHolder}
            {children}
        </NotificationContext.Provider>
    );
};

export default NotificationContext;
