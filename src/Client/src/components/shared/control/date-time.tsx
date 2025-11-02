import { useCallback } from 'react';
import { DatePicker, Typography } from 'antd';
import dayjs from 'dayjs';
import { ControlByModeMap, DisplayMode, EditableControlProps, FormParams } from './multi-mode-control/types';
import { Rule } from 'antd/es/form';
import { ViewControlProps } from './multi-mode-control/default-controls';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';

const { Text } = Typography;

const ViewControl: React.FC<ViewControlProps> = ({ value }) => {
  return <Text>{dayjs(String(value ?? 'Неверный тип данных')).format('DD.MM.YYYY HH:mm:ss')}</Text>;
};

const CommonEditorFormItemControl: React.FC<EditableControlProps> = ({ defaultValue, onChange, formParams }) => {
  const { key } = formParams;

  const formattValue = useCallback(
    (date: dayjs.Dayjs) => {
      const formattedDateString = dayjs(date).format('YYYY-MM-DDTHH:mm:ss');
      onChange(formattedDateString);
    },
    [onChange],
  );

  return (
    <DatePicker
      key={key}
      defaultValue={dayjs(String(defaultValue ?? 'Неверный тип данных'))}
      showTime
      format={{
        format: 'DD.MM.YYYY HH:mm:ss',
        type: 'mask',
      }}
      onChange={formattValue}
    />
  );
};

const controlMap: ControlByModeMap = {
  [DisplayMode.VIEW]: ViewControl,
  [DisplayMode.EDITABLE_VIEW]: ViewControl,
  [DisplayMode.EDITOR]: CommonEditorFormItemControl,
  [DisplayMode.FORM_ITEM]: CommonEditorFormItemControl,
};

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить дату',
  },
];

const formParams: FormParams = {
  key: 'date',
  name: 'Введите дату',
  //normalize: (value) => value,
  rules,
  hasFeedback: true,
};

export const DateTime: React.FC<MultimodeControlProps> = (props) => {
  return <MultimodeControl {...props} controlMap={controlMap} formParams={formParams} />;
};
