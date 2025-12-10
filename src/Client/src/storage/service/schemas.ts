import { z } from 'zod';

export const SexHumanEnum = z.enum(['0', '1']);

export const StatusEntrancExamsEnum = z.enum(['0', '1', '2', '3']);

export const GroupSchema = z.object({
  name: z.string().nullable().optional(),
  educationProgramId: z.uuid(),
  startDate: z.date(),
  endDate: z.date(),
});

export const RequestSchema = z.object({
  studentId: z.uuid().nullable().optional(),
  phantomStudentId: z.uuid().nullable().optional(),
  educationProgramId: z.uuid().nullable().optional(),
  documentRiseQualificationId: z.uuid().nullable().optional(),
  dataNumberDogovor: z.string().nullable().optional(),
  statusRequestId: z.uuid().nullable().optional(),
  studentStatusId: z.uuid().nullable().optional(),
  statusEntrancExams: StatusEntrancExamsEnum,
  registrationNumber: z.string().nullable().optional(),
  email: z.email().nullable().optional(),
  phone: z.string().nullable().optional(),
  agreement: z.boolean(),
  dateOfCreate: z.iso.datetime(),
});

export const StudentSchema = z.object({
  family: z.string().nullable().optional(),
  name: z.string().nullable().optional(),
  patron: z.string().nullable().optional(),
  fullName: z.string().nullable().optional(),
  birthDate: z.date(),
  age: z.number().int().nullable().optional(),
  sex: SexHumanEnum,
  address: z.string().nullable().optional(),
  phone: z.string().nullable().optional(),
  email: z.email().nullable().optional(),
  iT_Experience: z.string().nullable().optional(),
  typeEducationId: z.uuid().nullable().optional(),
  scopeOfActivityLevelOneId: z.uuid(),
  scopeOfActivityLevelTwoId: z.uuid().nullable().optional(),
  nationality: z.string().nullable().optional(),
  snils: z.string().nullable().optional(),
  projects: z.string().nullable().optional(),
  disability: z.boolean().nullable().optional(),
  speciality: z.string().nullable().optional(),
  fullNameDocument: z.string().nullable().optional(),
  documentSeries: z.string().nullable().optional(),
  documentNumber: z.string().nullable().optional(),
  dateTakeDiplom: z.iso.datetime().nullable().optional(),
  groups: z.array(GroupSchema).nullable().optional(),
  requests: z.array(RequestSchema).nullable().optional(),
});

export const EducationProgramSchema = z.object({
  description: z.string().describe('Образовательная программа.'),
  name: z.string().nullable().describe('Наименование программы.'),
  cost: z.number().describe('Стоимость обучения.'),
  hoursCount: z.number().int().describe('Количество часов.'),
  educationFormId: z.uuid().describe('Id Формы обучения.'),
  kindDocumentRiseQualificationId: z.uuid().describe('Вид документа повышения квалификации.'),
  kindEducationProgramId: z.uuid().describe('Вид программы'),
  isModularProgram: z.boolean().describe('Модульная программа.'),
  feaProgramId: z.uuid().nullable().describe('Id ВЭД программы.'),
  financingTypeId: z.uuid().describe('Id источника финансирования.'),
  isCollegeProgram: z.boolean().describe('Обязательно наличие ВО'),
  isArchive: z.boolean().describe('Архивная программа.'),
  isNetworkProgram: z.boolean().describe('Сетевая форма.'),
  isDOTProgram: z.boolean().describe('Применение ДОТ.'),
  isFullDOTProgram: z.boolean().describe('Применение ДОТ полностью.'),
  qualificationName: z.string().nullable().describe('Наименование квалификации, профессии, специальности'),
});


export const RequestDTOSchema = z.object({
  studentFullName: z.string().nullable().optional().describe('ФИО.'),
  family: z.string().nullable().optional().describe('Фамилия.'),
  name: z.string().nullable().optional().describe('Имя.'),
  patron: z.string().nullable().optional().describe('Отчество.'),
  birthDate: z.iso.datetime({ offset: true }).nullable().optional().describe('Дата рождения.'),
  address: z.string().nullable().optional().describe('Адрес...'),
  typeEducation: z.string().nullable().optional().describe('Уровень образования (текст)'),
  typeEducationId: z.string().uuid().nullable().optional().describe('Id уровня образования'),
  email: z.email().nullable().optional().describe('Электронный адрес'),
  id: z.uuid().nullable().optional().describe('Id заявки'),
  studentId: z.uuid().nullable().optional().describe('Id Персона'),
  educationProgramId: z.uuid().nullable().optional().describe('Id образовательной программы'),
  educationProgram: z.string().nullable().optional().describe('Образовательная программа (наименование)'),
  statusRequest: z.string().nullable().optional().describe('Статус заявки (текст)'),
  statusRequestId: z.uuid().nullable().optional().describe('Идентификатор статуса студента'),
  iT_Experience: z.string().nullable().optional().describe('Опыт в ИТ'),
  speciality: z.string().nullable().optional().describe('Специальность'),
  projects: z.string().nullable().optional().describe('Проекты'),
  statusEntrancExams: StatusEntrancExamsEnum.describe('Статусы вступительных экзаменов').transform(val => Number(val) as 0 | 1 | 2 | 3),
  phone: z.string().nullable().optional().describe('Телефон'),
  scopeOfActivityLevelOneId: z.uuid().nullable().optional().describe('Ид сферы деятельности 1 уровень'),
  scopeOfActivityLevelTwoId: z.uuid().nullable().optional().describe('Ид сферы деятельности 2 уровень'),
  agreement: z.boolean().describe('Согласие на обработку данных'),
  age: z.number().int().nullable().optional().describe('Возраст'),
  trained: z.boolean().nullable().optional().describe('Обучающийся'),
  dateOfCreate: z.iso.datetime({ offset: true }).describe('Дата создания заявки'),
});