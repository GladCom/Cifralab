import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { actions as userActions } from '../../slices/userSlice.js';
import Logo from './Logo.jsx';

const headerStyle = {
    height: '10%',
    'min-height': '50px',
};

const titleStyle = {
    'font-size': 'max(24px, 2vw)',
};

const Header = ({ title }) => {
    const dispatch = useDispatch();
    const { userName } = useSelector((state) => state.user);

    const onClickHandler = () => {
        dispatch(userActions.logoutUser());
    };

    return (
        <header className="
            row
            d-flex align-items-center
            w-100 
            border-bottom
            border-primary
            p-6
        " style={headerStyle}>
            <div className="hstack gap-3">
                <Logo />
                <div className="vr m-3" />
                <div className="me-auto">
                    <h1 className="display-6 m-0" style={titleStyle}>{title}</h1>
                </div>
                <div className="vr m-3" />
                <div className="d-flex justify-content-center">
                    <span>Пользователь: {userName}</span>
                </div>
                <div className="d-flex justify-content-center">
                    <button className="btn btn-primary btn-block" onClick={onClickHandler}>Выйти</button>
                </div>
            </div>
        </header>
    );
};

export default Header;