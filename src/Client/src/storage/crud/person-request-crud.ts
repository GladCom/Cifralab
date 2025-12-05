import { useEffect } from 'react';
import useNotifications from '../../notification/use-notifications';
import {
  useGetPersonRequestsQuery,
  useGetPersonRequestsPagedQuery,
  useGetPersonRequestByIdQuery,
  useAddPersonRequestMutation,
  useEditPersonRequestMutation,
  useRemovePersonRequestMutation,
  useGetPersonRequestSearchQuery,
} from '../service/request-api';

const useGetAllAsync = () => {
  const { data, isError, isSuccess, error, isLoading, isFetching, refetch } = useGetPersonRequestsQuery(undefined);

  return { data, isError, isSuccess, error, isLoading, isFetching, refetch };
};

const useGetAllPagedAsync = ({ pageNumber, pageSize, filterDataReq: queryString, sortingField, isSortAsc }) => {
  const { data, isError, isSuccess, error, isLoading, isFetching, refetch } = useGetPersonRequestsPagedQuery({
    pageNumber,
    pageSize,
    filterDataReq: queryString,
    sortingField,
    isSortAsc,
  });

  return { data, isError, isSuccess, error, isLoading, isFetching, refetch };
};

const useRemoveOneAsync = () => {
  const [removeItem, removingResult] = useRemovePersonRequestMutation();
  return [removeItem, removingResult];
};

const useEditOneAsync = () => {
  const [editItem, editingResult] = useEditPersonRequestMutation();
  const { error, isSuccess, isError } = editingResult;

  const { showSuccess, showError } = useNotifications();

  useEffect(() => {
    if (isSuccess) {
      showSuccess('Заявка успешно обновлена', 'описание уведомления');
    }
    if (isError) {
      showError('Ошибка! Редактирование заявки не удалось!', error);
    }
  }, [isSuccess, isError, showSuccess, showError, error]);

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
  useRemoveOneAsync,
  useGetPersonRequestSearchQuery as useSearchAsync,
};
