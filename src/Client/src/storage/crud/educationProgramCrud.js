import { 
  useGetEducationProgramQuery,
  useGetEducationProgramPagedQuery,
  useGetEducationProgramByIdQuery,
  useAddEducationProgramMutation,
  useEditEducationProgramMutation,
  useRemoveEducationProgramMutation,
} from '../services/educationProgramApi';

export {
  useGetEducationProgramQuery as getAllAsync,
  useGetEducationProgramPagedQuery as getAllPagedAsync,
  useGetEducationProgramByIdQuery as getOneByIdAsync,
  useAddEducationProgramMutation as addOneAsync,
  useEditEducationProgramMutation as editOneAsync,
  useRemoveEducationProgramMutation as removeOneAsync,
}