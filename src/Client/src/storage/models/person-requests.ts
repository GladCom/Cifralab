import String from '../../components/shared/business/common/String';
import EducationProgramSelect from '../../components/shared/business/selects/EducationProgramSelect';
import EducationTypeSelect from '../../components/shared/business/selects/EducationTypeSelect';
import StatusEntrancExamsSelect from '../../components/shared/business/selects/StatusEntrancExamsSelect';
import ScopeOfActivitySelect from '../../components/shared/business/selects/ScopeOfActivitySelect';
import CheckBox from '../../components/shared/business/common/CheckBox';
import BirthDate from '../../components/shared/business/BirthDate';
import Address from '../../components/shared/business/Address';
import Email from '../../components/shared/business/Email';
import PhoneNumber from '../../components/shared/business/PhoneNumber';
import DateTimeView from '../../components/shared/business/DateTimeView';

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
