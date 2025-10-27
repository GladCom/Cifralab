import { useState, useCallback } from 'react';
import defaultControlByMode from './components-by-mode';
import _ from 'lodash';
import defaultFormParams from './form-params';
import View from './view';
import EditableView from './editable-view';
import Editor from './editor';
import FormItem from './form-item';
import { DisplayMode, IControlByMode, MultimodeControl, valueType } from './types';

const defaultParams = {
  show: {
    info: true,
    editableInfo: true,
    form: true,
    edit: true,
    modal: true,
  },
};

const controlByMode: IControlByMode = {
  view: View,
  editableView: EditableView,
  formItem: FormItem,
  editor: Editor,
};

export const BaseControl: React.FC<MultimodeControl> = ({ formParams, params, ...props }) => {
  const { defaultControlMap, displayMode, value, setValue } = props;
  const [currentMode, setCurrentMode] = useState<DisplayMode>(displayMode);
  const [changed, setChanged] = useState(false);

  const handleSetValue = useCallback(
    (newValue: valueType) => {
      setChanged(newValue !== value);
      setValue(newValue);
    },
    [value, setValue],
  );

  const ComponentByMode = { ...defaultControlByMode, ...defaultControlMap }[currentMode] ?? View;
  const MultimodeBaseControl = controlByMode[currentMode] ?? View;

  return (
    <MultimodeBaseControl
      {...props}
      Control={ComponentByMode}
      setValue={handleSetValue}
      setDisplayMode={setCurrentMode}
      changed={changed}
      params={_.merge({}, defaultParams, params)}
      formParams={_.merge({}, defaultFormParams, formParams)}
    />
  );
};
