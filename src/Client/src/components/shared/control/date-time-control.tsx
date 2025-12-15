import { useCallback } from 'react';
import { DatePicker, Typography } from 'antd';
import dayjs from 'dayjs';
import { ControlByModeMap, DisplayMode, FormParams } from './multi-mode-control/types';
import { Rule } from 'antd/es/form';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import merge from 'lodash/merge';
import { MultiControlProps } from './multi-mode-control/default-controls';

const { Text } = Typography;

const ViewControl: React.FC<MultiControlProps> = ({ value }) => {
  return <Text>{dayjs(String(value ?? 'Неверный тип данных')).format('DD.MM.YYYY HH:mm:ss')}</Text>;
};

const CommonEditorFormItemControl: React.FC<MultiControlProps> = ({ defaultValue, onChange, formParams }) => {
  if (!formParams) {
    throw new Error('CommonEditorFormItemControl: "formParams" is required but was not provided.');
  }
  if (!onChange) {
    throw new Error('CommonEditorFormItemControl: "onChange" is required but was not provided.');
  }

  const { key } = formParams;

  const formattValue = useCallback(
    (date: dayjs.Dayjs | null, _dateString: string) => {
      if (!date) {
        onChange(null);
        return;
      }

      onChange(dayjs(date).format('YYYY-MM-DDTHH:mm:ss'));
    },
    [onChange],
  );

  return (
    <DatePicker
      key={key}
      defaultValue={defaultValue ? dayjs(defaultValue) : null}
      showTime
      format="DD.MM.YYYY HH:mm:ss"
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
  rules,
  hasFeedback: true,
};

export const DateTimeControl: React.FC<MultimodeControlProps> = (props) => {
  const { formParams: externalFormParams, ...restProps } = props;

  // Такой финт нужен для переопределения formParams при переиспользовании компонента.
  const finalFormParams = merge(
    {},
    formParams, // база
    externalFormParams, // переопределения
  );

  return <MultimodeControl {...restProps} controlMap={controlMap} formParams={finalFormParams} />;
};
