import {
  useGetRequestStatusQuery,
  useGetRequestStatusPagedQuery,
  useGetRequestStatusByIdQuery,
  useAddRequestStatusMutation,
  useEditRequestStatusMutation,
  useRemoveRequestStatusMutation,
  useGetRequestStatusSearchQuery,
} from '../service/request-status-api';

export {
  useGetRequestStatusQuery as useGetAllAsync,
  useGetRequestStatusPagedQuery as useGetAllPagedAsync,
  useGetRequestStatusByIdQuery as useGetOneByIdAsync,
  useAddRequestStatusMutation as useAddOneAsync,
  useEditRequestStatusMutation as useEditOneAsync,
  useRemoveRequestStatusMutation as useRemoveOneAsync,
  useGetRequestStatusSearchQuery as useSearchAsync,
};
