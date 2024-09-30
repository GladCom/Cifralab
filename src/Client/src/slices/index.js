import { configureStore } from '@reduxjs/toolkit';
import userReducer  from './userSlice.js';
import { authApi }  from '../services/authApi.js';
import { studentsApi }  from '../services/studentsApi.js';
import { educationFormApi }  from '../services/educationFormApi.js';
import { requestStatusApi }  from '../services/requestStatusApi.js';

export default configureStore({
  reducer: {
    user: userReducer,
    [authApi.reducerPath]: authApi.reducer,
    [studentsApi.reducerPath]: studentsApi.reducer,
    [educationFormApi.reducerPath]: educationFormApi.reducer,
    [requestStatusApi.reducerPath]: requestStatusApi.reducer,
  },
  middleware: (
    (getDefaultMiddleware) => getDefaultMiddleware()
    .concat(authApi.middleware)
    .concat(studentsApi.middleware)
    .concat(educationFormApi.middleware)
    .concat(requestStatusApi.middleware)
  ),
});