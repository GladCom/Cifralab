import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const studentsApi = createApi({
  reducerPath: 'students',
  keepUnusedDataFor: 5, // время жизни кэша для всех эндпоинтов
  baseQuery: fetchBaseQuery({ baseUrl: '/student' }), //  TODO: уточнить url
  endpoints: (builder) => ({
    getStudents: builder.query({
      query: () => '',
    }),
    getStudentsPaged: builder.query({
      query: ({ pageNumber, pageSize, filterDataReq }) => `paged?page=${pageNumber}&size=${pageSize}${filterDataReq}`,
      providesTags: ['Students'],
    }),
    getStudentById: builder.query({
      query: (id) => id,
      invalidatesTags: ['Students'],
    }),
    addStudent: builder.mutation({
      query: (student) => ({
        method: 'POST',
        body: student,
      }),
      invalidatesTags: ['Students'],
    }),
    editStudent: builder.mutation({
      query: ({ id, student }) => ({
        url: id,
        method: 'PUT',
        body: student,
      }),
      invalidatesTags: ['Students'],
    }),
    removeStudent: builder.mutation({
      query: (id) => ({
        url: id,
        method: 'DELETE',
      }),
      invalidatesTags: ['Students'],
    }),
  }),
});

export const {
  useGetStudentsQuery,
  useGetStudentsPagedQuery,
  useGetStudentByIdQuery,
  useAddStudentMutation,
  useEditStudentMutation,
  useRemoveStudentMutation,
} = studentsApi;