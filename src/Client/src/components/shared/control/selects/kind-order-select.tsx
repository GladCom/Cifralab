import { Rule } from 'antd/es/form';
import { FormParams } from '../multi-mode-control/types';
import { MultimodeControlProps } from '../multi-mode-control/multi-mode-control';
import { QueryableSelectControl } from './common/queryable-select-control';
import merge from 'lodash/merge';
import { kindOrderConfig } from '../../../../storage/catalog-config/kind-order';

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const formParams: FormParams = {
  key: 'KindOrderSelectSelectKey!',
  labelKey: 'name',
  name: 'Тип приказа',
  rules,
};

export const KindOrderSelectSelect: React.FC<MultimodeControlProps> = (props) => {
  const { crud } = kindOrderConfig;
  const { formParams: externalFormParams } = props;
  const finalFormParams = merge(
    {},
    formParams, // база
    externalFormParams, // переопределения
  );

  return <QueryableSelectControl {...props} crud={crud} formParams={finalFormParams} />;
};
