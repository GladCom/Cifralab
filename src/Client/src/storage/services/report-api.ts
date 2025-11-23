import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './apiUrl.js';
import {IGroupFilter} from "@/types";

const baseUrl = `${apiUrl}/report`;

const jsonBaseQuery = fetchBaseQuery({ baseUrl });

const arrayBufferBaseQuery = async (args, api, extraOptions) => {
  const { url, method, body } = args;
  try {
    const response = await fetch(`${baseUrl}${url}`, { method, body });

    if (!response.ok) {
      const errorText = await response.text();
      throw new Error(errorText || `Сетевая ошибка: ${response.status}`);
    }

    const buffer = await response.arrayBuffer();
    return { data: buffer };
  } catch (error) {
    return { error: { status: 'FETCH_ERROR', error: error.message } };
  }
};

const hybridBaseQuery = async (args, api, extraOptions) => {
  if (extraOptions?.responseHandler === 'arraybuffer') {
    // Если флаг установлен, используем обработчик для ArrayBuffer
    return arrayBufferBaseQuery(args, api, extraOptions);
  }

  return jsonBaseQuery(args, api, extraOptions);
};

export const reportApi = createApi({
  reducerPath: 'report',
  keepUnusedDataFor: 0,

  baseQuery: hybridBaseQuery,
  tagTypes: ['report', 'reports'],
  endpoints: (builder) => ({
    GetPFDOReport: builder.mutation({
      query: (body: IGroupFilter) => ({
        url: '/GetPFDOReport',
        method: 'POST',
        body: body,
      }),
      extraOptions: { responseHandler: 'arraybuffer' },
      invalidatesTags: [{ type: 'reports', id: 'LIST' }],
    }),
    GetSummaryReport: builder.mutation({
      query: (body: IGroupFilter) => ({
        url: '/GetSummaryReport',
        method: 'POST',
        body: body,
      }),
      extraOptions: { responseHandler: 'arraybuffer' },
      invalidatesTags: [{ type: 'reports', id: 'LIST' }],
    }),
    GetRosstatReport: builder.mutation({
      query: (body: IGroupFilter) => ({
        url: '/GetRosstatReport',
        method: 'POST',
        body: body,
      }),
      extraOptions: { responseHandler: 'arraybuffer' },
      invalidatesTags: [{ type: 'reports', id: 'LIST' }],
    }),


  }),
});

export const { useGetPFDOReportMutation, useGetSummaryReportMutation, useGetRosstatReportMutation } = reportApi;
