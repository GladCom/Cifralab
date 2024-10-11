import { useDispatch, useSelector } from 'react-redux';
import React, { useState, useEffect } from 'react';
import { 
  useGetStudentsQuery,
  useGetStudentsPagedQuery,
  useGetStudentByIdQuery,
  useAddStudentMutation,
  useEditStudentMutation,
  useRemoveStudentMutation,
} from '../services/studentsApi';
import { showNotification } from '../slices/notificationSlice.js';

const useGetAllAsync = () => {
  const { data, isError, isSuccess, error, isLoading, isFetching, refetch } = useGetStudentsQuery();


  return { data, isError, isSuccess, error, isLoading, isFetching, refetch };
};

const useGetAllPagedAsync = ({ pageNumber, pageSize, filterDataReq: queryString }) => {
  const { data, isError, isSuccess, error, isLoading, isFetching, refetch } = useGetStudentsPagedQuery({ pageNumber, pageSize, filterDataReq: queryString });
  
  const dispatch = useDispatch();

  useEffect(() => {
    if (!isLoading && !isFetching) {
      const type = isSuccess ? 'success' : 'error';
      const message = isSuccess
        ? 'Все студенты успешно получены'
        : 'Ошибка получения студентов';
  
      dispatch(showNotification({ type, error, message }));
    }
  }, [isSuccess, isError]);

  return { data, isError, isSuccess, error, isLoading, isFetching, refetch };
};

const useRemoveOneAsync = () => {
  const [removeItem, removingResult] = useRemoveStudentMutation();
  const [studentId, setId] = useState('');
  const { data, error, isUninitialized, isLoading, isSuccess, isError, reset } = removingResult;

  const dispatch = useDispatch();

  const removeStudent = (id) => {
    setId(id);
    return removeItem(id);
  };

  useEffect(() => {
    console.log(data)
    if (!isLoading && !isUninitialized && (isSuccess || isError)) {
      const type = isSuccess ? 'success' : 'error';
      const message = isSuccess
        ? `Студент (id=${studentId}) успешно удален`
        : `Ошибка: не удалось удалить студента (id=${studentId})`;
  
      dispatch(showNotification({ type, error, message }));
    }

    console.log('сработало');
  }, [isSuccess, isError, isUninitialized, isLoading]);

  return [removeStudent, removingResult];
};

export {
  useGetAllAsync,
  useGetAllPagedAsync,
  useGetStudentByIdQuery as useGetOneByIdAsync,
  useAddStudentMutation as useAddOneAsync,
  useEditStudentMutation as useEditOneAsync,
  useRemoveOneAsync,
}