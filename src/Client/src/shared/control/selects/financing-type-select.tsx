import { Rule } from 'antd/es/form';
import { FormParams } from '../multi-mode-control/types';
import { MultimodeControlProps } from '../multi-mode-control/multi-mode-control';
import { QueryableSelectControl } from './common/queryable-select-control';
import merge from 'lodash/merge';
import { financingTypeConfig } from '../../../storage/catalog-config/financing-type';

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const formParams: FormParams = {
  key: 'FinancingTypeSelectKey!',
  labelKey: 'sourceName',
  name: 'Тип финансирования',
  rules,
};

export const FinancingTypeSelect: React.FC<MultimodeControlProps> = (props) => {
  const { crud } = financingTypeConfig;
  const { formParams: externalFormParams } = props;
  const finalFormParams = merge(
    {},
    formParams, // база
    externalFormParams, // переопределения
  );

  return <QueryableSelectControl {...props} crud={crud} formParams={finalFormParams} />;
};
