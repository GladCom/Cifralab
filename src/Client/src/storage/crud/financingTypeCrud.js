import { 
  useGetFinancingTypeQuery,
  useGetFinancingTypePagedQuery,
  useGetFinancingTypeByIdQuery,
  useAddFinancingTypeMutation,
  useEditFinancingTypeMutation,
  useRemoveFinancingTypeMutation,
} from '../services/financingTypeApi';

export {
  useGetFinancingTypeQuery as getAllAsync,
  useGetFinancingTypePagedQuery as getAllPagedAsync,
  useGetFinancingTypeByIdQuery as getOneByIdAsync,
  useAddFinancingTypeMutation as addOneAsync,
  useEditFinancingTypeMutation as editOneAsync,
  useRemoveFinancingTypeMutation as removeOneAsync,
}