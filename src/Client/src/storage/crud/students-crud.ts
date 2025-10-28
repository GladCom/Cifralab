import {
  useGetStudentsQuery,
  useGetStudentsPagedQuery,
  useGetStudentByIdQuery,
  useAddStudentMutation,
  useEditStudentMutation,
  useRemoveStudentMutation,
} from '../services/students-api';

const useGetAllAsync = () => {
  const { data, isError, isSuccess, error, isLoading, isFetching, refetch } = useGetStudentsQuery();

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
  const { data, error, isUninitialized, isLoading, isSuccess, isError, reset } = removingResult;

  return [removeItem, removingResult];
};

export {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetStudentByIdQuery as useGetOneByIdAsync,
  useAddStudentMutation as useAddOneAsync,
  useEditStudentMutation as useEditOneAsync,
  useRemoveOneAsync,
};
