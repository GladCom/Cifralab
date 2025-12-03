import { Empty } from 'antd';

const CustomEmpty = () => {
  const style = {
    height: '10vh',
  };

  return (
    <div className="row h-100 align-items-center justify-content-center">
      <Empty />
    </div>
  );
};

export default CustomEmpty;
