import { ControlByModeMap, DisplayMode, FormParams } from '../multi-mode-control/types';
import {
  DefaultEditableViewControl,
  DefaultEditorControl,
  DefaultFormItemControl,
  DefaultViewControl,
} from '../multi-mode-control/default-controls';
import { MultimodeControl, MultimodeControlProps } from '../multi-mode-control/multi-mode-control';
import { Rule } from 'antd/es/form';

const controlMap: ControlByModeMap = {
  [DisplayMode.VIEW]: DefaultViewControl,
  [DisplayMode.EDITABLE_VIEW]: DefaultEditableViewControl,
  [DisplayMode.EDITOR]: DefaultEditorControl,
  [DisplayMode.FORM_ITEM]: DefaultFormItemControl,
};

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить место проживания',
  },
];

const formParams: FormParams = {
  key: 'address',
  name: 'Место проживания',
  rules,
  hasFeedback: true,
};

export const Address: React.FC<MultimodeControlProps> = (props) => {
  return <MultimodeControl {...props} formParams={formParams} />;
};
