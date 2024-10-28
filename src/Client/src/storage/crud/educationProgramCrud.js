import { 
  useGetEducationProgramQuery,
  useGetEducationProgramPagedQuery,
  useGetEducationProgramByIdQuery,
  useAddEducationProgramMutation,
  useEditEducationProgramMutation,
  useRemoveEducationProgramMutation,
} from '../services/educationProgramApi';

export {
  useGetEducationProgramQuery as useGetAllAsync,
  useGetEducationProgramPagedQuery as useGetAllPagedAsync,
  useGetEducationProgramByIdQuery as useGetOneByIdAsync,
  useAddEducationProgramMutation as useAddOneAsync,
  useEditEducationProgramMutation as useEditOneAsync,
  useRemoveEducationProgramMutation as useRemoveOneAsync,
}