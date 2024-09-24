import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const studentsApi = createApi({
  reducerPath: 'students',
  baseQuery: fetchBaseQuery({ baseUrl: '/student' }), //  TODO: уточнить url
  endpoints: (builder) => ({
    getStudents: builder.query({
      query: () => '',
    }),
    getStudentsPaged: builder.query({
      query: ({ pageNumber, pageSize, filterDataReq }) => `paged?page=${pageNumber}&size=${pageSize}${filterDataReq}`,
    }),
    getStudentById: builder.query({
      query: (id) => id,
    }),
    addStudent: builder.mutation({
      query: (student) => ({
        method: 'POST',
        body: student,
      }),
    }),
    removeStudent: builder.mutation({
      query: (id) => ({
        url: id,
        method: 'DELETE',
      }),
    }),
  }),
});

export const {
  useGetStudentsQuery,
  useGetStudentsPagedQuery,
  useGetStudentByIdQuery,
  useAddStudentMutation,
  useRemoveStudentMutation,
} = studentsApi;