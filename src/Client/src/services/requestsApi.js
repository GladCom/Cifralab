import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const requestsApi = createApi({
  reducerPath: 'requests',
  keepUnusedDataFor: 5, // время жизни кэша для всех эндпоинтов
  baseQuery: fetchBaseQuery({ baseUrl: '/Request' }), //  TODO: уточнить url
  endpoints: (builder) => ({
    getRequests: builder.query({
      query: () => '',
    }),
    getRequestsPaged: builder.query({
      query: ({ pageNumber, pageSize, filterDataReq }) => `paged?page=${pageNumber}&size=${pageSize}${filterDataReq}`,
      providesTags: ['Requests'],
    }),
    getRequestById: builder.query({
      query: (id) => id,
    }),
    addRequest: builder.mutation({
      query: (request) => ({
        method: 'POST',
        body: request,
      }),
    }),
    removeRequest: builder.mutation({
      query: (id) => ({
        url: id,
        method: 'DELETE',
      }),
      invalidatesTags: ['Requests'],
    }),
  }),
});

export const {
  useGetRequestsQuery,
  useGetRequestsPagedQuery,
  useGetRequestByIdQuery,
  useAddRequestMutation,
  useRemoveRequestMutation,
} = requestsApi;