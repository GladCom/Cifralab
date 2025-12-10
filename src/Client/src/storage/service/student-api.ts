import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './api-url';

export const studentsApi = createApi({
  reducerPath: 'students',
  keepUnusedDataFor: 5, // время жизни кэша для всех эндпоинтов
  baseQuery: fetchBaseQuery({ baseUrl: `${apiUrl}/student` }), //  TODO: уточнить url
  tagTypes: ['Students'],
  endpoints: (builder) => ({
    getStudents: builder.query({
      query: () => '',
    }),
    getStudentsPaged: builder.query({
      query: ({ pageNumber, pageSize, filterDataReq }) => `paged?page=${pageNumber}&size=${pageSize}${filterDataReq}`,
      providesTags: ['Students'],
    }),
    getStudentSearch: builder.query({
      //  TODO: в разработке
      query: (_queryText) => '',
    }),
    getStudentById: builder.query({
      query: (id) => id,
    }),
    addStudent: builder.mutation({
      query: (student) => ({
        url: '',
        method: 'POST',
        body: student,
      }),
      invalidatesTags: ['Students'],
    }),
    editStudent: builder.mutation({
      query: ({ id, item }) => ({
        url: id,
        method: 'PUT',
        body: item,
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
    getSimilarStudents: builder.query({
      query: ({ fullname, adress, email, phone }) => {
        const encoded = encodeURIComponent(JSON.stringify({fullname: fullname, adress: adress, email: email, phone: phone}));
        return `Filter?filterWithoutType=${encoded}`;
      },
      providesTags: ['Students']
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
  useGetStudentSearchQuery,
  useGetSimilarStudentsQuery
} = studentsApi;
