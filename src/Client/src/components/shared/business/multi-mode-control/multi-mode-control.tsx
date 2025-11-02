import { useState, useCallback } from 'react';
import { defaultControlByModeMap, DefaultViewControl } from './default-controls';
import _ from 'lodash';
import { BaseControlParams, BaseControlValue, DisplayMode } from './types';
import { defaultControlWrapperByModeMap, MultimodeBaseControlWrapperProps, ViewWrapper } from './default-control-wrappers';

const defaultRules = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const defaultFormParams = {
  key: 'name',
  name: 'Введите значение',
  normalize: (value: any) => value,
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

export const MultimodeControl: React.FC<MultimodeBaseControlWrapperProps> = ({ formParams, controlParams: params, ...props }) => {
  const { controlMap, controlWrapperMap, displayMode, value, setValue } = props;
  const [currentDisplayMode, setCurrentDisplayMode] = useState<DisplayMode>(displayMode);
  const [isChanged, setIsChanged] = useState(false);

  const handleSetValue = useCallback(
    (newValue: BaseControlValue) => {
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
