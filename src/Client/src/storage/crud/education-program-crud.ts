import { useEffect } from 'react';
import {
  useGetEducationProgramQuery,
  useGetEducationProgramPagedQuery,
  useGetEducationProgramByIdQuery,
  useAddEducationProgramMutation,
  useEditEducationProgramMutation,
  useRemoveEducationProgramMutation,
} from '../service/education-program-api';
import useNotifications from '../../notification/use-notifications';

const useEditOneAsync = () => {
  const [editItem, editingResult] = useEditEducationProgramMutation();
  const { data, error, isUninitialized, isLoading, isSuccess, isError, reset } = editingResult;

  const { showSuccess, showError } = useNotifications();

  useEffect(() => {
    if (isSuccess) {
      showSuccess('Программа успешно обновлена', 'описание уведомления');
    }
    if (isError) {
      showError('Ошибка! Редактирование программы не удалось!', error);
    }
  }, [isSuccess, isError]);

  const editProgram = ({ id, item }) => {
    editItem({ id, item });
  };
  return [editProgram, editingResult];
};

export {
  useGetEducationProgramQuery as useGetAllAsync,
  useGetEducationProgramPagedQuery as useGetAllPagedAsync,
  useGetEducationProgramByIdQuery as useGetOneByIdAsync,
  useAddEducationProgramMutation as useAddOneAsync,
  useEditOneAsync,
  useRemoveEducationProgramMutation as useRemoveOneAsync,
};
