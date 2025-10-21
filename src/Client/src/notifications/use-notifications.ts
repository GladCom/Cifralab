import { useContext } from 'react';
import NotificationContext from './NotificationContext';

const useNotifications = () => {
  const api = useContext(NotificationContext);

  const showSuccess = (message, description) => {
    api.success({
      message,
      description,
    });
  };

  const showError = (message, error) => {
    api.error({
      message,
      description: JSON.stringify(error),
    });
  };

  const showInfo = (message, description) => {
    api.info({
      message,
      description,
    });
  };

  return { showSuccess, showError, showInfo };
};

export default useNotifications;
