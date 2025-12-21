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
  agreement: {
    name: 'Согласие на обработку перс. даннных',
    type: CheckBox,
    formParams: {
      key: DtoKeys.AGREEMENT,
    },
  },
};
