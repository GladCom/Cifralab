import { 
    useGetEducationFormQuery,
    useGetEducationFormPagedQuery,
    useGetEducationFormByIdQuery,
    useAddEducationFormMutation,
    useEditEducationFormMutation,
    useRemoveEducationFormMutation,
} from '../services/educationFormApi';

export {
  useGetEducationFormQuery as getAllAsync,
  useGetEducationFormPagedQuery as getAllPagedAsync,
  useGetEducationFormByIdQuery as getOneByIdAsync,
  useAddEducationFormMutation as addOneAsync,
  useEditEducationFormMutation as editOneAsync,
  useRemoveEducationFormMutation as removeOneAsync,
}