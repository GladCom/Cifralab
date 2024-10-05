import { 
  useGetStudentStatusQuery,
  useGetStudentStatusPagedQuery,
  useGetStudentStatusByIdQuery,
  useAddStudentStatusMutation,
  useEditStudentStatusMutation,
  useRemoveStudentStatusMutation,
} from '../services/studentStatusApi';

export {
  useGetStudentStatusQuery as getAllAsync,
  useGetStudentStatusPagedQuery as getAllPagedAsync,
  useGetStudentStatusByIdQuery as getOneByIdAsync,
  useAddStudentStatusMutation as addOneAsync,
  useEditStudentStatusMutation as editOneAsync,
  useRemoveStudentStatusMutation as removeOneAsync,
}