import {
  useGetFinancingTypeQuery,
  useGetFinancingTypePagedQuery,
  useGetFinancingTypeByIdQuery,
  useAddFinancingTypeMutation,
  useEditFinancingTypeMutation,
  useRemoveFinancingTypeMutation,
} from '../services/financing-type-api';

export {
  useGetFinancingTypeQuery as useGetAllAsync,
  useGetFinancingTypePagedQuery as useGetAllPagedAsync,
  useGetFinancingTypeByIdQuery as useGetOneByIdAsync,
  useAddFinancingTypeMutation as useAddOneAsync,
  useEditFinancingTypeMutation as useEditOneAsync,
  useRemoveFinancingTypeMutation as useRemoveOneAsync,
};
