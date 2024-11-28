import React from 'react';
import { Routes, Route } from 'react-router-dom';
import PrivateRoute from './authorization/PrivateRoute.jsx'
import LoginPage from './authorization/LoginPage.jsx';
import StudentsPage from './student/StudentsPage.jsx';
import StudentDetailsPage from './student/StudentDetailsPage.jsx';
import GroupsPage from './group/GroupsPage.jsx';
import GroupDetailsPage from './group/GroupDetailsPage.jsx';
import ProgramsPage from './program/ProgramsPage.jsx';
import ProgramDetailsPage from './program/ProgramDetailsPage.jsx';
import EducationFormPage from './catalogPages/EducationFormPage.jsx';
import RequestStatusPage from './catalogPages/RequestStatusPage.jsx';
import TypeEducationPage from './catalogPages/TypeEducationPage.jsx';
import StudentStatusPage from './catalogPages/StudentStatusPage.jsx';
import ScopeOfActivityPage from './catalogPages/ScopeOfActivityPage.jsx';
import KindOrderPage from './catalogPages/KindOrderPage.jsx';
import KindDocumentRiseQualificationPage from './catalogPages/KindDocumentRiseQualificationPage.jsx';
import KindEducationProgramPage from './catalogPages/KindEducationProgramPage.jsx';
import FinancingTypePage from './catalogPages/FinancingTypePage.jsx';
import FEAProgramPage from './catalogPages/FEAProgramPage.jsx';
import PersonRequestsPage from './request/PersonRequestsPage.jsx';
import RequestDetailPage from './request/RequestDetailPage.jsx';
import OrdersDetailsPage from './order/OrdersDetailsPage.jsx';
import OrdersPage from './order/OrdersPage.jsx';
import ReportsPage from './report/ReportsPage.jsx';
import { NotificationProvider } from '../notifications/NotificationContext.js';

const App = () => {
  return (
    <NotificationProvider>
        <Routes>
            <Route path="*" element={<LoginPage />} />
            <Route path="/login" element={<LoginPage />} />
            <Route path="/requests" element={(
                <PrivateRoute>
                  <PersonRequestsPage />
                </PrivateRoute>
              )}
            />
            <Route path="/requests/:id" element={(
                <PrivateRoute>
                  <RequestDetailPage />
                </PrivateRoute>
              )}
            />
            <Route path="/students" element={(
                <PrivateRoute>
                  <StudentsPage />
                </PrivateRoute>
              )}
            />
            <Route path="/student/:id" element={(
                <PrivateRoute>
                  <StudentDetailsPage />
                </PrivateRoute>
              )}
            />
            <Route path="/group" element={(
                <PrivateRoute>
                  <GroupsPage />
                </PrivateRoute>
              )}
            />
            <Route path="/group/:id" element={(
                <PrivateRoute>
                  <GroupDetailsPage />
                </PrivateRoute>
              )}
            />
            <Route path="/program" element={(
                <PrivateRoute>
                  <ProgramsPage />
                </PrivateRoute>
              )}
            />
            <Route path="/program/:id" element={(
                <PrivateRoute>
                  <ProgramDetailsPage />
                </PrivateRoute>
              )}
            />
            <Route path="/educationProgram/:id" element={(
                <PrivateRoute>
                  <ProgramDetailsPage />
                </PrivateRoute>
              )}
            />
            <Route path="/order/" element={(
                <PrivateRoute>
                  <OrdersPage />
                </PrivateRoute>
              )}
            />
            <Route path="/order/:id" element={(
                <PrivateRoute>
                  <OrdersDetailsPage />
                </PrivateRoute>
              )}
            />
            <Route path="/report/" element={(
                <PrivateRoute>
                  <ReportsPage />
                </PrivateRoute>
              )}
            />
            <Route path="/educationForm" element={(
                <PrivateRoute>
                  <EducationFormPage />
                </PrivateRoute>
              )}
            />
            <Route path="/statusRequest" element={(
                <PrivateRoute>
                  <RequestStatusPage />
                </PrivateRoute>
              )}
            />
            <Route path="/typeEducation" element={(
                <PrivateRoute>
                  <TypeEducationPage />
                </PrivateRoute>
              )}
            />
            <Route path="/studentStatus" element={(
                <PrivateRoute>
                  <StudentStatusPage />
                </PrivateRoute>
              )}
            />
            <Route path="/kindOrder" element={(
                <PrivateRoute>
                  <KindOrderPage />
                </PrivateRoute>
              )}
            />
            <Route path="/kindDocumentRiseQualification" element={(
                <PrivateRoute>
                  <KindDocumentRiseQualificationPage />
                </PrivateRoute>
              )}
            />
            <Route path="/financingType" element={(
                <PrivateRoute>
                  <FinancingTypePage />
                </PrivateRoute>
              )}
            />
            <Route path="/fEAProgram" element={(
                <PrivateRoute>
                  <FEAProgramPage />
                </PrivateRoute>
              )}
            />
            <Route path="/kindEducationProgram" element={(
                <PrivateRoute>
                  <KindEducationProgramPage />
                </PrivateRoute>
              )}
            />
            <Route path="/scopeOfActivity" element={(
                <PrivateRoute>
                  <ScopeOfActivityPage />
                </PrivateRoute>
              )}
            />
          </Routes>
    </NotificationProvider>
  );
}

export default App;
