import { Rule } from 'antd/es/form';
import { FormParams } from '../multi-mode-control/types';
import { MultimodeControlProps } from '../multi-mode-control/multi-mode-control';
import { QueryableSelectControl } from './common/queryable-select-control';
import merge from 'lodash/merge';
import { studentConfig } from '../../../../storage/catalog-config/student';

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const formParams: FormParams = {
  key: 'StudentSelectKey!',
  labelKey: 'fullName',
  name: 'Обучающийся',
  rules,
};

export const StudentSelect: React.FC<MultimodeControlProps> = (props) => {
  const { crud } = studentConfig;
  const { formParams: externalFormParams } = props;
  const finalFormParams = merge(
    {},
    formParams, // база
    externalFormParams, // переопределения
  );

  return <QueryableSelectControl {...props} crud={crud} formParams={finalFormParams} />;
};
