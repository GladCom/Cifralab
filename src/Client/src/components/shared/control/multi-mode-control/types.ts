import { ComponentType } from 'react';
import {
  EditableViewControlProps,
  ViewControlProps,
} from './default-controls';
import { FormItemProps } from 'antd';
import { MultimodeControlProps } from './multi-mode-control';

export enum DisplayMode {
  VIEW = 'viewMode',
  EDITABLE_VIEW = 'editableViewMode',
  EDITOR = 'editorMode',
  FORM_ITEM = 'formItemMode',
}

export type BaseControlParams = {
  displayOptions: Record<DisplayMode, boolean>;
};

export type FormParams = FormItemProps & { key: string };

export type MultimodeControlValue = boolean | number | string | null | undefined;

export type ControlByModeMap = {
  viewMode?: ComponentType<ViewControlProps>;
  editableViewMode?: ComponentType<EditableViewControlProps>;
  formItemMode?: ComponentType<EditableControlProps>;
  editorMode?: ComponentType<EditableControlProps>;
};

export type ControlWrapperByModeMap = Record<DisplayMode, ComponentType<MultimodeControlProps>>;

export type EditableControlProps = {
  value: MultimodeControlValue;
  defaultValue: MultimodeControlValue;
  placeholder: string;
  formParams: FormParams;
  //  TODO: a точно ли тут надо передавать значение а не событие?
  onChange: (value: MultimodeControlValue) => void;
};