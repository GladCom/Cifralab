import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const requestsAPI = createApi({
  reducerPath: 'personrequests',
  keepUnusedDataFor: 5, // время жизни кэша для всех эндпоинтов
  baseQuery: fetchBaseQuery({ baseUrl: '/Request' }), //  TODO: уточнить url
  endpoints: (builder) => ({
    getPersonRequests: builder.query({
      query: () => '',
    }),
    getPersonRequestsPaged: builder.query({
      query: ({ pageNumber, pageSize, filterDataReq }) => `paged?page=${pageNumber}&size=${pageSize}${filterDataReq}`,
      providesTags: ['Request'],
    }),
    getPersonRequestById: builder.query({
      query: (id) => id,
    }),
    addPersonRequest: builder.mutation({
      query: (request) => ({
        method: 'POST',
        body: request,
      }),
    }),
    removePersonRequest: builder.mutation({
      query: (id) => ({
        url: id,
        method: 'DELETE',
      }),
      invalidatesTags: ['Requests'],
    }),
  }),
});

export const {
  useGetPersonRequestsQuery,
  useGetPersonRequestsPagedQuery,
  useGetPersonRequestByIdQuery,
  useAddPersonRequestMutation,
  useRemovePersonRequestMutation,
} = requestsApi;