import { Rule } from 'antd/es/form';
import { FormParams } from '../multi-mode-control/types';
import { MultimodeControlProps } from '../multi-mode-control/multi-mode-control';
import { QueryableSelectControl } from './common/queryable-select-control';
import merge from 'lodash/merge';
import { kindEducationProgramConfig } from '../../../storage/catalog-config/kind-education-program';

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const formParams: FormParams = {
  key: 'KindEducationProgramSelectKey!',
  labelKey: 'name',
  name: 'Вид программы',
  rules,
};

export const KindEducationProgramSelect: React.FC<MultimodeControlProps> = (props) => {
  const { crud } = kindEducationProgramConfig;
  const { formParams: externalFormParams } = props;
  const finalFormParams = merge(
    {},
    formParams, // база
    externalFormParams, // переопределения
  );

  return <QueryableSelectControl {...props} crud={crud} formParams={finalFormParams} />;
};
