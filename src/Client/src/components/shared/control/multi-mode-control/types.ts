import { ComponentType } from 'react';
import { MultiControlProps } from './default-controls';
import { FormItemProps } from 'antd';
import { MultimodeWrapperControlProps } from './default-control-wrappers';

export enum DisplayMode {
  VIEW = 'viewMode',
  EDITABLE_VIEW = 'editableViewMode',
  EDITOR = 'editorMode',
  FORM_ITEM = 'formItemMode',
  MULTI_SELECT = 'multiselect',
}

export type BaseControlParams = {
  displayOptions: Record<DisplayMode, boolean>;
};

// TODO: возможно никакой labelKey тут и не нужен, вместо него в select использовать key?
export type FormParams = FormItemProps & { key: string; labelKey?: string };

export type MultimodeControlValue = boolean | number | string | null | undefined | string[];

export type ControlByModeMap = Record<DisplayMode, ComponentType<MultiControlProps>>;

export type ControlWrapperByModeMap = Record<DisplayMode, ComponentType<MultimodeWrapperControlProps>>;
