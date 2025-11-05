import { ScopeOfActivityLevel } from '../../components/shared/control/scope-of-activity-level';
import { StringControl } from '../../components/shared/control/string-control';

const model = {
  nameOfScope: {
    name: 'Сфера деятельности',
    type: StringControl,
  },
  level: {
    name: 'Уровень',
    type: ScopeOfActivityLevel,
  },
};

export default model;
