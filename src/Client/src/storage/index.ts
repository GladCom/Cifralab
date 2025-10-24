import { configureStore } from '@reduxjs/toolkit';
import userReducer from './slices/user-slice';
import { authApi } from './services/auth-api';
import { studentsApi } from './services/students-api';
import { educationFormApi } from './services/education-form-api';
import { requestStatusApi } from './services/request-status-api';
import { typeEducationApi } from './services/type-education-api';
import { studentStatusApi } from './services/student-status-api';
import { kindOrderApi } from './services/kind-order-api';
import { kindDocumentRiseQualificationApi } from './services/kind-document-rise-qualification-api';
import { kindEducationProgramApi } from './services/kind-education-program-api';
import { financingTypeApi } from './services/financing-type-api';
import { feaProgramApi } from './services/fea-program-api';
import { educationProgramApi } from './services/education-program-api';
import { groupsApi } from './services/groups-api';
import { requestsApi } from './services/requests-api';
import { scopeOfActivityApi } from './services/scope-of-activity-api';

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
