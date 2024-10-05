import { 
  useGetStudentsQuery,
  useGetStudentsPagedQuery,
  useGetStudentByIdQuery,
  useAddStudentMutation,
  useEditStudentMutation,
  useRemoveStudentMutation,
} from '../services/studentsApi';

export {
  useGetStudentsQuery as getAllAsync,
  useGetStudentsPagedQuery as getAllPagedAsync,
  useGetStudentByIdQuery as getOneByIdAsync,
  useAddStudentMutation as addOneAsync,
  useEditStudentMutation as editOneAsync,
  useRemoveStudentMutation as removeOneAsync,
}