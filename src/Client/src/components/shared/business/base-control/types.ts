import { ComponentType } from 'react';

export type DisplayMode = 'viewMode' | 'editableViewMode' | 'editorMode' | 'formItemMode';

type DisplayOptions = {
  view: boolean;
  editableView: boolean;
  formItem: boolean;
  editor: boolean;
};

export type BaseControlParams = {
  displayOptions: DisplayOptions;
};

export type FormParams = {
  key: string;
  name: string;
  normalize: () => any;
  rules: unknown;
  hasFeedback: boolean;
};

export type BaseControlValue = boolean | number | string;

export type MultimodeBaseControlWrapper = {
  Control: ComponentType<any>;
  controlsMap: ControlsByModeMap;
  value: BaseControlValue;
  defaultValue: BaseControlValue;
  placeholder: string;
  displayMode: DisplayMode;
  changed: boolean;
  params: BaseControlParams;
  formParams: FormParams;
  setValue: (value: BaseControlValue) => void;
  onChange: () => void;
  setDisplayMode: (mode: DisplayMode) => void;
};

export type ControlsByModeMap = {
  viewMode?: ComponentType<ViewControlProps>;
  editableViewMode?: ComponentType<EditableViewControlProps>;
  formItemMode?: ComponentType<FormItemControlProps>;
  editorMode?: ComponentType<EditorControlProps>;
};

export type ControlWrapperByModeMap = Record<DisplayMode, MultimodeBaseControlWrapper>;
