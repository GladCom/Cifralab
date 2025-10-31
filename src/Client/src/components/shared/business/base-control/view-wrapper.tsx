import { MultimodeBaseControlWrapper } from './types';

export const ViewWrapper: React.FC<MultimodeBaseControlWrapper> = ({ Control, value }) => {
  return <Control value={value} />;
};
