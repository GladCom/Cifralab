import { MultimodeControl } from './types';

// export interface CustomViewControl {

// }

const View: React.FC<MultimodeControl> = ({ Control, value }) => {
  return <Control value={value} />;
};

export default View;
