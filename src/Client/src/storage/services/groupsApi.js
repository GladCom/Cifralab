import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const groupsApi = createApi({
  reducerPath: 'groups',
  keepUnusedDataFor: 30,
  baseQuery: fetchBaseQuery({ baseUrl: '/group' }),
  endpoints: (builder) => ({
    getGroups: builder.query({
      query: () => '',
    }),
    getGroupsPaged: builder.query({
      query: () => '',  //  TODO: Переделать
      providesTags: ['Groups'],
    }),
    getGroupById: builder.query({
      query: (id) => id,
      invalidatesTags: ['Groups'],
    }),
    addGroup: builder.mutation({
      query: (student) => ({
        method: 'POST',
        body: student,
      }),
      invalidatesTags: ['Groups'],
    }),
    editGroup: builder.mutation({
      query: ({ id, student }) => ({
        url: id,
        method: 'PUT',
        body: student,
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
} = groupsApi;