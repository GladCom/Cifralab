import String from '../../components/shared/business/common/String';
import ScopeOfActivityLevel from '../../components/shared/business/ScopeOfActivityLevel';

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
