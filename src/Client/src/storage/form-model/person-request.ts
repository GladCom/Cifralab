import { Address } from '../../features/shared/control/address';
import { BirthDate } from '../../features/shared/control/birth-date';
import { CheckBox } from '../../features/shared/control/check-box';
import { DateTimeView } from '../../features/shared/control/date-time-view';
import { Email } from '../../features/shared/control/email';
import { PhoneNumber } from '../../features/shared/control/phone-number';
import { EducationProgramSelect } from '../../features/shared/control/selects/education-program-select';
import { EducationTypeSelect } from '../../features/shared/control/selects/education-type-select';
import { ScopeOfActivitySelect } from '../../features/shared/control/selects/scope-of-activity-select';
import { StatusEntrancExamsSelect } from '../../features/shared/control/selects/status-entranc-exams-select';
import { StringControl } from '../../features/shared/control/string-control';
import { DtoKeys } from '../service/types';
import { FormModel } from './types';

export const personRequestFormModel: FormModel = {
  family: {
    name: 'Фамилия',
    type: StringControl,
    formParams: {
      key: DtoKeys.FAMILY,
      rules: [
        {
          required: true,
          message: 'Необходимо заполнить фамилию',
        },
        {
          pattern: /^[А-Яа-яЁё]+(-[А-Яа-яЁё]+)?$/,
          message: 'Фамилия должна содержать только символы кириллицы',
        },
      ],
    },
  },
  name: {
    name: 'Имя',
    type: StringControl,
    formParams: {
      key: DtoKeys.NAME,
      rules: [
        {
          required: true,
          message: 'Необходимо заполнить имя',
        },
        {
          pattern: /^[А-Яа-яЁё]+(-[А-Яа-яЁё]+)?$/,
          message: 'Имя должно содержать только символы кириллицы',
        },
      ],
    },
  },
  patron: {
    name: 'Отчество',
    type: StringControl,
    formParams: {
      key: DtoKeys.PATRON,
      rules: [
        {
          required: true,
          message: 'Необходимо заполнить отчество',
        },
        {
          pattern: /^[А-Яа-яЁё]+(-[А-Яа-яЁё]+)?$/,
          message: 'Отчество должно содержать только символы кириллицы',
        },
      ],
    },
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
    formParams: {
      key: DtoKeys.STATUS_ENTRANC_EXAMS,
    },
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
    formParams: {
      key: DtoKeys.SCOPE_OF_ACTIVITY_LEVEL_ONE_ID,
    },
  },
  scopeOfActivityLevelTwoId: {
    name: 'Сфера деятельности уровень 2',
    type: ScopeOfActivitySelect,
    formParams: {
      key: DtoKeys.SCOPE_OF_ACTIVITY_LEVEL_TWO_ID,
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
    formParams: {
      key: DtoKeys.AGREEMENT,
    },
  },
};
