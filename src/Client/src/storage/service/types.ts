/**
 * По этим ключам формируются поля API-сущностей в payload запросов.
 * Используются в моделях форм.
 */
export enum DtoKeys {
  NAME = 'name',
  FAMILY = 'family',
  PATRON = 'patron',
  ADDRESS = 'address',
  COST = 'cost',
  EMAIL = 'email',
  HOURS_COUNT = 'hoursCount',
  EDUCATION_FORM_ID = 'educationFormId',
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
}
