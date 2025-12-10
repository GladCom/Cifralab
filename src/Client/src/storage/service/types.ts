import z from 'zod';
import {
  EducationProgramSchema,
  GroupSchema,
  RequestDTOSchema,
  RequestSchema,
  SexHumanEnum,
  StatusEntrancExamsEnum,
  StudentSchema,
} from './schemas';

/**
 * По этим ключам формируются поля API-сущностей в payload запросов.
 * Используются в моделях форм.
 */
export enum DtoKeys {
  NAME = 'name',
  FAMILY = 'family',
  PATRON = 'patron',
  ADDRESS = 'address',
  BIRTH_DATE = 'birthDate',
  COST = 'cost',
  SEX = 'sex',
  AGE = 'age',
  PHONE = 'phone',
  SNILS = 'snils',
  EMAIL = 'email',
  NATIONALITY = 'nationality',
  IT_EXPERIENCE = 'iT_Experience',
  SPECIALITY = 'speciality',
  HOURS_COUNT = 'hoursCount',
  EDUCATION_FORM_ID = 'educationFormId',
  EDUCATION_TYPE_ID = 'typeEducationId',
  KIND_DOCUMENT_RISE_QUALIFICATION_ID = 'kindDocumentRiseQualificationId',
  KIND_EDUCATION_PROGRAM_ID = 'kindEducationProgramId',
  IS_MODULAR_PROGRAM = 'isModularProgram',
  FEA_PROGRAM_ID = 'feaProgramId',
  FINANCING_TYPE_ID = 'financingTypeId',
  IS_COLLEGE_PROGRAM = 'isCollegeProgram',
  IS_ARCHIVE = 'isArchive',
  IS_NETWORK_PROGRAM = 'isNetworkProgram',
  IS_DOT_PROGRAM = 'isDOTProgram',
  IS_FULL_DOT_PROGRAM = 'isFullDOTProgram',
  QUALIFICATION_NAME = 'qualificationName',
  SCOPE_OF_ACTIVITY_LEVEL_ONE_ID = 'scopeOfActivityLevelOneId',
  SCOPE_OF_ACTIVITY_LEVEL_TWO_ID = 'scopeOfActivityLevelTwoId',
  FULL_NAME_DOCUMENT = 'fullNameDocument',
  DOCUMENT_SERIES = 'documentSeries',
  DOCUMENT_NUMBER = 'documentNumber',
  DATE_TAKE_DIPLOM = 'dateTakeDiplom',
  DISABILITY = 'disability',
  AGREEMENT = 'agreement',
  STATUS_ENTRANC_EXAMS = 'statusEntrancExams',
}

export type SexHuman = z.infer<typeof SexHumanEnum>;
export type StatusEntrancExams = z.infer<typeof StatusEntrancExamsEnum>;
export type Group = z.infer<typeof GroupSchema>;
export type Request = z.infer<typeof RequestSchema>;
export type RequestDTO = z.infer<typeof RequestDTOSchema>;
export type Student = z.infer<typeof StudentSchema>;
export type EducationProgram = z.infer<typeof EducationProgramSchema>;
