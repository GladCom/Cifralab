import config from '../../../../storage/catalog-config/education-program';
import { MultimodeControlProps } from '../multi-mode-control/multi-mode-control';
import { FormParams } from '../multi-mode-control/types';
import { Rule } from 'antd/es/form';
import { QueryableSelectControl } from './common/queryable-select-control';

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const formParams: FormParams = {
  key: 'EducationProgramSelectKey!',
  labelKey: 'name',
  name: 'Программа обучения',
  rules,
};

export const EducationProgramSelect: React.FC<MultimodeControlProps> = (props) => {
  const { crud } = config;

  return <QueryableSelectControl {...props} crud={crud} formParams={formParams} />;
};
