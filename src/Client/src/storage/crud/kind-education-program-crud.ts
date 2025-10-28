import {
  useGetKindEducationProgramQuery,
  useGetKindEducationProgramPagedQuery,
  useGetKindEducationProgramByIdQuery,
  useAddKindEducationProgramMutation,
  useEditKindEducationProgramMutation,
  useRemoveKindEducationProgramMutation,
} from '../services/kind-education-program-api';

export {
  useGetKindEducationProgramQuery as useGetAllAsync,
  useGetKindEducationProgramPagedQuery as useGetAllPagedAsync,
  useGetKindEducationProgramByIdQuery as useGetOneByIdAsync,
  useAddKindEducationProgramMutation as useAddOneAsync,
  useEditKindEducationProgramMutation as useEditOneAsync,
  useRemoveKindEducationProgramMutation as useRemoveOneAsync,
};
