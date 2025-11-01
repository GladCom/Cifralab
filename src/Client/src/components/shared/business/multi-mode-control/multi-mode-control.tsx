import { useState, useCallback, ComponentType } from 'react';
import { defaultControlByModeMap, DefaultViewControl } from './default-controls';
import _ from 'lodash';
import { ViewWrapper } from './view-wrapper';
import { BaseControlParams, BaseControlValue, ControlByModeMap, DisplayMode } from './types';
import { defaultControlWrapperByModeMap, MultimodeBaseControlWrapperProps } from './default-control-wrappers';

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

const defaultParams: BaseControlParams = {
  displayOptions: {
    [DisplayMode.VIEW]: true,
    [DisplayMode.EDITABLE_VIEW]: true,
    [DisplayMode.EDITOR]: true,
    [DisplayMode.FORM_ITEM]: true,
  },
};

export const MultimodeControl: React.FC<MultimodeBaseControlWrapperProps> = ({ formParams, params, ...props }) => {
  const { controlMap, controlWrapperMap, displayMode, value, setValue } = props;
  const [currentMode, setCurrentMode] = useState<DisplayMode>(displayMode);
  const [changed, setChanged] = useState(false);

  const handleSetValue = useCallback(
    (newValue: BaseControlValue) => {
      setChanged(newValue !== value);
      setValue(newValue);
    },
    [value, setValue],
  );

  const ControlByMode = { ...defaultControlByModeMap, ...controlMap }[currentMode] ?? DefaultViewControl;
  const BaseControlWrapperByMode =
    { ...defaultControlWrapperByModeMap, ...controlWrapperMap }[currentMode] ?? ViewWrapper;

  return (
    <BaseControlWrapperByMode
      {...props}
      Control={ControlByMode}
      setValue={handleSetValue}
      setDisplayMode={setCurrentMode}
      changed={changed}
      params={_.merge({}, defaultParams, params)}
      formParams={_.merge({}, defaultFormParams, formParams)}
    />
  );
};
