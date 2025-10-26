import BaseControl from './base-controls/base-control';

const components = {
  form: DefaultFormComponent,
  edit: DefaultEditComponent,
};

const rules = [
  {
    required: true,
    message: 'Необходимо заполнить email',
  },
  {
    type: 'email',
    message: 'Некорректно заполнен email',
  },
];

const formParams = {
  key: 'email',
  name: 'E-mail',
  rules,
};

const StartEndDate = (props) => (
  <BaseControl
    {...{
      ...props,
      components,
      formParams,
    }}
  />
);

export default StartEndDate;
