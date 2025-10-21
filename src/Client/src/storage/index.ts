import { configureStore } from '@reduxjs/toolkit';
import userReducer from './slices/userSlice';
import { authApi } from './services/authApi';
import { studentsApi } from './services/studentsApi';
import { educationFormApi } from './services/educationFormApi';
import { requestStatusApi } from './services/requestStatusApi';
import { typeEducationApi } from './services/typeEducationApi';
import { studentStatusApi } from './services/studentStatusApi';
import { kindOrderApi } from './services/kindOrderApi';
import { kindDocumentRiseQualificationApi } from './services/kindDocumentRiseQualificationApi';
import { kindEducationProgramApi } from './services/kindEducationProgramApi';
import { financingTypeApi } from './services/financingTypeApi';
import { feaProgramApi } from './services/feaProgramApi';
import { educationProgramApi } from './services/educationProgramApi';
import { groupsApi } from './services/groupsApi';
import { requestsApi } from './services/requestsApi';
import { scopeOfActivityApi } from './services/scopeOfActivityApi';

export default configureStore({
  reducer: {
    user: userReducer,
    [authApi.reducerPath]: authApi.reducer,
    [studentsApi.reducerPath]: studentsApi.reducer,
    [educationFormApi.reducerPath]: educationFormApi.reducer,
    [requestStatusApi.reducerPath]: requestStatusApi.reducer,
    [typeEducationApi.reducerPath]: typeEducationApi.reducer,
    [studentStatusApi.reducerPath]: studentStatusApi.reducer,
    [kindOrderApi.reducerPath]: kindOrderApi.reducer,
    [kindDocumentRiseQualificationApi.reducerPath]: kindDocumentRiseQualificationApi.reducer,
    [kindEducationProgramApi.reducerPath]: kindEducationProgramApi.reducer,
    [financingTypeApi.reducerPath]: financingTypeApi.reducer,
    [feaProgramApi.reducerPath]: feaProgramApi.reducer,
    [educationProgramApi.reducerPath]: educationProgramApi.reducer,
    [groupsApi.reducerPath]: groupsApi.reducer,
    [requestsApi.reducerPath]: requestsApi.reducer,
    [scopeOfActivityApi.reducerPath]: scopeOfActivityApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware()
      .concat(authApi.middleware)
      .concat(studentsApi.middleware)
      .concat(educationFormApi.middleware)
      .concat(requestStatusApi.middleware)
      .concat(typeEducationApi.middleware)
      .concat(studentStatusApi.middleware)
      .concat(kindOrderApi.middleware)
      .concat(kindDocumentRiseQualificationApi.middleware)
      .concat(kindEducationProgramApi.middleware)
      .concat(financingTypeApi.middleware)
      .concat(feaProgramApi.middleware)
      .concat(educationProgramApi.middleware)
      .concat(groupsApi.middleware)
      .concat(requestsApi.middleware)
      .concat(scopeOfActivityApi.middleware),
});
