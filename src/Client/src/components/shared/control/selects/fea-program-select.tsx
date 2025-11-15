import { Rule } from 'antd/es/form';
import config from '../../../../storage/catalog-config/fea-program';
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
  key: 'FEAProgramSelectKey!',
  labelKey: 'name',
  name: 'ВЭД программа',
  rules,
};

export const FEAProgramSelect: React.FC<MultimodeControlProps> = (props) => {
  const { crud } = config;
  return <QueryableSelectControl {...props} crud={crud} formParams={formParams} />;
};
