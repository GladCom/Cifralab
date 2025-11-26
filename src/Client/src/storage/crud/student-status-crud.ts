import {
  useGetStudentStatusQuery,
  useGetStudentStatusPagedQuery,
  useGetStudentStatusByIdQuery,
  useAddStudentStatusMutation,
  useEditStudentStatusMutation,
  useRemoveStudentStatusMutation,
  useGetStudentStatusSearchQuery,
} from '../service/student-status-api';

export {
  useGetStudentStatusQuery as useGetAllAsync,
  useGetStudentStatusPagedQuery as useGetAllPagedAsync,
  useGetStudentStatusByIdQuery as useGetOneByIdAsync,
  useAddStudentStatusMutation as useAddOneAsync,
  useEditStudentStatusMutation as useEditOneAsync,
  useRemoveStudentStatusMutation as useRemoveOneAsync,
  useGetStudentStatusSearchQuery as useSearchAsync,
};
