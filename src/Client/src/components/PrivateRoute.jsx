import React from 'react';
import { useSelector } from 'react-redux';
import { Navigate, useLocation } from 'react-router-dom';

const PrivateRoute = ({ children }) => {
    const { loggedIn } = useSelector((state) => state.user);
    const location = useLocation();

    return (
        //loggedIn ? children : <Navigate to="/login" state={{ from: location }} />
        children
    );
};

export default PrivateRoute;