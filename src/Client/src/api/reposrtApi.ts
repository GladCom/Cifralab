import { z } from 'zod';
import { apiFileRequest } from '@/api/apiClient';

export const OrderResponseSchema = z.object({
  id: z.string().uuid(),
  number: z.string().nullable(),
  date: z.coerce.date(),
  kindOrderId: z.string().uuid(),
  requestId: z.string().uuid(),
});

export const ReportRequestSchema = z.object({
  id: z.string().uuid(),
  studentId: z.string().uuid(),
  startDateMin: z.string().nullable(),
  startDateMax: z.string().nullable(),
  endDateMin: z.string().nullable(),
  endDateMax: z.string().nullable(),
});

export type IOrderRequest = z.infer<typeof ReportRequestSchema>;
export type IOrderReponse = z.infer<typeof OrderResponseSchema>;

const downloadReport = async (endpoint: string, params: IOrderRequest, downloadFileName: string): Promise<void> => {
  try {
    const options: RequestInit = {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, */*',
      },
      body: JSON.stringify(params),
    };

    const blob = await apiFileRequest(endpoint, options);

    const url = window.URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.setAttribute('download', downloadFileName);
    document.body.appendChild(link);
    link.click();

    link.parentNode?.removeChild(link);
    window.URL.revokeObjectURL(url);
  } catch (error) {
    console.error(`Не удалось скачать файл с эндпоинта ${endpoint}:`, error);
  }
};

export const fetchPFDOReport = async (params: IOrderRequest): Promise<void> => {
  await downloadReport('report/GetPFDOReport', params, 'Отчет_ФРДО.xlsx');
};

export const fetchRosstatReport = async (params: IOrderRequest): Promise<void> => {
  await downloadReport('report/GetRosstatReport', params, 'Отчет_Росстат.xlsx');
};

export const fetchSummaryReport = async (params: IOrderRequest): Promise<void> => {
  await downloadReport('report/GetSummaryReport', params, 'Отчет_Росстат.xlsx');
};
