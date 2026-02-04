import React from 'react';

import LoginPage from '../src/components/authorization/login-page';
import PersonRequestsPage from '../src/components/request/person-requests-page';
import { RequestDetailPage } from '../src/components/request/request-detail-page';
import StudentsPage from '../src/components/student/students-page';
import { StudentDetailsPage } from '../src/components/student/student-details-page';
import GroupsPage from '../src/components/group/groups-page';
import GroupDetailsPage from '../src/components/group/group-details-page';
import ProgramsPage from '../src/components/program/programs-page';
import ProgramDetailsPage from '../src/components/program/program-details-page';
import OrdersPage from '../src/components/order/orders-page';
import ReportsPage from '../src/components/report/reports-page';

import { renderWithProviders } from '../src/test-utils/render-with-providers';

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
  // Добавляйте новые сюда
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
