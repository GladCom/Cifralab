import {
  useGetEducationFormQuery,
  useGetEducationFormPagedQuery,
  useGetEducationFormByIdQuery,
  useAddEducationFormMutation,
  useEditEducationFormMutation,
  useRemoveEducationFormMutation,
} from '../services/educationFormApi';

export {
  useGetEducationFormQuery as useGetAllAsync,
  useGetEducationFormPagedQuery as useGetAllPagedAsync,
  useGetEducationFormByIdQuery as useGetOneByIdAsync,
  useAddEducationFormMutation as useAddOneAsync,
  useEditEducationFormMutation as useEditOneAsync,
  useRemoveEducationFormMutation as useRemoveOneAsync,
};
