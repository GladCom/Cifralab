import React from 'react';

const FilterPanel = ({ children }) => {
  const style = {
    height: '10vh',
    minHeight: '50px',
  };

  return (
    <div
      className="
            row 
            d-flex
            align-items-center 
            w-100
            text-center
            border-bottom
            border-primary"
      style={style}
    >
      {children}
    </div>
  );
};

export default FilterPanel;
