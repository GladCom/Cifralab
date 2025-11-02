import { Select, Typography } from 'antd';
import { BaseControl } from '../base-controls/base-control';

const { Text } = Typography;

const options = [
  { value: 0, label: 'Не сдано' },
  { value: 1, label: 'Тестовое задание' },
  { value: 2, label: 'Собеседование' },
  { value: 3, label: 'Выполнено' },
];

const keyValueMap = {
  0: 'Не сдано',
  1: 'Тестовое задание',
  2: 'Собеседование',
  3: 'Выполнено',
};

const rules = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const formParams = {
  labelKey: 'statusEntrancExams',
  name: 'Выберите значение',
  rules,
};

const DefaultInfoComponent = ({ value }) => <Text>{keyValueMap[value]}</Text>;

const DefaultSelectComponent = ({ value, onChange, formParams }) => {
  const { key } = formParams;

  return <Select key={key} defaultValue={value} style={{ minWidth: '200px' }} options={options} onChange={onChange} />;
};

const components = {
  info: DefaultInfoComponent,
  editableInfo: DefaultInfoComponent,
  form: DefaultSelectComponent,
  edit: DefaultSelectComponent,
};

const StatusEntrancExamsSelect = (props) => (
  <BaseControl
    {...{
      components,
      formParams,
      ...props,
    }}
  />
);

export default StatusEntrancExamsSelect;
