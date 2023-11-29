import React from "react";
import { Nav, Navbar, Button} from "react-bootstrap";
import {Link} from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.min.css';

export default function NaviBar() {
    return (
    <>
        <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark" >
            <Navbar.Brand>Test react app</Navbar.Brand>
            <Navbar.Toggle aria-controls="responsive-navbar-nav"/>
            <Navbar.Collapse id="responsive-navbar-nav">
                <Nav className="mr-auto">
                    <Nav.Link><Link to="/">Home</Link></Nav.Link>
                    <Nav.Link><Link to="/users">Users</Link></Nav.Link>
                    <Nav.Link><Link to="/create_item">About</Link></Nav.Link>
                </Nav>
                <Nav>
                    <Button variant="primary" className="mr-2">1Test</Button>
                    <Button variant="primary" >2Te3st</Button>
                    <Button variant="primary" >3Te3st</Button>
                </Nav>
            </Navbar.Collapse>
        </Navbar>
    </>
)}