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
            <Nav.Link href="groups">Groups</Nav.Link>
            <Nav.Link href="requests">Requests</Nav.Link>
            <Nav.Link href="students">Students</Nav.Link>
            <NavDropdown title="Lists" id="basic-nav-dropdown">
              <NavDropdown.Item href="educationPrograms">
                Education Programs  
                </NavDropdown.Item>
              <NavDropdown.Item href="educationForms">
                Education Forms
              </NavDropdown.Item>
              <NavDropdown.Item href="educationTypes">
                Education Types
              </NavDropdown.Item>
              {/* <NavDropdown.Divider /> */}
              <NavDropdown.Item href="FEAPrograms">
                FEA Programs
              </NavDropdown.Item> 
              <NavDropdown.Item href="FinancingTypes">
                Financing Types
              </NavDropdown.Item> 
              <NavDropdown.Item href="ScopeOfActivities">
                Scopes of activities
              </NavDropdown.Item> 
              <NavDropdown.Item href="StudentsDocuments">
                Students Documents
              </NavDropdown.Item> 
              <NavDropdown.Item href="StudentsEducations">
                Students Educations
              </NavDropdown.Item> 
              <NavDropdown.Item href="StudentsStatus">
                Students Status
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