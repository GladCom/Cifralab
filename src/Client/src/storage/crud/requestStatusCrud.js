import { 
  useGetRequestStatusQuery,
  useGetRequestStatusPagedQuery,
  useGetRequestStatusByIdQuery,
  useAddRequestStatusMutation,
  useEditRequestStatusMutation,
  useRemoveRequestStatusMutation,
} from '../services/requestStatusApi';

export {
  useGetRequestStatusQuery as useGetAllAsync,
  useGetRequestStatusPagedQuery as useGetAllPagedAsync,
  useGetRequestStatusByIdQuery as useGetOneByIdAsync,
  useAddRequestStatusMutation as useAddOneAsync,
  useEditRequestStatusMutation as useEditOneAsync,
  useRemoveRequestStatusMutation as useRemoveOneAsync,
}