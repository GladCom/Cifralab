import { Cost } from '../../components/shared/control/cost';
import { HoursCount } from '../../components/shared/control/hours-count';
import { EducationFormSelect } from '../../components/shared/control/selects/education-form-select';
import { FEAProgramSelect } from '../../components/shared/control/selects/fea-program-select';
import { FinancingTypeSelect } from '../../components/shared/control/selects/financing-type-select';
import { KindDocumentRiseQualificationSelect } from '../../components/shared/control/selects/kind-document-rise-qualification-select';
import { KindEducationProgramSelect } from '../../components/shared/control/selects/kind-education-program-select';
import { StringControl } from '../../components/shared/control/string-control';
import { YesNoControl } from '../../components/shared/control/yes-no-control';


const model = {
  name: { name: 'Программа обучения', type: StringControl, show: true, required: true },
  cost: { name: 'Стоимость', type: Cost, show: true, required: true },
  hoursCount: { name: 'Кол-во часов', type: HoursCount, show: true, required: true },
  educationFormId: { name: 'Форма образования', type: EducationFormSelect, show: true, required: true },
  kindEducationProgramId: { name: 'Вид программы', type: KindEducationProgramSelect, show: true, required: true },
  kindDocumentRiseQualificationId: {
    name: 'Вид документа',
    type: KindDocumentRiseQualificationSelect,
    show: true,
    required: true,
  },
  isModularProgram: { name: 'Модульная программа', type: YesNoControl, show: true, required: true },
  feaProgramId: { name: 'ВЭД программы', type: FEAProgramSelect, show: true, required: true },
  financingTypeId: { name: 'Источник финансирования', type: FinancingTypeSelect, show: true, required: true },
  isCollegeProgram: { name: 'Обязательно наличие ВО', type: YesNoControl, show: true, required: true },
  isNetworkProgram: { name: 'Сетевая форма', type: YesNoControl, show: true, required: true },
  isDOTProgram: { name: 'Применение ДОТ', type: YesNoControl, show: true, required: true },
  isFullDOTProgram: { name: 'Применение ДОТ полностью', type: YesNoControl, show: true, required: true },
  qualificationName: { name: 'Наименование квалификации', type: StringControl, show: true, required: true },
  isArchive: { name: 'В архиве', type: YesNoControl, show: true, required: true },
};

export default model;
