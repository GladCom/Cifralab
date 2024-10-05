import { 
  useGetKindOrderQuery,
  useGetKindOrderPagedQuery,
  useGetKindOrderByIdQuery,
  useAddKindOrderMutation,
  useEditKindOrderMutation,
  useRemoveKindOrderMutation,
} from '../services/kindOrderApi';

export {
  useGetKindOrderQuery as getAllAsync,
  useGetKindOrderPagedQuery as getAllPagedAsync,
  useGetKindOrderByIdQuery as getOneByIdAsync,
  useAddKindOrderMutation as addOneAsync,
  useEditKindOrderMutation as editOneAsync,
  useRemoveKindOrderMutation as removeOneAsync,
}