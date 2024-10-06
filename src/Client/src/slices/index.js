import { configureStore } from '@reduxjs/toolkit';
import userReducer  from './userSlice.js';
import { authApi }  from '../services/authApi.js';
import { studentsApi }  from '../services/studentsApi.js';
import { requestsApi }  from '../services/requestsApi.js';

export default configureStore({
  reducer: {
    user: userReducer,
    [authApi.reducerPath]: authApi.reducer,
    [studentsApi.reducerPath]: studentsApi.reducer,
    [requestsApi.reducerPath]: requestsApi.reducer
  },
  middleware: (
    (getDefaultMiddleware) => getDefaultMiddleware()
    .concat(authApi.middleware)
    .concat(studentsApi.middleware)
    .concat(requestsApi.middleware)
  ),
});