import config from '../../../../storage/catalog-config/education-form';
import { ControlByModeMap, DisplayMode, EditableControlProps, FormParams } from '../multi-mode-control/types';
import { Rule } from 'antd/es/form';
import { MultimodeControl, MultimodeControlProps } from '../multi-mode-control/multi-mode-control';
import { EditorFormItemSelectControl } from './common/editor-form-item-select-control';
import { DefaultEditableViewControl, DefaultViewControl } from '../multi-mode-control/default-controls';

const CommonEditorFormItemControl: React.FC<EditableControlProps> = (props) => {
  const { crud } = config;

  return <EditorFormItemSelectControl {...props} crud={crud} />;
};

const controlMap: ControlByModeMap = {
  [DisplayMode.VIEW]: DefaultViewControl,
  [DisplayMode.EDITABLE_VIEW]: DefaultEditableViewControl,
  [DisplayMode.EDITOR]: CommonEditorFormItemControl,
  [DisplayMode.FORM_ITEM]: CommonEditorFormItemControl,
};

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const formParams: FormParams = {
  key: 'EducationFormSelectKey!',
  labelKey: 'name',
  name: 'Форма образования',
  rules,
};

export const EducationFormSelect: React.FC<MultimodeControlProps> = (props) => {
  return <MultimodeControl {...props} controlMap={controlMap} formParams={formParams} />;
};
