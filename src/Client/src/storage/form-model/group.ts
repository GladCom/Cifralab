import { DateControl } from '../../features/shared/control/date-control';
import { EducationProgramSelect } from '../../features/shared/control/selects/education-program-select';
import { StringControl } from '../../features/shared/control/string-control';
import { FormModel } from './types';

export const groupFormModel: FormModel = {
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
