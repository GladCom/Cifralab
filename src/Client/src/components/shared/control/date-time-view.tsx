import { Rule } from 'antd/es/form';
import { FormParams } from './multi-mode-control/types';
import { MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import { DateTimeControl } from './date-time-control';

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить дату создания заявки',
  },
];

const formParams: FormParams = {
  key: 'dateOfCreate',
  name: 'Введите дату создания заявки',
  rules,
  hasFeedback: true,
};

// TODO: Какое-то странное имя компонента, судя по параметрам в formParams, надо переименовать
// и возможно перенести сам компонент куда-то.
export const DateTimeView: React.FC<MultimodeControlProps> = (props) => {
  return <DateTimeControl {...props} defaultValue={'2025-03-05T00:00:00'} formParams={formParams} />;
};
