import { useState, useCallback, ComponentType } from 'react';
import { defaultControlByModeMap, DefaultViewControl, MultiControlProps } from './default-controls';
import merge from 'lodash/merge';
import {
  BaseControlParams,
  MultimodeControlValue,
  DisplayMode,
  ControlByModeMap,
  ControlWrapperByModeMap,
  FormParams,
} from './types';
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
  Control?: ComponentType<MultiControlProps>;
  controlMap?: ControlByModeMap;
  controlWrapperMap?: ControlWrapperByModeMap;
  value?: MultimodeControlValue;
  defaultValue?: MultimodeControlValue;
  placeholder?: string;
  displayMode?: DisplayMode;
  isChanged?: boolean;
  controlParams?: BaseControlParams;
  formParams?: FormParams;
  crud?: unknown;
  options?: unknown;
  setValue?: (value: MultimodeControlValue) => void;
  onChange?: () => void;
  setDisplayMode?: (mode: DisplayMode) => void;
};

export const MultimodeControl: React.FC<MultimodeControlProps> = (props) => {
  const {
    controlMap,
    controlWrapperMap,
    displayMode,
    value,
    controlParams,
    formParams: externalFormParams,
    setValue,
    onChange,
  } = props;
  const [currentDisplayMode, setCurrentDisplayMode] = useState<DisplayMode>(displayMode || DisplayMode.VIEW);
  const [isChanged, setIsChanged] = useState(false);

  const handleSetValue = useCallback(
    (newValue: MultimodeControlValue) => {
      setIsChanged(newValue !== value);

      if (setValue) {
        //  TODO Показыкать уведомение?
        setValue(newValue);
      }
    },
    [value, setValue],
  );

  const handleOnChange = useCallback(() => {
    if (onChange) {
      onChange();
    }
  }, [onChange]);

  const finalFormParams = merge(
    {},
    defaultFormParams, // база
    externalFormParams, // переопределения
  );

  const finalWrapperMap = { ...defaultControlWrapperByModeMap, ...controlWrapperMap };
  const finalControlMap = { ...defaultControlByModeMap, ...controlMap };
  const ControlByMode = finalControlMap[currentDisplayMode] ?? DefaultViewControl;
  const BaseControlWrapperByMode = finalWrapperMap[currentDisplayMode] ?? ViewWrapper;

  return (
    <BaseControlWrapperByMode
      {...props}
      Control={ControlByMode}
      controlMap={finalControlMap}
      controlWrapperMap={finalWrapperMap}
      value={value}
      isChanged={isChanged}
      controlParams={merge({}, defaultControlParams, controlParams)}
      formParams={finalFormParams}
      setValue={handleSetValue}
      onChange={handleOnChange}
      setDisplayMode={setCurrentDisplayMode}
    />
  );
};
