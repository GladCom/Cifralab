import { Cost } from '../../components/shared/control/cost';
import { HoursCount } from '../../components/shared/control/hours-count';
import { EducationFormSelect } from '../../components/shared/control/selects/education-form-select';
import { FEAProgramSelect } from '../../components/shared/control/selects/fea-program-select';
import { FinancingTypeSelect } from '../../components/shared/control/selects/financing-type-select';
import { KindDocumentRiseQualificationSelect } from '../../components/shared/control/selects/kind-document-rise-qualification-select';
import { KindEducationProgramSelect } from '../../components/shared/control/selects/kind-education-program-select';
import { StringControl } from '../../components/shared/control/string-control';
import { YesNoControl } from '../../components/shared/control/yes-no-control';
import { FormModel } from './types';

export const educationProgramFormModel: FormModel = {
  name: {
    name: 'Программа обучения',
    type: StringControl,
    formParams: {
      key: 'nameKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
  cost: {
    name: 'Стоимость',
    type: Cost,
    formParams: {
      key: 'costKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
  hoursCount: {
    name: 'Кол-во часов',
    type: HoursCount,
    formParams: {
      key: 'hoursCountKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
  educationFormId: {
    name: 'Форма образования',
    type: EducationFormSelect,
    formParams: {
      key: 'educationFormIdKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
  kindEducationProgramId: {
    name: 'Вид программы',
    type: KindEducationProgramSelect,
    formParams: {
      key: 'kindEducationProgramIdKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
  kindDocumentRiseQualificationId: {
    name: 'Вид документа',
    type: KindDocumentRiseQualificationSelect,
    formParams: {
      key: 'kindDocumentRiseQualificationIdKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
  isModularProgram: {
    name: 'Модульная программа',
    type: YesNoControl,
    formParams: {
      key: 'isModularProgramKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
  feaProgramId: {
    name: 'ВЭД программы',
    type: FEAProgramSelect,
    formParams: {
      key: 'feaProgramIdKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
  financingTypeId: {
    name: 'Источник финансирования',
    type: FinancingTypeSelect,
    formParams: {
      key: 'financingTypeIdKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
  isCollegeProgram: {
    name: 'Обязательно наличие ВО',
    type: YesNoControl,
    formParams: {
      key: 'isCollegeProgramKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
  isNetworkProgram: {
    name: 'Сетевая форма',
    type: YesNoControl,
    formParams: {
      key: 'isNetworkProgramKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
  isDOTProgram: {
    name: 'Применение ДОТ',
    type: YesNoControl,
    formParams: {
      key: 'isDOTProgramKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
  isFullDOTProgram: {
    name: 'Применение ДОТ полностью',
    type: YesNoControl,
    formParams: {
      key: 'isFullDOTProgramKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
  qualificationName: {
    name: 'Наименование квалификации',
    type: StringControl,
    formParams: {
      key: 'qualificationNameKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
  inArchive: {
    name: 'В архиве',
    type: YesNoControl,
    formParams: {
      key: 'isArchiveKey',
      rules: [
        {
          required: true,
        },
      ],
    },
  },
};
