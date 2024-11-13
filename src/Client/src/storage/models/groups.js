import String from '../../components/shared/business/common/String.jsx';
import Date from '../../components/shared/business/common/Date.jsx';
import EducationProgramSelect from '../../components/shared/business/selects/EducationProgramSelect.jsx'

const model = {
    name: { 
        name: 'Наименование группы',
        type: String,
    },
    educationProgramId: { 
        name: 'Программа обучения', 
        type: EducationProgramSelect,
    },
    startDate: { 
        name: 'Дата начала', 
        type: Date, 
    },
    endDate: { 
        name: 'Дата окончания', 
        type: Date,
    },
};

export default model;