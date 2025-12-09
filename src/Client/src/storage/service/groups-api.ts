import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './api-url';

export const groupsApi = createApi({
  reducerPath: 'groups',
  keepUnusedDataFor: 30,
  baseQuery: fetchBaseQuery({ baseUrl: `${apiUrl}/group` }),
  tagTypes: ['Groups'],
  endpoints: (builder) => ({
    getGroups: builder.query({
      query: () => '',
    }),
    getGroupsPaged: builder.query({
      query: () => '', //  TODO: Переделать
      providesTags: ['Groups'],
    }),
    getGroupsSearch: builder.query({
      //  TODO: в разработке
      query: (_queryText) => '',
    }),
    getGroupById: builder.query({
      query: () => ({
        url: '',
        method: 'GET',
      }),
    }),
    addGroup: builder.mutation({
      query: (item) => ({
        url: '',
        method: 'POST',
        body: item,
      }),
      invalidatesTags: ['Groups'],
    }),
    editGroup: builder.mutation({
      query: ({ id, item }) => ({
        url: id,
        method: 'PUT',
        body: item,
      }),
      invalidatesTags: ['Groups'],
    }),
    removeGroup: builder.mutation({
      query: (id) => ({
        url: id,
        method: 'DELETE',
      }),
      invalidatesTags: ['Groups'],
    }),
  }),
});

export const {
  useGetGroupsQuery,
  useGetGroupsPagedQuery,
  useGetGroupByIdQuery,
  useAddGroupMutation,
  useEditGroupMutation,
  useRemoveGroupMutation,
  useGetGroupsSearchQuery,
} = groupsApi;
