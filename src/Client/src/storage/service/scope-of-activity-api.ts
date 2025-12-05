import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './api-url';

export const scopeOfActivityApi = createApi({
  reducerPath: 'scopeOfActivity',
  baseQuery: fetchBaseQuery({ baseUrl: `${apiUrl}/scopeOfActivity` }),
  tagTypes: ['ScopeOfActivity'],
  endpoints: (builder) => ({
    getscopeOfActivity: builder.query({
      query: () => '',
    }),
    getscopeOfActivityPaged: builder.query({
      query: () => '', //  TODO: Переделать
      providesTags: ['ScopeOfActivity'],
    }),
    getScopeOfActivitySearch: builder.query({
      //  TODO: в разработке
      query: (_queryText) => '',
    }),
    getscopeOfActivityById: builder.query({
      query: (id) => id,
    }),
    addscopeOfActivity: builder.mutation({
      query: (item) => ({
        url: '',
        method: 'POST',
        body: item,
      }),
      invalidatesTags: ['ScopeOfActivity'],
    }),
    editscopeOfActivity: builder.mutation({
      query: ({ id, item }) => ({
        url: id,
        method: 'PUT',
        body: item,
      }),
      invalidatesTags: ['ScopeOfActivity'],
    }),
    removescopeOfActivity: builder.mutation({
      query: (id) => ({
        url: id,
        method: 'DELETE',
      }),
      invalidatesTags: ['ScopeOfActivity'],
    }),
  }),
});

export const {
  useGetscopeOfActivityQuery,
  useGetscopeOfActivityPagedQuery,
  useGetscopeOfActivityByIdQuery,
  useAddscopeOfActivityMutation,
  useEditscopeOfActivityMutation,
  useRemovescopeOfActivityMutation,
  useGetScopeOfActivitySearchQuery,
} = scopeOfActivityApi;
