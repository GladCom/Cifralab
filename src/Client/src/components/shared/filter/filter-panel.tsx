const style: React.CSSProperties = {
  height: '10vh',
  minHeight: '50px',
};

export const FilterPanel = ({ children }) => {
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
