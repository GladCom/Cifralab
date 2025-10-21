import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const authApi = createApi({
  reducerPath: 'auth',
  baseQuery: fetchBaseQuery({ baseUrl: '/' }),
  endpoints: (builder) => ({
    loginUser: builder.query({
      query: () => '', //  TODO: доработать
    }),
    logoutUser: builder.query({
      query: () => '', //  TODO: доработать
    }),
  }),
});

export const { useLoginUserQuery, useLogoutUserQuery } = authApi;
