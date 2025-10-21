import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './apiUrl.js';

export const educationProgramApi = createApi({
  reducerPath: 'educationProgram',
  baseQuery: fetchBaseQuery({ baseUrl: `${apiUrl}/educationProgram` }),
  endpoints: (builder) => ({
    getEducationProgram: builder.query({
      query: () => '',
    }),
    getEducationProgramPaged: builder.query({
      query: () => '', //  TODO: Переделать
      providesTags: ['EducationProgram'],
    }),
    getEducationProgramById: builder.query({
      query: (id) => id,
      providesTags: ['EducationProgramById'],
    }),
    addEducationProgram: builder.mutation({
      query: (item) => ({
        method: 'POST',
        body: item,
      }),
      invalidatesTags: ['EducationProgram'],
    }),
    editEducationProgram: builder.mutation({
      query: ({ id, item }) => ({
        url: id,
        method: 'PUT',
        body: item,
      }),
      invalidatesTags: ['EducationProgram', 'EducationProgramById'],
    }),
    removeEducationProgram: builder.mutation({
      query: (id) => ({
        url: id,
        method: 'DELETE',
      }),
      invalidatesTags: ['EducationProgram'],
    }),
  }),
});

export const {
  useGetEducationProgramQuery,
  useGetEducationProgramPagedQuery,
  useGetEducationProgramByIdQuery,
  useAddEducationProgramMutation,
  useEditEducationProgramMutation,
  useRemoveEducationProgramMutation,
} = educationProgramApi;
