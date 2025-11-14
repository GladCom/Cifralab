import { Rule } from 'antd/es/form';
import { FormParams } from '../../components/shared/control/multi-mode-control/types';
import { StringControl } from '../../components/shared/control/string-control';
import { FormModel } from './types';

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const formParams: FormParams = {
  key: 'name',
  name: 'Форма образования',
  rules,
};

export const educationFormFormModel: FormModel = {
  name: { name: 'Форма образования', type: StringControl, formParams },
};
