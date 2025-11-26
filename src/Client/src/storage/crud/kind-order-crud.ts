import {
  useGetKindOrderQuery,
  useGetKindOrderPagedQuery,
  useGetKindOrderByIdQuery,
  useAddKindOrderMutation,
  useEditKindOrderMutation,
  useRemoveKindOrderMutation,
} from '../service/kind-order-api';

export {
  useGetKindOrderQuery as useGetAllAsync,
  useGetKindOrderPagedQuery as useGetAllPagedAsync,
  useGetKindOrderByIdQuery as useGetOneByIdAsync,
  useAddKindOrderMutation as useAddOneAsync,
  useEditKindOrderMutation as useEditOneAsync,
  useRemoveKindOrderMutation as useRemoveOneAsync,
};
