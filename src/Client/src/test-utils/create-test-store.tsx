// Все API-слайсы, которые используются в компонентах
import { requestsApi } from '../../src/storage/service/request-api';
import { requestStatusApi } from '../../src/storage/service/request-status-api';
import { educationProgramApi } from '../../src/storage/service/education-program-api';
import { kindEducationProgramApi } from '../../src/storage/service/kind-education-program-api';
import { educationFormApi } from '../../src/storage/service/education-form-api';
import { feaProgramApi } from '../../src/storage/service/fea-program-api';
import { financingTypeApi } from '../../src/storage/service/financing-type-api';
import { kindDocumentRiseQualificationApi } from '../../src/storage/service/kind-document-rise-qualification-api';
import { typeEducationApi } from '../../src/storage/service/type-education-api';
import { scopeOfActivityApi } from '../../src/storage/service/scope-of-activity-api';
import { studentsApi } from '../../src/storage/service/student-api';
import { groupsApi } from '../../src/storage/service/groups-api';

import { configureStore } from '@reduxjs/toolkit';

// Мок-редюсер для user
const userReducer = (state = { loggedIn: true, userName: 'Test User' }, _action) => {
  return state;
};

export const createTestStore = (preloadedState = {}) =>
  configureStore({
    preloadedState,
    reducer: {
      user: userReducer,
      [requestsApi.reducerPath]: requestsApi.reducer,
      [requestStatusApi.reducerPath]: requestStatusApi.reducer,
      [educationProgramApi.reducerPath]: educationProgramApi.reducer,
      [kindEducationProgramApi.reducerPath]: kindEducationProgramApi.reducer,
      [educationFormApi.reducerPath]: educationFormApi.reducer,
      [feaProgramApi.reducerPath]: feaProgramApi.reducer,
      [financingTypeApi.reducerPath]: financingTypeApi.reducer,
      [kindDocumentRiseQualificationApi.reducerPath]: kindDocumentRiseQualificationApi.reducer,
      [typeEducationApi.reducerPath]: typeEducationApi.reducer,
      [scopeOfActivityApi.reducerPath]: scopeOfActivityApi.reducer,
      [studentsApi.reducerPath]: studentsApi.reducer,
      [groupsApi.reducerPath]: groupsApi.reducer,
    },
    middleware: (getDefaultMiddleware) =>
      getDefaultMiddleware()
        .concat(requestsApi.middleware)
        .concat(requestStatusApi.middleware)
        .concat(educationProgramApi.middleware)
        .concat(kindEducationProgramApi.middleware)
        .concat(educationFormApi.middleware)
        .concat(feaProgramApi.middleware)
        .concat(financingTypeApi.middleware)
        .concat(kindDocumentRiseQualificationApi.middleware)
        .concat(typeEducationApi.middleware)
        .concat(scopeOfActivityApi.middleware)
        .concat(studentsApi.middleware)
        .concat(groupsApi.middleware),
  });
