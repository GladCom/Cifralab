import { 
  useGetStudentStatusQuery,
  useGetStudentStatusPagedQuery,
  useGetStudentStatusByIdQuery,
  useAddStudentStatusMutation,
  useEditStudentStatusMutation,
  useRemoveStudentStatusMutation,
} from '../services/studentStatusApi';

export {
  useGetStudentStatusQuery as useGetAllAsync,
  useGetStudentStatusPagedQuery as useGetAllPagedAsync,
  useGetStudentStatusByIdQuery as useGetOneByIdAsync,
  useAddStudentStatusMutation as useAddOneAsync,
  useEditStudentStatusMutation as useEditOneAsync,
  useRemoveStudentStatusMutation as useRemoveOneAsync,
}