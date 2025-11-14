import config from '../../../../storage/catalog-config/education-program';
import { MultimodeControl, MultimodeControlProps } from '../multi-mode-control/multi-mode-control';
import { ControlByModeMap, DisplayMode, EditableControlProps, FormParams } from '../multi-mode-control/types';
import { Rule } from 'antd/es/form';
import { DefaultEditableViewControl, DefaultViewControl } from '../multi-mode-control/default-controls';
import { EditorFormItemSelectControl } from './common/editor-form-item-select-control';

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
  key: 'EducationProgramSelectKey!',
  labelKey: 'name',
  name: 'Программа обучения',
  rules,
};

export const EducationProgramSelect: React.FC<MultimodeControlProps> = (props) => {
  return <MultimodeControl {...props} controlMap={controlMap} formParams={formParams} />;
};
