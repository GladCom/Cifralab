import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './api-url';

export const financingTypeApi = createApi({
  reducerPath: 'financingType',
  baseQuery: fetchBaseQuery({ baseUrl: `${apiUrl}/financingType` }),
  tagTypes: ['FinancingType'],
  endpoints: (builder) => ({
    getFinancingType: builder.query({
      query: () => '',
    }),
    getFinancingTypePaged: builder.query({
      query: () => '', //  TODO: Переделать
      providesTags: ['FinancingType'],
    }),
    getFinancingTypeById: builder.query({
      query: (id) => id,
    }),
    addFinancingType: builder.mutation({
      query: (item) => ({
        url: '',
        method: 'POST',
        body: item,
      }),
      invalidatesTags: ['FinancingType'],
    }),
    editFinancingType: builder.mutation({
      query: ({ id, item }) => ({
        url: id,
        method: 'PUT',
        body: item,
      }),
      invalidatesTags: ['FinancingType'],
    }),
    removeFinancingType: builder.mutation({
      query: (id) => ({
        url: id,
        method: 'DELETE',
      }),
      invalidatesTags: ['FinancingType'],
    }),
  }),
});

export const {
  useGetFinancingTypeQuery,
  useGetFinancingTypePagedQuery,
  useGetFinancingTypeByIdQuery,
  useAddFinancingTypeMutation,
  useEditFinancingTypeMutation,
  useRemoveFinancingTypeMutation,
} = financingTypeApi;
