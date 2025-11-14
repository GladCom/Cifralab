import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './api-url';

export const kindDocumentRiseQualificationApi = createApi({
  reducerPath: 'kindDocumentRiseQualification',
  baseQuery: fetchBaseQuery({ baseUrl: `${apiUrl}/kindDocumentRiseQualification` }),
  endpoints: (builder) => ({
    getKindDocumentRiseQualification: builder.query({
      query: () => '',
    }),
    getKindDocumentRiseQualificationPaged: builder.query({
      query: () => '', //  TODO: Переделать
      providesTags: ['KindDocumentRiseQualification'],
    }),
    getKindDocumentRiseQualificationById: builder.query({
      query: (id) => id,
      invalidatesTags: ['KindDocumentRiseQualification'],
    }),
    addKindDocumentRiseQualification: builder.mutation({
      query: (item) => ({
        url: '',
        method: 'POST',
        body: item,
      }),
      invalidatesTags: ['KindDocumentRiseQualification'],
    }),
    editKindDocumentRiseQualification: builder.mutation({
      query: ({ id, item }) => ({
        url: id,
        method: 'PUT',
        body: item,
      }),
      invalidatesTags: ['KindDocumentRiseQualification'],
    }),
    removeKindDocumentRiseQualification: builder.mutation({
      query: (id) => ({
        url: id,
        method: 'DELETE',
      }),
      invalidatesTags: ['KindDocumentRiseQualification'],
    }),
  }),
});

export const {
  useGetKindDocumentRiseQualificationQuery,
  useGetKindDocumentRiseQualificationPagedQuery,
  useGetKindDocumentRiseQualificationByIdQuery,
  useAddKindDocumentRiseQualificationMutation,
  useEditKindDocumentRiseQualificationMutation,
  useRemoveKindDocumentRiseQualificationMutation,
} = kindDocumentRiseQualificationApi;
