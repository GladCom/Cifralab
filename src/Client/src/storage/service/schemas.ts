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