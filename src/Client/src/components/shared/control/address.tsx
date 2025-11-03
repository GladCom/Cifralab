import { FormParams } from './multi-mode-control/types';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import { Rule } from 'antd/es/form';

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить место проживания',
  },
];

const formParams: FormParams = {
  key: 'address',
  name: 'Место проживания',
  rules,
  hasFeedback: true,
};

export const Address: React.FC<MultimodeControlProps> = (props) => {
  return <MultimodeControl {...props} formParams={formParams} />;
};
