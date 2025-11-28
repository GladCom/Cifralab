import { Routes, Route } from 'react-router-dom';
import PrivateRoute from './authorization/private-route';
import LoginPage from './authorization/login-page';
import StudentsPage from './student/students-page';
import StudentDetailsPage from './student/student-details-page';
import GroupsPage from './group/groups-page';
import GroupDetailsPage from './group/group-details-page';
import ProgramsPage from './program/programs-page';
import ProgramDetailsPage from './program/program-details-page';

import PersonRequestsPage from './request/person-requests-page';
import RequestDetailPage from './request/request-detail-page';
import OrdersDetailsPage from './order/orders-details-page';
import OrdersPage from './order/orders-page';
import ReportsPage from './report/reports-page';
import { NotificationProvider } from '../notification/notification-context';
import EducationFormPage from './catalog-page/education-form-page';
import RequestStatusPage from './catalog-page/request-status-page';
import TypeEducationPage from './catalog-page/type-education-page';
import StudentStatusPage from './catalog-page/student-status-page';
import KindOrderPage from './catalog-page/kind-order-page';
import KindDocumentRiseQualificationPage from './catalog-page/kind-document-rise-qualification-page';
import FinancingTypePage from './catalog-page/financing-type-page';
import FEAProgramPage from './catalog-page/fea-program-page';
import KindEducationProgramPage from './catalog-page/kind-education-program-page';
import ScopeOfActivityPage from './catalog-page/scope-of-activity-page';

const App = () => {
  return (
    <NotificationProvider>
      <Routes>
        <Route path="*" element={<LoginPage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route
          path="/requests"
          element={
            <PrivateRoute>
              <PersonRequestsPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/requests/:id"
          element={
            <PrivateRoute>
              <RequestDetailPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/students"
          element={
            <PrivateRoute>
              <StudentsPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/student/:id"
          element={
            <PrivateRoute>
              <StudentDetailsPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/group"
          element={
            <PrivateRoute>
              <GroupsPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/group/:id"
          element={
            <PrivateRoute>
              <GroupDetailsPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/program"
          element={
            <PrivateRoute>
              <ProgramsPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/program/:id"
          element={
            <PrivateRoute>
              <ProgramDetailsPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/educationProgram/:id"
          element={
            <PrivateRoute>
              <ProgramDetailsPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/order/"
          element={
            <PrivateRoute>
              <OrdersPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/order/:id"
          element={
            <PrivateRoute>
              <OrdersDetailsPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/report/"
          element={
            <PrivateRoute>
              <ReportsPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/educationForm"
          element={
            <PrivateRoute>
              <EducationFormPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/statusRequest"
          element={
            <PrivateRoute>
              <RequestStatusPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/typeEducation"
          element={
            <PrivateRoute>
              <TypeEducationPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/studentStatus"
          element={
            <PrivateRoute>
              <StudentStatusPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/kindOrder"
          element={
            <PrivateRoute>
              <KindOrderPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/kindDocumentRiseQualification"
          element={
            <PrivateRoute>
              <KindDocumentRiseQualificationPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/financingType"
          element={
            <PrivateRoute>
              <FinancingTypePage />
            </PrivateRoute>
          }
        />
        <Route
          path="/fEAProgram"
          element={
            <PrivateRoute>
              <FEAProgramPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/kindEducationProgram"
          element={
            <PrivateRoute>
              <KindEducationProgramPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/scopeOfActivity"
          element={
            <PrivateRoute>
              <ScopeOfActivityPage />
            </PrivateRoute>
          }
        />
      </Routes>
    </NotificationProvider>
  );
};

export default App;
