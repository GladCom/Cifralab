import config from '../../../../storage/catalog-config/education-form';
import { FormParams } from '../multi-mode-control/types';
import { Rule } from 'antd/es/form';
import { MultimodeControlProps } from '../multi-mode-control/multi-mode-control';
import { QueryableSelectControl } from './common/queryable-select-control';

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const formParams: FormParams = {
  key: 'EducationFormSelectKey!',
  labelKey: 'name',
  name: 'Форма образования',
  rules,
};

export const EducationFormSelect: React.FC<MultimodeControlProps> = (props) => {
  const { crud } = config;
  return <QueryableSelectControl {...props} crud={crud} formParams={formParams} />;
};
