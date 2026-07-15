import { NotificationProvider } from '../notification/notification-context';
import { AppRoutes } from './routes';

export const App = () => {
  return (
    <NotificationProvider>
      <AppRoutes />
    </NotificationProvider>
  );
};
