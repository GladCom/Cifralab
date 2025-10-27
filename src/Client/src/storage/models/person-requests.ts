import String from '../../components/shared/business/common/string';
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
    type: String,
  },
  name: {
    name: 'Имя',
    type: String,
  },
  patron: {
    name: 'Отчество',
    type: String,
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
    type: String,
  },
  speciality: {
    name: 'Специальность',
    type: String,
  },
  projects: {
    name: 'Проекты',
    type: String,
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
