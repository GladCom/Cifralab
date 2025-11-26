import { useEffect } from 'react';
import {
  useGetEducationProgramQuery,
  useGetEducationProgramPagedQuery,
  useGetEducationProgramByIdQuery,
  useAddEducationProgramMutation,
  useEditEducationProgramMutation,
  useRemoveEducationProgramMutation,
  useGetEducationProgramSearchQuery,
} from '../service/education-program-api';
import useNotifications from '../../notification/use-notifications';

const useEditOneAsync = () => {
  const [editItem, editingResult] = useEditEducationProgramMutation();
  const { error, isSuccess, isError } = editingResult;

  const { showSuccess, showError } = useNotifications();

  useEffect(() => {
    if (isSuccess) {
      showSuccess('Программа успешно обновлена', 'описание уведомления');
    }
    if (isError) {
      showError('Ошибка! Редактирование программы не удалось!', error);
    }
  }, [isSuccess, isError, showSuccess, showError, error]);

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
  useGetEducationProgramSearchQuery as useSearchAsync,
};
