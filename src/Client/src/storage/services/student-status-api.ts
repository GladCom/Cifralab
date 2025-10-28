import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './api-url';

export const studentStatusApi = createApi({
  reducerPath: 'studentStatus',
  baseQuery: fetchBaseQuery({ baseUrl: `${apiUrl}/studentStatus` }),
  endpoints: (builder) => ({
    getStudentStatus: builder.query({
      query: () => '',
    }),
    getStudentStatusPaged: builder.query({
      query: () => '', //  TODO: Переделать
      providesTags: ['StudentStatus'],
    }),
    getStudentStatusById: builder.query({
      query: (id) => id,
      invalidatesTags: ['StudentStatus'],
    }),
    addStudentStatus: builder.mutation({
      query: (item) => ({
        method: 'POST',
        body: item,
      }),
      invalidatesTags: ['StudentStatus'],
    }),
    editStudentStatus: builder.mutation({
      query: ({ id, item }) => ({
        url: id,
        method: 'PUT',
        body: item,
      }),
      invalidatesTags: ['StudentStatus'],
    }),
    removeStudentStatus: builder.mutation({
      query: (id) => ({
        url: id,
        method: 'DELETE',
      }),
      invalidatesTags: ['StudentStatus'],
    }),
  }),
});

export const {
  useGetStudentStatusQuery,
  useGetStudentStatusPagedQuery,
  useGetStudentStatusByIdQuery,
  useAddStudentStatusMutation,
  useEditStudentStatusMutation,
  useRemoveStudentStatusMutation,
} = studentStatusApi;
