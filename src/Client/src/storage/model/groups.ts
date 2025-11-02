import StringControl from '../../components/shared/business/common/string-control';
import Date from '../../components/shared/business/common/date';
import EducationProgramSelect from '../../components/shared/business/selects/education-program-select';

const model = {
  name: {
    name: 'Наименование группы',
    type: StringControl,
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
