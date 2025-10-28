import String from '../../components/shared/business/common/string';

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
  name: { name: 'Форма образования', type: String, show: true, formParams },
};

export default model;
