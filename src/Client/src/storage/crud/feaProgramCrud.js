import { 
  useGetFEAProgramQuery,
  useGetFEAProgramPagedQuery,
  useGetFEAProgramByIdQuery,
  useAddFEAProgramMutation,
  useEditFEAProgramMutation,
  useRemoveFEAProgramMutation,
} from '../services/feaProgramApi';

export {
  useGetFEAProgramQuery as getAllAsync,
  useGetFEAProgramPagedQuery as getAllPagedAsync,
  useGetFEAProgramByIdQuery as getOneByIdAsync,
  useAddFEAProgramMutation as addOneAsync,
  useEditFEAProgramMutation as editOneAsync,
  useRemoveFEAProgramMutation as removeOneAsync,
}