import { FormParams } from './multi-mode-control/types';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import { Rule } from 'antd/es/form';
import _ from 'lodash';

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
  const { formParams: externalFormParams } = props;
  const finalFormParams = _.merge(
    {},
    formParams, // база
    externalFormParams, // переопределения
  );

  return <MultimodeControl {...props} formParams={finalFormParams} />;
};
