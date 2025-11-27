import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './api-url';

export const kindOrderApi = createApi({
  reducerPath: 'kindOrder',
  baseQuery: fetchBaseQuery({ baseUrl: `${apiUrl}/kindOrder` }),
  tagTypes: ['KindOrder'],
  endpoints: (builder) => ({
    getKindOrder: builder.query({
      query: () => '',
    }),
    getKindOrderPaged: builder.query({
      query: () => '', //  TODO: Переделать
      providesTags: ['KindOrder'],
    }),
    getKindOrderSearch: builder.query({
      //  TODO: в разработке
      query: (queryText) => '',
    }),
    getKindOrderById: builder.query({
      query: (id) => id,
    }),
    addKindOrder: builder.mutation({
      query: (item) => ({
        url: '',
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
  useGetKindOrderSearchQuery,
} = kindOrderApi;
