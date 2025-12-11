import { useSelector } from 'react-redux';
import { Navigate, useLocation } from 'react-router-dom';
import { RootState } from '../../storage';

const PrivateRoute = ({ children }) => {
  const { loggedIn } = useSelector((state: RootState) => state.user);
  const location = useLocation();

  return loggedIn ? children : <Navigate to="/login" state={{ from: location }} />;
};

export default PrivateRoute;
