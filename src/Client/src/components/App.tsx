import React from 'react';
import { Routes, Route } from 'react-router-dom';
import PrivateRoute from './authorization/PrivateRoute';
import LoginPage from './authorization/LoginPage';
import StudentsPage from './student/StudentsPage';
import StudentDetailsPage from './student/StudentDetailsPage';
import GroupsPage from './group/GroupsPage';
import GroupDetailsPage from './group/GroupDetailsPage';
import ProgramsPage from './program/ProgramsPage';
import ProgramDetailsPage from './program/ProgramDetailsPage';
import EducationFormPage from './catalogPages/EducationFormPage';
import RequestStatusPage from './catalogPages/RequestStatusPage';
import TypeEducationPage from './catalogPages/TypeEducationPage';
import StudentStatusPage from './catalogPages/StudentStatusPage';
import ScopeOfActivityPage from './catalogPages/ScopeOfActivityPage';
import KindOrderPage from './catalogPages/KindOrderPage';
import KindDocumentRiseQualificationPage from './catalogPages/KindDocumentRiseQualificationPage';
import KindEducationProgramPage from './catalogPages/KindEducationProgramPage';
import FinancingTypePage from './catalogPages/FinancingTypePage';
import FEAProgramPage from './catalogPages/FEAProgramPage';
import PersonRequestsPage from './request/PersonRequestsPage';
import RequestDetailPage from './request/RequestDetailPage';
import OrdersDetailsPage from './order/OrdersDetailsPage';
import OrdersPage from './order/OrdersPage';
import ReportsPage from './report/ReportsPage';
import { NotificationProvider } from '../notifications/NotificationContext';

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
