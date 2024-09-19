import React from 'react';
import { TailSpin } from 'react-loader-spinner';

const Spinner = () => {
  const overlayStyle = {
    position: 'fixed',
    top: 0,
    left: 0,
    width: '100vw',
    height: '100vh',
    backgroundColor: 'rgba(255, 255, 255, 0.8)',
    display: 'flex',
    justifyContent: 'center',
    alignItems: 'center',
    zIndex: 9999,
  };

  return (
    <div style={overlayStyle}>
      <TailSpin height="80" width="80" color="#00BFFF" ariaLabel="loading" />
    </div>
  );
};

export default Spinner;