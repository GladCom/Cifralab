import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './api-url';

export const typeEducationApi = createApi({
  reducerPath: 'typeEducation',
  baseQuery: fetchBaseQuery({ baseUrl: `${apiUrl}/typeEducation` }),
  endpoints: (builder) => ({
    getTypeEducation: builder.query({
      query: () => '',
    }),
    getTypeEducationPaged: builder.query({
      query: () => '', //  TODO: Переделать
      providesTags: ['TypeEducation'],
    }),
    getTypeEducationById: builder.query({
      query: (id) => id,
      invalidatesTags: ['TypeEducation'],
    }),
    addTypeEducation: builder.mutation({
      query: (item) => ({
        method: 'POST',
        body: item,
      }),
      invalidatesTags: ['TypeEducation'],
    }),
    editTypeEducation: builder.mutation({
      query: ({ id, item }) => ({
        url: id,
        method: 'PUT',
        body: item,
      }),
      invalidatesTags: ['TypeEducation'],
    }),
    removeTypeEducation: builder.mutation({
      query: (id) => ({
        url: id,
        method: 'DELETE',
      }),
      invalidatesTags: ['TypeEducation'],
    }),
  }),
});

export const {
  useGetTypeEducationQuery,
  useGetTypeEducationPagedQuery,
  useGetTypeEducationByIdQuery,
  useAddTypeEducationMutation,
  useEditTypeEducationMutation,
  useRemoveTypeEducationMutation,
} = typeEducationApi;
