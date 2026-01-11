import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import apiUrl from './api-url';

export const requestsApi = createApi({
  reducerPath: 'personrequests',
  keepUnusedDataFor: 5, // время жизни кэша для всех эндпоинтов
  baseQuery: fetchBaseQuery({ baseUrl: `${apiUrl}/Request` }), //  TODO: уточнить url
  tagTypes: ['Requests'],
  endpoints: (builder) => ({
    getPersonRequests: builder.query({
      query: () => '',
    }),
    getPersonRequestsPaged: builder.query({
      query: ({ pageNumber, pageSize, filterDataReq, sortingField, isSortAsc }) => {
        var url = `paged?page=${pageNumber}&size=${pageSize}${filterDataReq}`;
        if (sortingField) {
          url += `&sortingField=${encodeURIComponent(sortingField)}`;
        }
        if (isSortAsc !== undefined) {
          url += `&isSortAsc=${isSortAsc}`;
        }
        return url;
      },
      providesTags: ['Requests'],
    }),
    getPersonRequestSearch: builder.query({
      query: (queryText) => {
        const encoded = encodeURIComponent(JSON.stringify({ query: queryText }));
        return `Search?searchWithoutType=${encoded}`;
      },
      providesTags: ['Requests'],
    }),
    getEntranceExamStatuses: builder.query({
      query: () => 'entranceExamStatuses',
    }),
    getPersonRequestById: builder.query({
      query: (id) => ({
        url: `/GetDTO/${id}`,
        providesTags: ['RequestById'],
      }),
    }),
    addPersonRequest: builder.mutation({
      query: (request) => ({
        url: '/NewRequest',
        method: 'POST',
        body: request,
      }),
      invalidatesTags: ['Requests'],
    }),
    editPersonRequest: builder.mutation({
      query: ({ id, item }) => ({
        url: `/EditRequest/${id}`,
        method: 'PUT',
        body: item,
      }),
      invalidatesTags: ['Requests'],
    }),
    removePersonRequest: builder.mutation({
      query: (id) => ({
        url: id,
        method: 'DELETE',
      }),
      invalidatesTags: ['Requests'],
    }),
    assignStudentToRequest: builder.mutation({
      query: ({ requestId, studentId }) => ({
        url: '/SetStudent',
        method: 'PATCH',
        body: {
          requestId,
          studentId,
        },
      }),
      invalidatesTags: ['Requests'],
    }),
  }),
});

export const {
  useGetPersonRequestsQuery,
  useGetPersonRequestsPagedQuery,
  useGetPersonRequestByIdQuery,
  useAddPersonRequestMutation,
  useEditPersonRequestMutation,
  useRemovePersonRequestMutation,
  useGetPersonRequestSearchQuery,
  useGetEntranceExamStatusesQuery,
  useAssignStudentToRequestMutation,
} = requestsApi;
