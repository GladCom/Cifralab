import { ScopeOfActivityLevel } from '../../components/shared/control/scope-of-activity-level';
import { StringControl } from '../../components/shared/control/string-control';
import { FormModel } from './types';

export const scopeOfActivityFormModel: FormModel = {
  nameOfScope: {
    name: 'Сфера деятельности',
    type: StringControl,
  },
  level: {
    name: 'Уровень',
    type: ScopeOfActivityLevel,
  },
};
