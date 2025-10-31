import { MultimodeControl } from './types';

const View: React.FC<MultimodeControl> = ({ Control, value }) => {
  return <Control value={value} />;
};

export default View;
