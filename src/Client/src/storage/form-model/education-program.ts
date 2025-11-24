import { ArchiveCheckbox } from '../../components/shared/control/archive-check-box';
import { Cost } from '../../components/shared/control/cost';
import { HoursCount } from '../../components/shared/control/hours-count';
import { EducationFormSelect } from '../../components/shared/control/selects/education-form-select';
import { FEAProgramSelect } from '../../components/shared/control/selects/fea-program-select';
import { FinancingTypeSelect } from '../../components/shared/control/selects/financing-type-select';
import { KindDocumentRiseQualificationSelect } from '../../components/shared/control/selects/kind-document-rise-qualification-select';
import { KindEducationProgramSelect } from '../../components/shared/control/selects/kind-education-program-select';
import { StringControl } from '../../components/shared/control/string-control';
import { YesNoControl } from '../../components/shared/control/yes-no-control';
import { DtoKeys } from '../service/types';
import { FormModel } from './types';

export const educationProgramFormModel: FormModel = {
  name: {
    name: 'Программа обучения',
    type: StringControl,
    formParams: {
      key: DtoKeys.NAME,
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
      key: DtoKeys.HOURS_COUNT,
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
      key: DtoKeys.EDUCATION_FORM_ID,
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
      key: DtoKeys.KIND_EDUCATION_PROGRAM_ID,
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
      key: DtoKeys.COST,
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
      key: DtoKeys.FINANCING_TYPE_ID,
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
      key: DtoKeys.IS_MODULAR_PROGRAM,
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
      key: DtoKeys.FEA_PROGRAM_ID,
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
      key: DtoKeys.IS_NETWORK_PROGRAM,
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
      key: DtoKeys.IS_DOT_PROGRAM,
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
      key: DtoKeys.IS_FULL_DOT_PROGRAM,
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
      key: DtoKeys.IS_COLLEGE_PROGRAM,
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
      key: DtoKeys.QUALIFICATION_NAME,
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
      key: DtoKeys.KIND_DOCUMENT_RISE_QUALIFICATION_ID,
      rules: [
        {
          required: true,
        },
      ],
    },
  },
  inArchive: {
    name: 'В архиве',
    type: ArchiveCheckbox,
    formParams: {
      key: DtoKeys.IS_ARCHIVE,
      rules: [
        {
          required: true,
        },
      ],
    },
  },
};
