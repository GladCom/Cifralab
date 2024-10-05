import React, { useState } from 'react';
import { Tooltip as ReactTooltip } from "react-tooltip";
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { actions as userActions } from '../../storage/slices/userSlice.js';

const containerStyle = {
    background: 'linear-gradient(to bottom right, #e968a4, #005aff)',
};

const LoginPage = () => {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const [login, setLogin] = useState('');
    const [pass, setPass] = useState('');
    const [wrongPass, setWrongass] = useState(false);

    const onSubmitHandle = (e) => {   //  TODO: в дальнейшем переделать
        e.preventDefault();

        if (login !== 'user' || pass !== '123') {
            setWrongass(true);
            setLogin('');
            setPass('');
            return;
        }

        setWrongass(false);
        const newUserData = { userName: 'user', token: 'sdfsdfsfg4332422v42v' };
        dispatch(userActions.loginUser(newUserData));
        sessionStorage.setItem('loggedIn', JSON.stringify({ loggedIn: true }));

        navigate('/requests');
    };

    const onInputDataChange = ({ target }) => {
        const { id, value } = target;
        const changeState = {
            login: () => setLogin(value),
            password: () => setPass(value),
        };
        changeState[id]();
    };

    const showWrongPassMessage = () => {
        return wrongPass 
            ? <div 
                className="text-danger position-absolute bottom-0 end-0 translate-middle-x translate-middle-y">
                    *Неправильный логин или пароль
                </div>
            : null;
    };

    return (
        <div className="container-fluid vh-100" style={containerStyle}>
            <div className="row auto justify-content-center align-items-center vh-100">
                <div className="col-md-5 col-lg-3">
                    <div className="card">
                        <div className="card-header text-center">
                            <h4>Авторизация</h4>
                        </div>
                        <div className="card-body">
                            <form onSubmit={onSubmitHandle}>
                                <div className="form-group mb-3">
                                    <label htmlFor="login">Логин</label>
                                    <input 
                                        type="text"
                                        required
                                        className="form-control" 
                                        id="login" 
                                        placeholder="Введите логин"
                                        onChange={onInputDataChange}
                                        value={login}
                                        data-tooltip-id="login-tooltip"
                                    />
                                </div>
                                <div className="form-group mb-3">
                                    <label htmlFor="password">Пароль</label>
                                    <input 
                                        type="password"
                                        required
                                        className="form-control"
                                        id="password"
                                        placeholder="Введите пароль"
                                        onChange={onInputDataChange}
                                        value={pass}
                                        data-tooltip-id="pass-tooltip"
                                    />
                                </div>
                                <button
                                    type="submit"
                                    className="btn btn-primary btn-block"
                                >
                                    Войти
                                </button>
                                <ReactTooltip
                                    id="login-tooltip"
                                    place="right"
                                    variant="info"
                                    content="Попробуйте: user"
                                />
                                <ReactTooltip
                                    id="pass-tooltip"
                                    place="right"
                                    variant="info"
                                    content="Попробуйте: 123"
                                />
                                {showWrongPassMessage()}
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default LoginPage;