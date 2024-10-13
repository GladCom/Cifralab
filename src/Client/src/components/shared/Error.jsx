import React from 'react';

const overlayStyle = {
    position: 'fixed',
    top: 0,
    left: 0,
    width: '100vw',
    height: '100vh',
    backgroundColor: 'rgb(255 2 2 / 70%)',
    display: 'flex',
    justifyContent: 'center',
    alignItems: 'center',
    zIndex: 9999,
};


const Error = ({ e }) => {
    const { data, error, status, originalStatus } = e;
  return (
    <div style={overlayStyle}>
        <div className="auto bg-white p-3 rounded">
            <div><span className="fw-bold">ОШИБКА:</span> {JSON.stringify(originalStatus)}</div>
            <div><span className="fw-bold">Status:</span> {JSON.stringify(status)}</div>
            <div><span className="fw-bold">Data:</span> {JSON.stringify(data)}</div>
            <div><span className="fw-bold">Error:</span> {JSON.stringify(error)}</div>
            <hr />
            <div>Обновите страницу или вернитесь на предыдущую</div>
        </div>
    </div>
  );
};

export default Error;