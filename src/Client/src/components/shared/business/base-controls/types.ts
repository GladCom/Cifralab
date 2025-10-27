type Mode = 'info' | 'editableInfo' | 'edit' | 'form';

type ShowParams = {
  info: boolean;
  editableInfo: boolean;
  form: boolean;
  edit: boolean;
  modal: boolean;
};

type ControlsByMode = {
  info: IBaseControl;
  editableInfo: IBaseControl;
  form: IBaseControl;
  filter?: IBaseControl;
  edit: IBaseControl;
  modal?: IBaseControl;
};

type Settings = {
  show: ShowParams;
  controlsByMode: ControlsByMode;
};

type FormParams = {
  key: string;
  name: string;
  normalize: () => {};
  rules: unknown;
  hasFeedback: boolean;
};

export interface IBaseControl {
  mode: Mode;
  value: boolean | number | string;
  changed: boolean;
  settings: Settings;
  formParams: FormParams;
  setValue: () => {};
  setMode: () => {};
  onChange: () => {};
}

export interface IInfoControl extends IBaseControl {}

export interface IEditableInfoControl extends IBaseControl {}

export interface IEditControl extends IBaseControl {}

export interface IFormControl extends IBaseControl {}
