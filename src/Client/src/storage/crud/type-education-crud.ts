import {
  useGetTypeEducationQuery,
  useGetTypeEducationPagedQuery,
  useGetTypeEducationByIdQuery,
  useAddTypeEducationMutation,
  useEditTypeEducationMutation,
  useRemoveTypeEducationMutation,
} from '../services/type-education-api';

export {
  useGetTypeEducationQuery as useGetAllAsync,
  useGetTypeEducationPagedQuery as useGetAllPagedAsync,
  useGetTypeEducationByIdQuery as useGetOneByIdAsync,
  useAddTypeEducationMutation as useAddOneAsync,
  useEditTypeEducationMutation as useEditOneAsync,
  useRemoveTypeEducationMutation as useRemoveOneAsync,
};
