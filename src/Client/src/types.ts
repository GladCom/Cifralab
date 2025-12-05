import dayjs from 'dayjs';

export type RangeValue = [dayjs.Dayjs, dayjs.Dayjs];

export type MutationHook = (...args: any[]) => any;

// Определяем тип для возвращаемого объекта конфигурации

export interface IGroupFilter {
  studentId?: string | null;

  /**
   * Нижняя граница начала периода.
   */
  startDateMin?: string | null;

  /**
   * Верхняя граница начала периода.
   */
  startDateMax?: string | null;

  /**
   * Нижняя граница конца периода.
   */
  endDateMin?: string | null;

  /**
   * Верхняя граница конца периода.
   */
  endDateMax?: string | null;

  /**
   * Список названий групп.
   */
  names?: string[] | null;
}
