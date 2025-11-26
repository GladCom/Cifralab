import {
  useGetFEAProgramQuery,
  useGetFEAProgramPagedQuery,
  useGetFEAProgramByIdQuery,
  useAddFEAProgramMutation,
  useEditFEAProgramMutation,
  useRemoveFEAProgramMutation,
} from '../service/fea-program-api';

export {
  useGetFEAProgramQuery as useGetAllAsync,
  useGetFEAProgramPagedQuery as useGetAllPagedAsync,
  useGetFEAProgramByIdQuery as useGetOneByIdAsync,
  useAddFEAProgramMutation as useAddOneAsync,
  useEditFEAProgramMutation as useEditOneAsync,
  useRemoveFEAProgramMutation as useRemoveOneAsync,
};
