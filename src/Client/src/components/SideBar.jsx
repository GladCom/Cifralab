import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import SwitchLang from './Switch';

function BasicExample() {
  return (
    <Navbar sticky="top" className="navBar">
      <Container>
        <Navbar.Brand href="#home">Cyfra-Lab</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link href="groups">{global.config.conf.groups[window.localStorage.getItem("lang")]}</Nav.Link>
            <Nav.Link href="requests">{global.config.conf.requests[window.localStorage.getItem("lang")]}</Nav.Link>
            <Nav.Link href="students">{global.config.conf.students[window.localStorage.getItem("lang")]}</Nav.Link>
            <NavDropdown title={global.config.conf.list[window.localStorage.getItem("lang")]} id="basic-nav-dropdown">
              <NavDropdown.Item href="educationPrograms">
              {global.config.conf.eduProgram[window.localStorage.getItem("lang")]}  
                </NavDropdown.Item>
              <NavDropdown.Item href="educationForms">
              {global.config.conf.educationForm[window.localStorage.getItem("lang")]}
              </NavDropdown.Item>
              <NavDropdown.Item href="educationTypes">
              {global.config.conf.educationType[window.localStorage.getItem("lang")]}
              </NavDropdown.Item>
              <NavDropdown.Item href="FEAPrograms">
              {global.config.conf.feaProgram[window.localStorage.getItem("lang")]}
              </NavDropdown.Item> 
              <NavDropdown.Item href="FinancingTypes">
              {global.config.conf.financingType[window.localStorage.getItem("lang")]}
              </NavDropdown.Item> 
              <NavDropdown.Item href="ScopeOfActivities">
              {global.config.conf.scopeOfActivity[window.localStorage.getItem("lang")]}
              </NavDropdown.Item> 
              <NavDropdown.Item href="StudentsDocuments">
              {global.config.conf.studentsDoc[window.localStorage.getItem("lang")]}
              </NavDropdown.Item> 
              <NavDropdown.Item href="StudentsEducations">
              {global.config.conf.studentEducation[window.localStorage.getItem("lang")]}
              </NavDropdown.Item> 
              <NavDropdown.Item href="StudentsStatus">
              {global.config.conf.studentStatus[window.localStorage.getItem("lang")]}
              </NavDropdown.Item> 
            </NavDropdown>
          </Nav>
        </Navbar.Collapse>
        <SwitchLang />
      </Container>
    </Navbar>
  );
}

export default BasicExample;