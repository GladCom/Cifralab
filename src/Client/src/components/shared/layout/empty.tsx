import { Empty as AntEmpty } from 'antd';

export const Empty = () => {
  const style = {
    height: '10vh',
  };

  return (
    <div className="row h-100 align-items-center justify-content-center" style={style}>
      <AntEmpty />
    </div>
  );
};
