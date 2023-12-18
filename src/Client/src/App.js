import logo from './logo.svg';
import './App.css';
import "./common/Navibar.jsx"
import MediaCard from './common/MediaCard.jsx';
import SideBar from './components/SideBar';
import {BrowserRouter, Route, Link, Routes} from 'react-router-dom';
import StudentTable from './components/StudentTable.jsx';
import GroupTable from './components/GroupTable.jsx'
import RequestTable from './components/RequestTable.jsx';
import EducationProgramTable from './components/tables/EducationProgram.jsx';
import EducationFormTable from './components/tables/EducationForm.jsx';
import EducationTypeTable from './components/tables/EducationType.jsx';
import FEAProgramTable from './components/tables/FEAProgram.jsx';
import FinancingTypeTable from './components/tables/FinancingType.jsx';
import ScopeOfActivityTable from './components/tables/ScopeOfActivity.jsx';
import StudentDocumentTable from './components/tables/StudentDocument.jsx';
import StudentEducationTable from './components/tables/StudentEducation.jsx';
import StudentStatusTable from './components/tables/StudentStatus.jsx';

function App() {
  return (
    <BrowserRouter>
      <SideBar/>
      <Routes>
        <Route path="/Groups" element={<GroupTable/>} />
        <Route path="/Students" element={<StudentTable/>} />
        <Route path="/Groups" element={<GroupTable/>}/>
        <Route path="/Requests" element={<RequestTable/>}/>
        <Route path="/EducationPrograms" element={<EducationProgramTable/>}/>
        <Route path="/EducationForms" element={<EducationFormTable/>}/>
        <Route path="/EducationTypes" element={<EducationTypeTable/>}/>
        <Route path="/FEAPrograms" element={<FEAProgramTable/>}/>
        <Route path="/FinancingTypes" element={<FinancingTypeTable/>}/>
        <Route path="/ScopeOfActivities" element={<ScopeOfActivityTable/>}/>
        <Route path="/StudentDocuments" element={<StudentDocumentTable/>}/>
        <Route path="/StudentsEducations" element={<StudentEducationTable/>}/>
        <Route path="/StudentsStatus" element={<StudentStatusTable/>}/>
      </Routes>
    </BrowserRouter>

  );
}


export default App;
