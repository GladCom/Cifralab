// import { templateParser, templateFormatter, parseDigit } from 'input-format';
import { MultimodeControl, MultimodeControlProps } from '../multi-mode-control/multi-mode-control';
import { MultimodeControlValue } from '../multi-mode-control/types';

//  TODO:   разобраться с форматтером
// const TEMPLATE = 'xxx-xxx-xxx xx';
// const parse = templateParser(TEMPLATE, parseDigit);
// const format = templateFormatter(TEMPLATE);

const formatSnils = (input: string) => {
  const digits = input.replace(/\D/g, '');
  const limitedDigits = digits.slice(0, 11);
  return limitedDigits.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, '$1-$2-$3 $4');
};

const rules = [
  {
    required: true,
    message: 'Необходимо заполнить СНИЛС',
  },
  {
    pattern: /^\d{3}-\d{3}-\d{3} \d{2}$/,
    message: 'Некорректно заполнен СНИЛС',
  },
];

const formParams = {
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

const Snils: React.FC<MultimodeControlProps> = (props) => (
  <MultimodeControl
    {...props}
    formParams={formParams}
  />
);

export default Snils;
