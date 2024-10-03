import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import PrivateRoute from './PrivateRoute.jsx'
import LoginPage from './pages/LoginPage.jsx';
import RequestServicePage from './pages/RequestServicePage.jsx';
import StudentsPage from './pages/StudentsPage.jsx';
import PersonRequestsPage from './pages/PersonRequestsPage.jsx';
import StudentDetailsPage from './pages/StudentDetailsPage.jsx';
import GroupsPage from './pages/GroupsPage.jsx';
import ProgramsPage from './pages/ProgramsPage.jsx';

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="*" element={<LoginPage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/requests" element={(
            <PrivateRoute>
              {/*<RequestServicePage />*/}
              <PersonRequestsPage />
            </PrivateRoute>
          )}
        />
        <Route path="/students" element={(
            <PrivateRoute>
              <StudentsPage />
            </PrivateRoute>
          )}
        />
        <Route path="/students/:id" element={(
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
      </Routes>
    </Router>
  );
}

export default App;
