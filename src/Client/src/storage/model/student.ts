import { Address } from '../../components/shared/control/address';
import { Age } from '../../components/shared/control/age';
import { BirthDate } from '../../components/shared/control/birth-date';
import { Email } from '../../components/shared/control/email';
import { Gender } from '../../components/shared/control/gender';
import { PhoneNumber } from '../../components/shared/control/phone-number';
import { EducationTypeSelect } from '../../components/shared/control/selects/education-type-select';
import { ScopeOfActivitySelect } from '../../components/shared/control/selects/scope-of-activity-select';
import { Snils } from '../../components/shared/control/snils';
import { StringControl } from '../../components/shared/control/string-control';
import { YesNoControl } from '../../components/shared/control/yes-no-control';


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
  birthDate: {
    name: 'Дата рождения',
    type: BirthDate,
  },
  sex: {
    name: 'Пол',
    type: Gender,
  },
  age: {
    name: 'Возраст',
    type: Age,
    formParams: {
      rules: [
        {
          required: false,
        },
      ],
    },
    params: {
      show: {
        form: false,
      },
    },
  },
  address: {
    name: 'Место проживания',
    type: Address,
  },
  phone: {
    name: 'Номер телефона',
    type: PhoneNumber,
  },
  email: {
    name: 'E-mail',
    type: Email,
  },
  snils: {
    name: 'Снилс',
    type: Snils,
  },
  nationality: {
    name: 'Гражданство',
    type: StringControl,
  },
  typeEducationId: {
    name: 'Уровень образования',
    type: EducationTypeSelect,
  },
  speciality: {
    name: 'Специальность',
    type: StringControl,
  },
  scopeOfActivityLevelOneId: {
    name: 'Сфера деятельности ур.1',
    type: ScopeOfActivitySelect,
  },
  scopeOfActivityLevelTwoId: {
    name: 'Сфера деятельности ур.2',
    type: ScopeOfActivitySelect,
    formParams: {
      rules: [
        {
          required: false,
        },
      ],
    },
  },
  fullNameDocument: {
    name: 'Фамилия в дипломе о ВО/СПО',
    type: StringControl,
  },
  documentSeries: {
    name: 'Серия документа о ВО/СПО',
    type: StringControl,
  },
  documentNumber: {
    name: 'Номер документа о ВО/СПО',
    type: StringControl,
  },
  disability: {
    name: 'ОВЗ',
    type: YesNoControl,
  },
  // projects: {
  //     name: 'Проекты',
  //     type: String,
  // },
  // iT_Experience: {
  //     name: 'Опыт в IT',
  //     type: String,
  // },
};

export default model;
