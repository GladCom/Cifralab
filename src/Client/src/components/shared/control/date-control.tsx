import React, { useCallback } from 'react';
import { DatePicker, Typography } from 'antd';
import dayjs from 'dayjs';
import { MultiControlProps } from './multi-mode-control/default-controls';
import { ControlByModeMap, DisplayMode, FormParams } from './multi-mode-control/types';
import { MultimodeControl, MultimodeControlProps } from './multi-mode-control/multi-mode-control';
import { Rule } from 'antd/es/form';
import merge from 'lodash/merge';

const { Text } = Typography;

const ViewControl: React.FC<MultiControlProps> = ({ value }) => {
  return <Text>{dayjs(String(value ?? 'Неверный тип данных')).format('DD.MM.YYYY')}</Text>;
};

const CommonEditorFormItemControl: React.FC<MultiControlProps> = ({
  defaultValue,
  onChange,
  formParams,
  placeholder,
}) => {
  if (!formParams) 
  {
    throw new Error('formParams is required');
  }
  if (!onChange)
  {   
    throw new Error('onChange is required');
  }
  const { key } = formParams;

  const formattValue = useCallback(
    (date: dayjs.Dayjs | null, _dateString: string) => {
      if (!date) {
        onChange(null);
        return;
      }
      onChange(dayjs(date).format('YYYY-MM-DD'));
    },
    [onChange],
  );

  return (
    <DatePicker
      key={key}
      placeholder={placeholder}
      defaultValue={defaultValue ? dayjs(defaultValue) : null}
      format="DD.MM.YYYY"
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

export const DateControl: React.FC<MultimodeControlProps> = (props) => {
  const { formParams: externalFormParams, ...restProps } = props;

  // Такой финт нужен для переопределения formParams при переиспользовании компонента,
  // например в компоненте BirthDate
  const finalFormParams = merge(
    {},
    formParams, // база
    externalFormParams, // переопределения
  );

  return <MultimodeControl {...restProps} controlMap={controlMap} formParams={finalFormParams} />;
};
