import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './api-url';

export const educationFormApi = createApi({
  reducerPath: 'educationForm',
  baseQuery: fetchBaseQuery({ baseUrl: `${apiUrl}/educationForm` }),
  tagTypes: ['EducationForm'],
  endpoints: (builder) => ({
    getEducationForm: builder.query({
      query: () => '',
    }),
    getEducationFormPaged: builder.query({
      query: () => '', //  TODO: Переделать
      providesTags: ['EducationForm'],
    }),
    getEducationFormById: builder.query({
      query: (id) => id,
    }),
    addEducationForm: builder.mutation({
      query: (item) => ({
        url: '',
        method: 'POST',
        body: item,
      }),
      invalidatesTags: ['EducationForm'],
    }),
    editEducationForm: builder.mutation({
      query: ({ id, item }) => ({
        url: id,
        method: 'PUT',
        body: item,
      }),
      invalidatesTags: ['EducationForm'],
    }),
    removeEducationForm: builder.mutation({
      query: (id) => ({
        url: id,
        method: 'DELETE',
      }),
      invalidatesTags: ['EducationForm'],
    }),
  }),
});

export const {
  useGetEducationFormQuery,
  useGetEducationFormPagedQuery,
  useGetEducationFormByIdQuery,
  useAddEducationFormMutation,
  useEditEducationFormMutation,
  useRemoveEducationFormMutation,
} = educationFormApi;
