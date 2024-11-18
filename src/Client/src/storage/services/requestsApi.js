import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './apiUrl.js';

export const requestsApi = createApi({
  reducerPath: 'personrequests',
  baseQuery: fetchBaseQuery({ baseUrl: `${apiUrl}/Request` }), //  TODO: уточнить url
  endpoints: (builder) => ({
    getPersonRequests: builder.query({
      query: () => '',
    }),
    getPersonRequestsPaged: builder.query({
      query: ({ pageNumber, pageSize, filterDataReq }) => `paged?page=${pageNumber}&size=${pageSize}${filterDataReq}`,
      providesTags: ['Request'],
    }),
    getPersonRequestById: builder.query({
      query: (id) => ({
        url: `/GetDTO/${id}`,
        providesTags: ['RequestById'],
      }),
    }),
    addPersonRequest: builder.mutation({
      query: (request) => ({
        url: '/NewRequest',
        method: 'POST',
        body: request,
        invalidatesTags: ['Requests'],
      }),
    }),
    editPersonRequest: builder.mutation({
      query: ({ id, item }) => ({
        url: `/EditRequest/${id}`,
        method: 'PUT',
        body: item,
      }),
      invalidatesTags: ['Requests', 'RequestById'],
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
  useEditPersonRequestMutation,
  useRemovePersonRequestMutation,
} = requestsApi;