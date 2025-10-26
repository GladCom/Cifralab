import { useState, useCallback } from 'react';
import renderByMode from './render-by-mode';
import defaultComponentsByMode from './components-by-mode';
import _ from 'lodash';
import defaultFormParams from './form-params';
import defaultParams from './params';

const BaseControl = ({ formParams, params, ...props }) => {
  const { components, mode, value, setValue } = props;
  const [currentMode, setCurrentMode] = useState(mode);
  const [changed, setChanged] = useState(false);

  const handleSetValue = useCallback(
    (newValue) => {
      setChanged(newValue !== value);
      setValue(newValue);
    },
    [value, setValue],
  );

  const ComponentByMode = { ...defaultComponentsByMode, ...components }[currentMode];
  const MultimodeComponent = renderByMode[currentMode] ?? renderByMode.info;

  return (
    <MultimodeComponent
      Component={ComponentByMode}
      props={{
        ...props,
        setValue: handleSetValue,
        setMode: setCurrentMode,
        changed,
        params: _.merge({}, defaultParams, params),
        formParams: _.merge({}, defaultFormParams, formParams),
      }}
    />
  );
};

export default BaseControl;
