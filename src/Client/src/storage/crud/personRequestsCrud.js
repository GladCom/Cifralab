import { useState, useEffect } from 'react';
import useNotifications from '../../notifications/useNotifications.js';
import { 
    useGetPersonRequestsQuery,
    useGetPersonRequestsPagedQuery,
    useGetPersonRequestByIdQuery,
    useAddPersonRequestMutation,
    useEditPersonRequestMutation,
    useRemovePersonRequestMutation,
} from '../services/requestsApi.js';

const useGetAllAsync = () => {
    const { data, isError, isSuccess, error, isLoading, isFetching, refetch } = useGetPersonRequestsQuery();
  
  
    return { data, isError, isSuccess, error, isLoading, isFetching, refetch };
};  

const useGetAllPagedAsync = ({ pageNumber, pageSize, filterDataReq: queryString }) => {
    const { data, isError, isSuccess, error, isLoading, isFetching, refetch } = useGetPersonRequestsPagedQuery({ pageNumber, pageSize, filterDataReq: queryString });
  
  
    return { data, isError, isSuccess, error, isLoading, isFetching, refetch };
};
  
const useRemoveOneAsync = () => {
    const [removeItem, removingResult] = useRemovePersonRequestMutation();
    const { data, error, isUninitialized, isLoading, isSuccess, isError, reset } = removingResult;
  
  
  
    return [removeItem, removingResult];
};

const useEditOneAsync = () => {
    const [editItem, editingResult] = useEditPersonRequestMutation();
    const { data, error, isUninitialized, isLoading, isSuccess, isError, reset } = editingResult;

    const { showSuccess, showError } = useNotifications();

    useEffect(() => {
        if (isSuccess) {
            showSuccess('Заявка успешно обновлена', 'описание уведомления');
        }
        if (isError) {
          showError('Ошибка! Редактирование заявки не удалось!', error);
        }
    }, [isSuccess, isError]);

    const editRequest = ({ id, item }) => {
      editItem({ id, item });
    };
    return [editRequest, editingResult];
};

export {
    useGetAllAsync as useGetAllAsync,
    useGetAllPagedAsync,
    useGetPersonRequestByIdQuery as useGetOneByIdAsync,
    useAddPersonRequestMutation as useAddOneAsync,
    useEditOneAsync,
    useRemovePersonRequestMutation as useRemoveOneAsync,
}