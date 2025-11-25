export type ControlMode = 'info' | 'editableInfo' | 'edit' | 'form';

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

type AddressFormParams = {
  key: string;
  name: string;
  normalize: () => {};
  rules: unknown;
  hasFeedback: boolean;
};

export type AutoCompleteOption = {
  label: string;
  value: string;
};

type EmailFormParams = {
  key: string;
  name: string;
  rules: unknown;
};

export type FieldProps = {
  value?: string;
  onChange: (value: string) => void;
  formParams: EmailFormParams;
};

export interface IBaseControl {
  mode: ControlMode;
  value: boolean | number | string;
  changed: boolean;
  settings: Settings;
  formParams: FormParams;
  setValue: () => {};
  setMode: () => {};
  onChange: () => {};
};

export type EmailProps = {
  formParams?: Partial<EmailFormParams>;
} & IBaseControl;

export type AddressProps = {
  formParams?: Partial<AddressFormParams>;
} & IBaseControl;

export interface IInfoControl extends IBaseControl {}

export interface IEditableInfoControl extends IBaseControl {}

export interface IEditControl extends IBaseControl {}

export interface IFormControl extends IBaseControl {}
