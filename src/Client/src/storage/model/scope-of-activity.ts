import StringControl from '../../components/shared/business/common/string-control';
import ScopeOfActivityLevel from '../../components/shared/business/scope-of-activity-level';

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
