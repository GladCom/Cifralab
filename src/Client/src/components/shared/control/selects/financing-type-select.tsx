import { Rule } from 'antd/es/form';
import config from '../../../../storage/catalog-config/financing-type';
import { FormParams } from '../multi-mode-control/types';
import { MultimodeControlProps } from '../multi-mode-control/multi-mode-control';
import { QueryableSelectControl } from './common/queryable-select-control';
import _ from 'lodash';

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
  const { crud } = config;
  const { formParams: externalFormParams, ...restProps } = props;
  const finalFormParams = _.merge(
      {},
      formParams, // база
      externalFormParams, // переопределения
    );

  return <QueryableSelectControl {...props} crud={crud} formParams={finalFormParams} />;
};
