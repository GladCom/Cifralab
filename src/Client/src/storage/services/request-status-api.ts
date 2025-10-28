import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './api-url';

export const requestStatusApi = createApi({
  reducerPath: 'requestStatus',
  baseQuery: fetchBaseQuery({ baseUrl: `${apiUrl}/statusRequest` }),
  endpoints: (builder) => ({
    getRequestStatus: builder.query({
      query: () => '',
    }),
    getRequestStatusPaged: builder.query({
      query: () => '', //  TODO: Переделать
      providesTags: ['RequestStatus'],
    }),
    getRequestStatusById: builder.query({
      query: (id) => id,
      invalidatesTags: ['RequestStatus'],
    }),
    addRequestStatus: builder.mutation({
      query: (item) => ({
        method: 'POST',
        body: item,
      }),
      invalidatesTags: ['RequestStatus'],
    }),
    editRequestStatus: builder.mutation({
      query: ({ id, item }) => ({
        url: id,
        method: 'PUT',
        body: item,
      }),
      invalidatesTags: ['RequestStatus'],
    }),
    removeRequestStatus: builder.mutation({
      query: (id) => ({
        url: id,
        method: 'DELETE',
      }),
      invalidatesTags: ['RequestStatus'],
    }),
  }),
});

export const {
  useGetRequestStatusQuery,
  useGetRequestStatusPagedQuery,
  useGetRequestStatusByIdQuery,
  useAddRequestStatusMutation,
  useEditRequestStatusMutation,
  useRemoveRequestStatusMutation,
} = requestStatusApi;
