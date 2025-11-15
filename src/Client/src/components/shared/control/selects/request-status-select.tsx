import { Rule } from 'antd/es/form';
import config from '../../../../storage/catalog-config/request-status';
import { FormParams } from '../multi-mode-control/types';
import { MultimodeControlProps } from '../multi-mode-control/multi-mode-control';
import { QueryableSelectControl } from './common/queryable-select-control';

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const formParams: FormParams = {
  key: 'RequestStatusSelectKey!',
  labelKey: 'name',
  name: 'Статус заявки',
  rules,
};

export const RequestStatusSelect: React.FC<MultimodeControlProps> = (props) => {
  const { crud } = config;
  return <QueryableSelectControl {...props} crud={crud} formParams={formParams} />;
};
