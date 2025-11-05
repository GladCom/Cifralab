import { DateControl } from '../../components/shared/control/date-control';
import { EducationProgramSelect } from '../../components/shared/control/selects/education-program-select';
import { StringControl } from '../../components/shared/control/string-control';

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
    type: DateControl,
  },
  endDate: {
    name: 'Дата окончания',
    type: DateControl,
  },
};

export default model;
