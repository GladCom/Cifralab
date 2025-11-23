import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './apiUrl.js';

const baseUrl = `${apiUrl}/report`;


// Он будет использоваться по умолчанию для всех запросов, которые возвращают JSON.
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
    // --- Используем наш новый гибридный baseQuery ---
    baseQuery: hybridBaseQuery,
    tagTypes: ['report', 'reports'],
    endpoints: (builder) => ({
        addPFDOReport: builder.mutation({
            query: ({ startDate, endDate }) => ({
                url: `/GetPFDOReport?startDate=${startDate}&endDate=${endDate}`,
                method: 'POST'
            }),
            extraOptions: { responseHandler: 'arraybuffer' },
            invalidatesTags: [{ type: 'reports', id: 'LIST' }]
        }),

        addPFDOReportFromClient: builder.mutation({

            queryFn: async (body, queryApi, extraOptions, baseQuery) => {

                const bodyAsJsonString = JSON.stringify(body, null, 2);
                console.log('Тело запроса (body):', bodyAsJsonString);

                const result = await baseQuery({
                    url: `/GenerateEditedPFDOReport`,
                    method: 'POST',
                    body: body,
                    responseHandler: (response) => response.arrayBuffer()
                });

                if (result.error) {
                    console.error('Ошибка от сервера:', result.error);
                } else {
                    console.log('Ответ от сервера получен (arrayBuffer).');
                }

                return result;
            },
            invalidatesTags: [{ type: 'reports', id: 'LIST' }]
        }),
// ...
        getPFDOPreview: builder.query({
            query: ({ startDate, endDate }) => ({
                url: `/PreviewPFDOReport?startDate=${startDate}&endDate=${endDate}`,
                method: 'GET',
            }),
            providesTags: ['reports'],
        }),
    }),
});

export const {
    useAddPFDOReportMutation,
    useAddPFDOReportFromClientMutation,
    useGetPFDOPreviewQuery,
} = reportApi;