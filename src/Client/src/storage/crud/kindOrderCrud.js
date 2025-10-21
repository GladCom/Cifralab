import {
  useGetKindOrderQuery,
  useGetKindOrderPagedQuery,
  useGetKindOrderByIdQuery,
  useAddKindOrderMutation,
  useEditKindOrderMutation,
  useRemoveKindOrderMutation,
} from '../services/kindOrderApi';

export {
  useGetKindOrderQuery as useGetAllAsync,
  useGetKindOrderPagedQuery as useGetAllPagedAsync,
  useGetKindOrderByIdQuery as useGetOneByIdAsync,
  useAddKindOrderMutation as useAddOneAsync,
  useEditKindOrderMutation as useEditOneAsync,
  useRemoveKindOrderMutation as useRemoveOneAsync,
};
