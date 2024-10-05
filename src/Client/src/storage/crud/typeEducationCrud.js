import { 
  useGetTypeEducationQuery,
  useGetTypeEducationPagedQuery,
  useGetTypeEducationByIdQuery,
  useAddTypeEducationMutation,
  useEditTypeEducationMutation,
  useRemoveTypeEducationMutation,
} from '../services/typeEducationApi';

export {
  useGetTypeEducationQuery as getAllAsync,
  useGetTypeEducationPagedQuery as getAllPagedAsync,
  useGetTypeEducationByIdQuery as getOneByIdAsync,
  useAddTypeEducationMutation as addOneAsync,
  useEditTypeEducationMutation as editOneAsync,
  useRemoveTypeEducationMutation as removeOneAsync,
}
