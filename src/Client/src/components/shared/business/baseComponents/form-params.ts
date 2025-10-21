const defaultRules = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const defaultFormParams = {
  key: 'name',
  name: 'Введите значение',
  normalize: (value) => value,
  rules: defaultRules,
  hasFeedback: true,
};

export default defaultFormParams;
