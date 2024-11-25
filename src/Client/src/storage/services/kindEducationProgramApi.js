import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './apiUrl.js';

export const kindEducationProgramApi = createApi({
  reducerPath: 'kindEducationProgram',
  baseQuery: fetchBaseQuery({ baseUrl: `${apiUrl}/kindEducationProgram` }),
  endpoints: (builder) => ({
    getKindEducationProgram: builder.query({
      query: () => '',
    }),
    getKindEducationProgramPaged: builder.query({
      query: () => '',  //  TODO: Переделать
      providesTags: ['KindEducationProgram'],
    }),
    getKindEducationProgramById: builder.query({
      query: (id) => id,
      invalidatesTags: ['KindEducationProgram'],
    }),
    addKindEducationProgram: builder.mutation({
      query: (item) => ({
        method: 'POST',
        body: item,
      }),
      invalidatesTags: ['KindEducationProgram'],
    }),
    editKindEducationProgram: builder.mutation({
      query: ({ id, item }) => ({
        url: id,
        method: 'PUT',
        body: item,
      }),
      invalidatesTags: ['KindEducationProgram'],
    }),
    removeKindEducationProgram: builder.mutation({
      query: (id) => ({
        url: id,
        method: 'DELETE',
      }),
      invalidatesTags: ['KindEducationProgram'],
    }),
  }),
});

export const {
  useGetKindEducationProgramQuery,
  useGetKindEducationProgramPagedQuery,
  useGetKindEducationProgramByIdQuery,
  useAddKindEducationProgramMutation,
  useEditKindEducationProgramMutation,
  useRemoveKindEducationProgramMutation,
} = kindEducationProgramApi;