import { useState, useCallback, ComponentType } from 'react';
import { defaultControlByModeMap, DefaultViewControl } from './default-controls';
import _ from 'lodash';
import { BaseControlParams, MultimodeControlValue, DisplayMode, ControlByModeMap, ControlWrapperByModeMap, FormParams } from './types';
import { defaultControlWrapperByModeMap, ViewWrapper } from './default-control-wrappers';
import { Rule } from 'antd/es/form';

const defaultRules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const defaultFormParams: FormParams = {
  key: 'name',
  name: 'Введите значение',
  // TODO: если будет все ок, то удалить
  // normalize: (value: any) => value,
  rules: defaultRules,
  hasFeedback: true,
};

const defaultControlParams: BaseControlParams = {
  displayOptions: {
    [DisplayMode.VIEW]: true,
    [DisplayMode.EDITABLE_VIEW]: true,
    [DisplayMode.EDITOR]: true,
    [DisplayMode.FORM_ITEM]: true,
  },
};

export type MultimodeControlProps = {
  //  TODO: если поставить вместо any - MultiControlProps, то возникает ошибка, подумать над этим.
  Control: ComponentType<any>;
  controlMap: ControlByModeMap;
  controlWrapperMap: ControlWrapperByModeMap;
  value: MultimodeControlValue;
  defaultValue: MultimodeControlValue;
  placeholder: string;
  displayMode: DisplayMode;
  isChanged: boolean;
  controlParams: BaseControlParams;
  formParams: FormParams;
  setValue: (value: MultimodeControlValue) => void;
  onChange: () => void;
  setDisplayMode: (mode: DisplayMode) => void;
};

export const MultimodeControl: React.FC<MultimodeControlProps> = ({ formParams, controlParams: params, ...props }) => {
  const { controlMap, controlWrapperMap, displayMode, value, setValue } = props;
  const [currentDisplayMode, setCurrentDisplayMode] = useState<DisplayMode>(displayMode);
  const [isChanged, setIsChanged] = useState(false);

  const handleSetValue = useCallback(
    (newValue: MultimodeControlValue) => {
      setIsChanged(newValue !== value);
      setValue(newValue);
    },
    [value, setValue],
  );

  const ControlByMode = { ...defaultControlByModeMap, ...controlMap }[currentDisplayMode] ?? DefaultViewControl;
  const BaseControlWrapperByMode =
    { ...defaultControlWrapperByModeMap, ...controlWrapperMap }[currentDisplayMode] ?? ViewWrapper;

  return (
    <BaseControlWrapperByMode
      {...props}
      Control={ControlByMode}
      setValue={handleSetValue}
      setDisplayMode={setCurrentDisplayMode}
      isChanged={isChanged}
      controlParams={_.merge({}, defaultControlParams, params)}
      formParams={_.merge({}, defaultFormParams, formParams)}
    />
  );
};
