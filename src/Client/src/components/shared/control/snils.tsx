import { Rule } from 'antd/es/form';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import { FormParams, MultimodeControlValue } from './multi-mode-control/types';

const formatSnils = (input: string) => {
  const digits = input.replace(/\D/g, '');
  const limitedDigits = digits.slice(0, 11);
  return limitedDigits.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, '$1-$2-$3 $4');
};

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить СНИЛС',
  },
  {
    pattern: /^\d{3}-\d{3}-\d{3} \d{2}$/,
    message: 'Некорректно заполнен СНИЛС',
  },
];

const formParams: FormParams = {
  key: 'snils',
  name: 'СНИЛС',
  normalize: (value: MultimodeControlValue) => {
    if (typeof value === 'string') {
      return formatSnils(value);
    }
    // Для других типов вернуть как есть.
    return value;
  },
  rules: rules,
};

export const Snils: React.FC<MultimodeControlProps> = (props) => (
  <MultimodeControl {...props} formParams={formParams} />
);
