import String from '../../components/shared/business/common/String';
import ScopeOfActivityLevel from '../../components/shared/business/scope-of-activity-level';

const model = {
  nameOfScope: {
    name: 'Сфера деятельности',
    type: String,
  },
  level: {
    name: 'Уровень',
    type: ScopeOfActivityLevel,
  },
};

export default model;
