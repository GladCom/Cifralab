import { Rule } from 'antd/es/form';
import { FormParams } from './multi-mode-control/types';
import { MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import { DateControl } from './date-control';

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить дату рождения',
  },
];

const formParams: FormParams = {
  key: 'birthDate',
  name: 'Введите дату рождения',
  rules,
  hasFeedback: true,
};

export const BirthDate: React.FC<MultimodeControlProps> = (props) => {
  return <DateControl {...props} defaultValue={'1990-03-05'} formParams={formParams} />;
};
