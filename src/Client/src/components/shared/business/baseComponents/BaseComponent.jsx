import React, { useState, useCallback, useEffect } from 'react';
import renderByMode from './renderByMode.js';
import defaultComponentsByMode from './componentsByMode.js';
import _ from 'lodash';
import defaultFormParams from './formParams.js';
import defaultParams from './params.js';

const BaseComponent = ({ formParams, params, ...props }) => {
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

export default BaseComponent;
