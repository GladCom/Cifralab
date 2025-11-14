import { Address } from '../../components/shared/control/address';
import { BirthDate } from '../../components/shared/control/birth-date';
import { CheckBox } from '../../components/shared/control/check-box';
import { DateTimeView } from '../../components/shared/control/date-time-view';
import { Email } from '../../components/shared/control/email';
import { PhoneNumber } from '../../components/shared/control/phone-number';
import { EducationProgramSelect } from '../../components/shared/control/selects/education-program-select';
import { EducationTypeSelect } from '../../components/shared/control/selects/education-type-select';
import { ScopeOfActivitySelect } from '../../components/shared/control/selects/scope-of-activity-select';
import { StatusEntrancExamsSelect } from '../../components/shared/control/selects/status-entranc-exams-select';
import { StringControl } from '../../components/shared/control/string-control';
import { FormModel } from './types';

export const personRequestFormModel: FormModel = {
  family: {
    name: 'Фамилия',
    type: StringControl,
  },
  name: {
    name: 'Имя',
    type: StringControl,
  },
  patron: {
    name: 'Отчество',
    type: StringControl,
  },
  dateOfCreate: {
    name: 'Дата и время заявки',
    type: DateTimeView,
  },
  educationProgramId: {
    name: 'Программа',
    type: EducationProgramSelect,
  },
  typeEducationId: {
    name: 'Уровень образования',
    type: EducationTypeSelect,
  },
  iT_Experience: {
    name: 'Опыт в IT',
    type: StringControl,
  },
  speciality: {
    name: 'Специальность',
    type: StringControl,
  },
  projects: {
    name: 'Проекты',
    type: StringControl,
  },
  statusEntrancExams: {
    name: 'Тестовое задание',
    type: StatusEntrancExamsSelect,
  },
  birthDate: {
    name: 'Дата рождения',
    type: BirthDate,
  },
  address: {
    name: 'Место проживания',
    type: Address,
  },
  phone: {
    name: 'Телефон',
    type: PhoneNumber,
  },
  email: {
    name: 'E-mail',
    type: Email,
  },
  scopeOfActivityLevelOneId: {
    name: 'Сфера деятельности уровень 1',
    type: ScopeOfActivitySelect,
  },
  scopeOfActivityLevelTwoId: {
    name: 'Сфера деятельности уровень 2',
    type: ScopeOfActivitySelect,
    formParams: {
      key: 'ScopeOfActivitySelect2Key',
      rules: [
        {
          required: false,
        },
      ],
    },
  },
  agreement: {
    name: 'Согласие на обработку перс. даннных',
    type: CheckBox,
  },
};
