import { Routes, Route } from 'react-router-dom';
import { NotificationProvider } from '../notification/notification-context';
import { StudentDetailsPage } from '../features/student/student-details-page';
import { RequestDetailPage } from '../features/request/request-detail-page';
import { PersonRequestsPage } from '../features/request/person-requests-page';
import { StudentsPage } from '../features/student/students-page';
import { GroupsPage } from '../features/group/groups-page';
import { GroupDetailsPage } from '../features/group/group-details-page';
import { ProgramsPage } from '../features/program/programs-page';
import { ProgramDetailsPage } from '../features/program/program-details-page';
import { OrdersPage } from '../features/order/orders-page';
import { ReportsPage } from '../features/report/reports-page';
import { EducationFormPage } from '../entities/education-form/education-form-page';
import { RequestStatusPage } from '../entities/request-status/request-status-page';
import { TypeEducationPage } from '../entities/type-education/type-education-page';
import { StudentStatusPage } from '../entities/student-status/student-status-page';
import { KindOrderPage } from '../entities/kind-order/kind-order-page';
import { KindDocumentRiseQualificationPage } from '../entities/kind-document-rise-qualification/kind-document-rise-qualification-page';
import { FinancingTypePage } from '../entities/financing-type/financing-type-page';
import { FEAProgramPage } from '../entities/fea-program/fea-program-page';
import { KindEducationProgramPage } from '../entities/kind-education-program/kind-education-program-page';
import { ScopeOfActivityPage } from '../entities/scope-of-activity/scope-of-activity-page';
import { PrivateRoute } from '../features/auth/private-route';
import { LoginPage } from '../features/auth/login-page';

export const AppRoutes = () => {
  return (
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
  );
};
