import { Rule } from 'antd/es/form';
import { DefaultEditableViewControl, DefaultViewControl } from '../../multi-mode-control/default-controls';
import { MultimodeControl, MultimodeControlProps } from '../../multi-mode-control/multi-mode-control';
import { ControlByModeMap, ControlWrapperByModeMap, DisplayMode, FormParams } from '../../multi-mode-control/types';
import {
  EditableViewSelectControlWrapper,
  EditorSelectControlWrapper,
  FormItemSelectControlWrapper,
  ViewSelectControlWrapper,
} from './select-control-wrappers';
import { EditorFormItemSelectControl } from './select-controls';
import merge from 'lodash/merge';

const defaultControlByModeMap: ControlByModeMap = {
  [DisplayMode.VIEW]: DefaultViewControl,
  [DisplayMode.EDITABLE_VIEW]: DefaultEditableViewControl,
  [DisplayMode.EDITOR]: EditorFormItemSelectControl,
  [DisplayMode.FORM_ITEM]: EditorFormItemSelectControl,
};

const defaultControlWrapperByModeMap: ControlWrapperByModeMap = {
  [DisplayMode.VIEW]: ViewSelectControlWrapper,
  [DisplayMode.EDITABLE_VIEW]: EditableViewSelectControlWrapper,
  [DisplayMode.EDITOR]: EditorSelectControlWrapper,
  [DisplayMode.FORM_ITEM]: FormItemSelectControlWrapper,
};

const rules: Rule[] = [
  {
    required: true,
    message: 'Необходимо заполнить это поле',
  },
];

const formParams: FormParams = {
  key: 'defaultKey',
  labelKey: 'name',
  name: 'Какое-то имя',
  rules,
};

export const QueryableSelectControl: React.FC<MultimodeControlProps> = (props) => {
  const { formParams: externalFormParams, crud, controlMap, controlWrapperMap, ...restProps } = props;

  // Такой финт нужен для переопределения formParams при переиспользовании компонента,
  // например в компоненте BirthDate
  const finalFormParams = merge(
    {},
    formParams, // база
    externalFormParams, // переопределения
  );

  const finalWrapperMap = { ...defaultControlWrapperByModeMap, ...controlWrapperMap };
  const finalControlMap = { ...defaultControlByModeMap, ...controlMap };

  return (
    <MultimodeControl
      {...restProps}
      formParams={finalFormParams}
      controlWrapperMap={finalWrapperMap}
      crud={crud}
      controlMap={finalControlMap}
    />
  );
};
