import StringControl from '../../components/shared/business/common/string-control';

const rules = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const formParams = {
  key: 'name',
  name: 'Форма образования',
  rules,
};

const model = {
  name: { name: 'Форма образования', type: StringControl, show: true, formParams },
};

export default model;
