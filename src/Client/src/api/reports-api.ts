import { z } from 'zod';
import { message } from 'antd';
import { apiFileRequest } from './api-client';

export const ReportRequestSchema = z.object({
  studentId: z.string().nullable(),
  startDateMin: z.string().nullable(),
  startDateMax: z.string().nullable(),
  endDateMin: z.string().nullable(),
  endDateMax: z.string().nullable(),
  groupNames: z.array(z.string()).nullable(),
});

export type ReportRequest = z.infer<typeof ReportRequestSchema>;

const downloadReport = async (endpoint: string, params: ReportRequest, downloadFileName: string): Promise<void> => {
  try {
    const options: RequestInit = {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, */*',
      },
      body: JSON.stringify(params),
    };

    const blob = await apiFileRequest<ReportRequest>(endpoint, params, options);

    const url = window.URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.setAttribute('download', downloadFileName);
    document.body.appendChild(link);
    link.click();

    link.parentNode?.removeChild(link);
    window.URL.revokeObjectURL(url);
  } catch (error) {
    message.error('Не удалось скачать файл с эндпоинта', error);
  }
};

export const fetchPfdoReport = async (params: ReportRequest): Promise<void> => {
  await downloadReport('report/GetPFDOReport', params, 'Отчет_ФРДО.xlsx');
};

export const fetchRostatReport = async (params: ReportRequest): Promise<void> => {
  await downloadReport('report/GetRostatReport', params, 'Отчет_Росстат.xlsx');
};

export const fetchSummaryReport = async (params: ReportRequest): Promise<void> => {
  await downloadReport('report/GetSummaryReport', params, 'Отчет_По_Обучающимся.xlsx');
};
