import {
  useGetStudentsQuery,
  useGetStudentsPagedQuery,
  useGetStudentByIdQuery,
  useAddStudentMutation,
  useEditStudentMutation,
  useRemoveStudentMutation,
  useGetStudentSearchQuery,
} from '../service/student-api';

const useGetAllAsync = () => {
  const { data, isError, isSuccess, error, isLoading, isFetching, refetch } = useGetStudentsQuery({});

  return { data, isError, isSuccess, error, isLoading, isFetching, refetch };
};

const useGetAllPagedAsync = ({ pageNumber, pageSize, filterDataReq: queryString }) => {
  const { data, isError, isSuccess, error, isLoading, isFetching, refetch } = useGetStudentsPagedQuery({
    pageNumber,
    pageSize,
    filterDataReq: queryString,
  });

  return { data, isError, isSuccess, error, isLoading, isFetching, refetch };
};

const useRemoveOneAsync = () => {
  const [removeItem, removingResult] = useRemoveStudentMutation();
  return [removeItem, removingResult];
};

export {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetStudentByIdQuery as useGetOneByIdAsync,
  useAddStudentMutation as useAddOneAsync,
  useEditStudentMutation as useEditOneAsync,
  useRemoveOneAsync,
  useGetStudentSearchQuery as useSearchAsync,
};
