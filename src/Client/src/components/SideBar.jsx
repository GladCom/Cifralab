import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import cyfraLogo from '../img/cyfraLogo.png';
import style from "./style/SideBar.css";

function BasicExample() {
  return (
    <Navbar sticky="top" className="navBar">
      <Container>
        <Navbar.Brand href="#home"><img
              src={cyfraLogo}
              width="80"
              height="37"
              alt="Cyfra-logo"
            /></Navbar.Brand>
        <Navbar.Toggle/>
        <Navbar.Collapse>
          <Nav>
            <Nav.Link className="navLink" href="groups">Группы</Nav.Link>
            <Nav.Link className="navLink" href="students">Студенты</Nav.Link>
            <Nav.Link className="navLink" href="educationPrograms">Программы обучения </Nav.Link>
            <NavDropdown title="Остальные" className='navLink'>
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
      </Container>
    </Navbar>
  );
}

export default BasicExample;