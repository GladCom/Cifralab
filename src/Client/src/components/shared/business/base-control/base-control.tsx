import { useState, useCallback } from 'react';
import { defaultControlsByModeMap, DefaultViewControl } from './default-controls';
import _ from 'lodash';
import { ViewWrapper } from './view-wrapper';
import { EditableViewWrapper } from './editable-view-wrapper';
import { EditorWrapper } from './editor-wrapper';
import { FormItemWrapper } from './form-item-wrapper';
import {
  DisplayMode,
  BaseControlParams,
  MultimodeBaseControlWrapper,
  BaseControlValue,
  ControlWrapperByModeMap,
} from './types';

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
    view: true,
    editableView: true,
    formItem: true,
    editor: true,
  },
};

const controlWrapperByModeMap: ControlWrapperByModeMap = {
  viewMode: ViewWrapper,
  editableViewMode: EditableViewWrapper,
  formItemMode: FormItemWrapper,
  editorMode: EditorWrapper,
};

export const BaseControl: React.FC<MultimodeBaseControlWrapper> = ({ formParams, params, ...props }) => {
  const { controlsMap, displayMode, value, setValue } = props;
  const [currentMode, setCurrentMode] = useState<DisplayMode>(displayMode);
  const [changed, setChanged] = useState(false);

  const handleSetValue = useCallback(
    (newValue: BaseControlValue) => {
      setChanged(newValue !== value);
      setValue(newValue);
    },
    [value, setValue],
  );

  const ControlByMode = { ...defaultControlsByModeMap, ...controlsMap }[currentMode] ?? DefaultViewControl;
  const BaseControlWrapper = controlWrapperByModeMap[currentMode] ?? ViewWrapper;

  return (
    <BaseControlWrapper
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
