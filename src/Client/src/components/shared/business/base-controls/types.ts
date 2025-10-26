type Mode = 'info' | 'editableInfo' | 'edit' | 'form';

type FormParams = {
  key: string;
  name: string;
  normalize: () => {};
  rules: unknown;
  hasFeedback: boolean;
};

export interface IBaseControl {
  mode: Mode;
  value: unknown;
  controls: unknown;
  params: unknown;
  formParams: FormParams;
  setValue: () => {};
}

export interface IInfoControl {
  value: string;
}

export interface IEditableInfoControl {
  value: string;
}

export interface IEditControl {
  value: string;
  defaultValue: string;
  placeholder: string;
  formParams: FormParams;
  onChange: () => {};
}

export interface IFormControl {
  value: string;
  defaultValue: string;
  placeholder: string;
  formParams: FormParams;
  onChange: () => {};
}
