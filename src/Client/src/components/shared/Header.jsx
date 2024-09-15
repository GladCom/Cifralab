import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { actions as userActions } from '../../slices/userSlice.js';

const headerStyle = {
    height: '10vh',
};

const Header = () => {
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
            <div className="col-2 d-flex justify-content-center">рисунок</div>
            <div className="col-6">Академия Цифра</div>
            <div className="col-2 d-flex justify-content-center">
                <span>Пользователь: {userName}</span>
            </div>
            <div className="col-2 d-flex justify-content-center">
                <button className="btn btn-primary btn-block" onClick={onClickHandler}>Выйти</button>
            </div>
        </header>
    );
};

export default Header;