import { configureStore } from '@reduxjs/toolkit';
import userReducer  from './userSlice.js';
import { authApi }  from '../services/authApi.js';

export default configureStore({
  reducer: {
    user: userReducer,
    [authApi.reducerPath]: authApi.reducer,
  },
  middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(authApi.middleware),
});