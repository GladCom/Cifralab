import {
  useGetEducationFormQuery,
  useGetEducationFormPagedQuery,
  useGetEducationFormByIdQuery,
  useAddEducationFormMutation,
  useEditEducationFormMutation,
  useRemoveEducationFormMutation,
  useGetEducationFormSearchQuery,
} from '../service/education-form-api';

export {
  useGetEducationFormQuery as useGetAllAsync,
  useGetEducationFormPagedQuery as useGetAllPagedAsync,
  useGetEducationFormByIdQuery as useGetOneByIdAsync,
  useAddEducationFormMutation as useAddOneAsync,
  useEditEducationFormMutation as useEditOneAsync,
  useRemoveEducationFormMutation as useRemoveOneAsync,
  useGetEducationFormSearchQuery as useSearchAsync,
};
