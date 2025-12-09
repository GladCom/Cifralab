import { Rule } from 'antd/es/form';
import config from '../../../../storage/catalog-config/type-education';
import { FormParams } from '../multi-mode-control/types';
import { MultimodeControlProps } from '../multi-mode-control/multi-mode-control';
import { QueryableSelectControl } from './common/queryable-select-control';
import merge from 'lodash/merge';

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const formParams: FormParams = {
  key: 'EducationTypeSelectKey!',
  labelKey: 'name',
  name: 'Тип образования',
  rules,
};

export const EducationTypeSelect: React.FC<MultimodeControlProps> = (props) => {
  const { crud } = config;
  const { formParams: externalFormParams } = props;
  const finalFormParams = merge(
    {},
    formParams, // база
    externalFormParams, // переопределения
  );

  return <QueryableSelectControl {...props} crud={crud} formParams={finalFormParams} />;
};
