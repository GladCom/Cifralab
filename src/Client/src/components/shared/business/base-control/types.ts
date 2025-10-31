import { ComponentType } from 'react';

export type DisplayMode = 'view' | 'editableView' | 'editor' | 'formItem';

interface IShowParams {
  view: boolean;
  editableView: boolean;
  formItem: boolean;
  editor: boolean;
  modal: boolean;
}

interface IDefaultParams {
  show: IShowParams;
}

type FormParams = {
  key: string;
  name: string;
  normalize: () => {};
  rules: unknown;
  hasFeedback: boolean;
};

export type valueType = boolean | number | string;

export type MultimodeControl = {
  Control: ComponentType<any>;
  defaultControlMap: IControlByMode;
  value: valueType;
  defaultValue: valueType;
  placeholder: string;
  displayMode: DisplayMode;
  changed: boolean;
  params: IDefaultParams;
  formParams: FormParams;
  setValue: (value: valueType) => void;
  onChange: () => void;
  setDisplayMode: (mode: DisplayMode) => void;
};
export interface IControlByMode {
  view?: ComponentType<MultimodeControl>;
  editableView?: ComponentType<MultimodeControl>;
  formItem?: ComponentType<MultimodeControl>;
  editor?: ComponentType<MultimodeControl>;
}

export interface ViewControl {
  value: valueType;
}

export interface EditableViewControl {
  value: valueType;
}

export interface EditorControl {
  value: valueType;
}

export interface FormItemControl {
  value: valueType;
}
