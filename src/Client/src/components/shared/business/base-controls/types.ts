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
