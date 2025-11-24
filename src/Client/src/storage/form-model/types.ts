import { MultimodeControlProps } from '../../components/shared/control/multi-mode-control/multi-mode-control';
import { BaseControlParams, FormParams } from '../../components/shared/control/multi-mode-control/types';

export type FormModel = Record<string, FormControlModel>;

export type FormControlModel = {
  name: string;
  type: React.FC<MultimodeControlProps>;
  controlParams?: BaseControlParams;
  formParams?: FormParams;
};

