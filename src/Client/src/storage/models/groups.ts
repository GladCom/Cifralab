import String from '../../components/shared/business/common/string';
import Date from '../../components/shared/business/common/_date';
import EducationProgramSelect from '../../components/shared/business/selects/education-program-select';

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
