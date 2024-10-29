import String from '../../components/shared/business/String.jsx';
import EducationProgramSelect from '../../components/shared/business/selects/EducationProgramSelect.jsx'

const model = {
    name: { name: 'Наименование группы', type: String, show: true, required: true },
    educationProgramId: { name: 'Программа обучения', type: EducationProgramSelect, show: true, required: true },
    startDate: { name: 'Дата начала', type: String, show: true, required: true },
    endDate: { name: 'Дата окончания', type: String, show: true, required: true },
};

export default model;