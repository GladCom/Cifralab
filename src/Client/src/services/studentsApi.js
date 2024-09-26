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
      invalidatesTags: ['Students'],
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