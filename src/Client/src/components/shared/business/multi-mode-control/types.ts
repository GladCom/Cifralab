import { ComponentType } from 'react';
import {
  EditableViewControlProps,
  EditorControlProps,
  FormItemControlProps,
  ViewControlProps,
} from './default-controls';
import { MultimodeBaseControlWrapperProps } from './default-control-wrappers';

export enum DisplayMode {
  VIEW = 'viewMode',
  EDITABLE_VIEW = 'editableViewMode',
  EDITOR = 'editorMode',
  FORM_ITEM = 'formItemMode',
}

export type BaseControlParams = {
  displayOptions: Record<DisplayMode, boolean>;
};

export type FormParams = {
  key: string;
  name: string;
  normalize: () => any;
  rules: unknown;
  hasFeedback: boolean;
};

export type BaseControlValue = boolean | number | string;

export type ControlByModeMap = {
  viewMode?: ComponentType<ViewControlProps>;
  editableViewMode?: ComponentType<EditableViewControlProps>;
  formItemMode?: ComponentType<FormItemControlProps>;
  editorMode?: ComponentType<EditorControlProps>;
};

export type ControlWrapperByModeMap = Record<DisplayMode, ComponentType<MultimodeBaseControlWrapperProps>>;
