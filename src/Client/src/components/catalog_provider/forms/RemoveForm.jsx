import React, { useRef, useEffect } from 'react';
import Button from 'react-bootstrap/Button';
import overlayStyle from './overlayStyle.js';
import Error from '../../shared/Error.jsx';

const formStyle = {
  width: '30%',
  height: '20%',
};

const RemoveForm = ({ show, validate, queryState, refetch }) => {

    const { isSuccess, isError, error } = queryState;

    // useEffect(() => {
    //     if(isSuccess) {
    //         show(false);
    //         refetch();
    //     }
    //     console.log(isSuccess)
    // },[isSuccess]);

    return (
        <>
            {isError && <Error e={error} />}
            <div style={overlayStyle}>
                <div className="border rounded bg-white p-3">
                            Вы уверены, что хотите удалить запись?
                    <Button variant="danger m-3" type="submit" onClick={() => {
                        validate();
                        show(false);
                    }}>
                    Удалить
                    </Button>
                    <Button variant="secondary m-3" onClick={() => show(false)}>
                    Отмена
                    </Button>
                </div>
            </div>
        </>
    );
};

export default RemoveForm;