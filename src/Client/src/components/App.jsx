import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import PrivateRoute from './authorization/PrivateRoute.jsx'
import LoginPage from './authorization/LoginPage.jsx';
import RequestServicePage from './request/RequestServicePage.jsx';
import StudentsPage from './student/StudentsPage.jsx';
import StudentDetailsPage from './student/StudentDetailsPage.jsx';
import GroupsPage from './group/GroupsPage.jsx';
import ProgramsPage from './program/ProgramsPage.jsx';
import EducationFormPage from './catalogPages/EducationFormPage.jsx';

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="*" element={<LoginPage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/requests" element={(
            <PrivateRoute>
              <RequestServicePage />
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
        <Route path="/groups" element={(
            <PrivateRoute>
              <GroupsPage />
            </PrivateRoute>
          )}
        />
        <Route path="/programs" element={(
            <PrivateRoute>
              <ProgramsPage />
            </PrivateRoute>
          )}
        />
        <Route path="/educationForm" element={(
            <PrivateRoute>
              <EducationFormPage />
            </PrivateRoute>
          )}
        />
      </Routes>
    </Router>
  );
}

export default App;
