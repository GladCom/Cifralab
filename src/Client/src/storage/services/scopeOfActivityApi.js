import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const scopeOfActivityApi = createApi({
  reducerPath: 'scopeOfActivity',
  baseQuery: fetchBaseQuery({ baseUrl: '/scopeOfActivity' }),
  endpoints: (builder) => ({
    getscopeOfActivity: builder.query({
      query: () => '',
    }),
    getscopeOfActivityPaged: builder.query({
      query: () => '',  //  TODO: Переделать
      providesTags: ['ScopeOfActivity'],
    }),
    getscopeOfActivityById: builder.query({
      query: (id) => id,
      invalidatesTags: ['ScopeOfActivity'],
    }),
    addscopeOfActivity: builder.mutation({
      query: (item) => ({
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
} = scopeOfActivityApi;