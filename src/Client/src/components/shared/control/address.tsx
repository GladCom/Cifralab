import { FormParams } from './multi-mode-control/types';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import { Rule } from 'antd/es/form';
import merge from 'lodash/merge';
import { DtoKeys } from '../../../storage/service/types';

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить место проживания',
  },
  {
    pattern: /^[А-Яа-яЁё0-9\s-.,/]+$/,
    message: 'Неверный формат адреса',
  },
];

const formParams: FormParams = {
  key: DtoKeys.ADDRESS,
  name: 'Место проживания',
  rules,
  hasFeedback: true,
};

export const Address: React.FC<MultimodeControlProps> = (props) => {
  const { formParams: externalFormParams } = props;
  const finalFormParams = merge(
    {},
    formParams, // база
    externalFormParams, // переопределения
  );

  return <MultimodeControl {...props} formParams={finalFormParams} />;
};
