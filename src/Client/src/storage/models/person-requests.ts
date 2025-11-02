import StringControl from '../../components/shared/business/common/string-control';
import EducationProgramSelect from '../../components/shared/business/selects/education-form-select';
import EducationTypeSelect from '../../components/shared/business/selects/education-type-select';
import StatusEntrancExamsSelect from '../../components/shared/business/selects/status-entranc-exams-select';
import ScopeOfActivitySelect from '../../components/shared/business/selects/scope-of-activity-select';
import CheckBox from '../../components/shared/business/common/check-box';
import BirthDate from '../../components/shared/business/birth-date';
import Address from '../../components/shared/business/common/address';
import Email from '../../components/shared/business/common/email';
import PhoneNumber from '../../components/shared/business/phone-number';
import DateTimeView from '../../components/shared/business/date-time-view';

const model = {
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

export default model;
