import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './api-url';

export const feaProgramApi = createApi({
  reducerPath: 'fEAProgram',
  baseQuery: fetchBaseQuery({ baseUrl: `${apiUrl}/fEAProgram` }),
  tagTypes: ['FEAProgram'],
  endpoints: (builder) => ({
    getFEAProgram: builder.query({
      query: () => '',
    }),
    getFEAProgramPaged: builder.query({
      query: () => '', //  TODO: Переделать
      providesTags: ['FEAProgram'],
    }),
    getFEAProgramSearch: builder.query({
      //  TODO: в разработке
      query: (_queryText) => '',
    }),
    getFEAProgramById: builder.query({
      query: (id) => id,
    }),
    addFEAProgram: builder.mutation({
      query: (item) => ({
        url: '',
        method: 'POST',
        body: item,
      }),
      invalidatesTags: ['FEAProgram'],
    }),
    editFEAProgram: builder.mutation({
      query: ({ id, item }) => ({
        url: id,
        method: 'PUT',
        body: item,
      }),
      invalidatesTags: ['FEAProgram'],
    }),
    removeFEAProgram: builder.mutation({
      query: (id) => ({
        url: id,
        method: 'DELETE',
      }),
      invalidatesTags: ['FEAProgram'],
    }),
  }),
});

export const {
  useGetFEAProgramQuery,
  useGetFEAProgramPagedQuery,
  useGetFEAProgramByIdQuery,
  useAddFEAProgramMutation,
  useEditFEAProgramMutation,
  useRemoveFEAProgramMutation,
  useGetFEAProgramSearchQuery,
} = feaProgramApi;
