import { 
  useGetRequestStatusQuery,
  useGetRequestStatusPagedQuery,
  useGetRequestStatusByIdQuery,
  useAddRequestStatusMutation,
  useEditRequestStatusMutation,
  useRemoveRequestStatusMutation,
} from '../services/requestStatusApi';

export {
  useGetRequestStatusQuery as getAllAsync,
  useGetRequestStatusPagedQuery as getAllPagedAsync,
  useGetRequestStatusByIdQuery as getOneByIdAsync,
  useAddRequestStatusMutation as addOneAsync,
  useEditRequestStatusMutation as editOneAsync,
  useRemoveRequestStatusMutation as removeOneAsync,
}