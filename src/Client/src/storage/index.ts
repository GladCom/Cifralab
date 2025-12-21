import { configureStore } from '@reduxjs/toolkit';
import userReducer from './slice/user-slice';
import { authApi } from './service/auth-api';
import { studentsApi } from './service/student-api';
import { educationFormApi } from './service/education-form-api';
import { requestStatusApi } from './service/request-status-api';
import { typeEducationApi } from './service/type-education-api';
import { studentStatusApi } from './service/student-status-api';
import { kindOrderApi } from './service/kind-order-api';
import { kindDocumentRiseQualificationApi } from './service/kind-document-rise-qualification-api';
import { kindEducationProgramApi } from './service/kind-education-program-api';
import { financingTypeApi } from './service/financing-type-api';
import { feaProgramApi } from './service/fea-program-api';
import { educationProgramApi } from './service/education-program-api';
import { groupsApi } from './service/groups-api';
import { requestsApi } from './service/request-api';
import { scopeOfActivityApi } from './service/scope-of-activity-api';

export const store = configureStore({
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

export type RootState = ReturnType<typeof store.getState>;
