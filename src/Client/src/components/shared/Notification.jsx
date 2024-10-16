import React, { useState, useEffect } from 'react';
import { notification } from 'antd';
import { useDispatch, useSelector } from 'react-redux';
import { clearNotificationData } from '../../storage/slices/notificationSlice.js';


const Notification = () => {
    const { show, type, error, message } = useSelector((state) => state.notification);
    const [api, contextHolder] = notification.useNotification();
    const dispatch = useDispatch();

    const openNotification = (type) => {
        api[type]({
            message,
            description: JSON.stringify(error),
        });
        dispatch(clearNotificationData());
    };

    useEffect(() => {
        if (show) {
            openNotification(type);
        }
    }, [message]);

    return (
        <>{contextHolder}</>
    );
};

export default Notification;