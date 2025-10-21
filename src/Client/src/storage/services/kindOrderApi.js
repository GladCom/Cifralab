import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './apiUrl.js';

export const kindOrderApi = createApi({
  reducerPath: 'kindOrder',
  baseQuery: fetchBaseQuery({ baseUrl: `${apiUrl}/kindOrder` }),
  endpoints: (builder) => ({
    getKindOrder: builder.query({
      query: () => '',
    }),
    getKindOrderPaged: builder.query({
      query: () => '', //  TODO: Переделать
      providesTags: ['KindOrder'],
    }),
    getKindOrderById: builder.query({
      query: (id) => id,
      invalidatesTags: ['KindOrder'],
    }),
    addKindOrder: builder.mutation({
      query: (item) => ({
        method: 'POST',
        body: item,
      }),
      invalidatesTags: ['KindOrder'],
    }),
    editKindOrder: builder.mutation({
      query: ({ id, item }) => ({
        url: id,
        method: 'PUT',
        body: item,
      }),
      invalidatesTags: ['KindOrder'],
    }),
    removeKindOrder: builder.mutation({
      query: (id) => ({
        url: id,
        method: 'DELETE',
      }),
      invalidatesTags: ['KindOrder'],
    }),
  }),
});

export const {
  useGetKindOrderQuery,
  useGetKindOrderPagedQuery,
  useGetKindOrderByIdQuery,
  useAddKindOrderMutation,
  useEditKindOrderMutation,
  useRemoveKindOrderMutation,
} = kindOrderApi;
