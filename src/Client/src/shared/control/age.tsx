import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import { FormParams } from './multi-mode-control/types';

const formParams: FormParams = {
  key: 'age',
  rules: [
    {
      required: false,
    },
  ],
};

export const Age: React.FC<MultimodeControlProps> = (props) => <MultimodeControl {...props} formParams={formParams} />;
