import React from 'react';

import { LoginPage } from '../../src/features/auth/login-page';
import { EducationFormPage } from '../../src/entities/education-form/education-form-page';
import { FEAProgramPage } from '../../src/entities/fea-program/fea-program-page';
import { FinancingTypePage } from '../../src/entities/financing-type/financing-type-page';
import { KindDocumentRiseQualificationPage } from '../../src/entities/kind-document-rise-qualification/kind-document-rise-qualification-page';
import { KindEducationProgramPage } from '../../src/entities/kind-education-program/kind-education-program-page';
import { KindOrderPage } from '../../src/entities/kind-order/kind-order-page';
import { RequestStatusPage } from '../../src/entities/request-status/request-status-page';
import { ScopeOfActivityPage } from '../../src/entities/scope-of-activity/scope-of-activity-page';
import { StudentStatusPage } from '../../src/entities/student-status/student-status-page';
import { TypeEducationPage } from '../../src/entities/type-education/type-education-page';
import { GroupDetailsPage } from '../../src/features/group/group-details-page';
import { GroupsPage } from '../../src/features/group/groups-page';
import { OrdersPage } from '../../src/features/order/orders-page';
import { ProgramDetailsPage } from '../../src/features/program/program-details-page';
import { ProgramsPage } from '../../src/features/program/programs-page';
import { ReportsPage } from '../../src/features/report/reports-page';
import { PersonRequestsPage } from '../../src/features/request/person-requests-page';
import { RequestDetailPage } from '../../src/features/request/request-detail-page';
import { StudentDetailsPage } from '../../src/features/student/student-details-page';
import { StudentsPage } from '../../src/features/student/students-page';

import { renderWithProviders } from '../../src/test-utils/render-with-providers';

// Автоматически генерируем тест для каждой страницы
const pages = [
  { name: 'LoginPage', component: <LoginPage /> },
  { name: 'PersonRequestsPage', component: <PersonRequestsPage /> },
  { name: 'RequestDetailPage', component: <RequestDetailPage /> },
  { name: 'StudentsPage', component: <StudentsPage /> },
  { name: 'StudentDetailsPage', component: <StudentDetailsPage /> },
  { name: 'GroupsPage', component: <GroupsPage /> },
  { name: 'GroupDetailsPage', component: <GroupDetailsPage /> },
  { name: 'ProgramsPage', component: <ProgramsPage /> },
  { name: 'ProgramDetailsPage', component: <ProgramDetailsPage /> },
  { name: 'OrdersPage', component: <OrdersPage /> },
  { name: 'ReportsPage', component: <ReportsPage /> },
  { name: 'EducationFormPage', component: <EducationFormPage /> },
  { name: 'RequestStatusPage', component: <RequestStatusPage /> },
  { name: 'TypeEducationPage', component: <TypeEducationPage /> },
  { name: 'StudentStatusPage', component: <StudentStatusPage /> },
  { name: 'KindOrderPage', component: <KindOrderPage /> },
  { name: 'KindDocumentRiseQualificationPage', component: <KindDocumentRiseQualificationPage /> },
  { name: 'FinancingTypePage', component: <FinancingTypePage /> },
  { name: 'FEAProgramPage', component: <FEAProgramPage /> },
  { name: 'KindEducationProgramPage', component: <KindEducationProgramPage /> },
  { name: 'ScopeOfActivityPage', component: <ScopeOfActivityPage /> },
];

// Подавляем act-предупреждения от асинхронных обновлений в smoke-тестах
const originalConsoleError = console.error;
beforeAll(() => {
  console.error = (...args) => {
    if (typeof args[0] === 'string' && args[0].includes('An update to') && args[0].includes('was not wrapped in act')) {
      return;
    }
    originalConsoleError(...args);
  };
});
afterAll(() => {
  console.error = originalConsoleError;
});

describe('Smoke tests: pages render without crashing', () => {
  pages.forEach(({ name, component }) => {
    test(`${name} renders without crashing`, () => {
      expect(() => renderWithProviders(component)).not.toThrow();
    });
  });
});
