import String from '../../components/shared/business/common/String.jsx';
import ScopeOfActivityLevel from '../../components/shared/business/ScopeOfActivityLevel.jsx';

const model = {
    nameOfScope: { 
        name: 'Сфера деятельности', 
        type: String,
    },
    level: { 
        name: 'Уровень', 
        type: ScopeOfActivityLevel,
    }
};

export default model;