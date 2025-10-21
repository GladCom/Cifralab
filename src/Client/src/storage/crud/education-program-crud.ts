import { useState, useEffect } from 'react';
import useNotifications from '../../notifications/useNotifications';
import {
  useGetEducationProgramQuery,
  useGetEducationProgramPagedQuery,
  useGetEducationProgramByIdQuery,
  useAddEducationProgramMutation,
  useEditEducationProgramMutation,
  useRemoveEducationProgramMutation,
} from '../services/educationProgramApi';

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
