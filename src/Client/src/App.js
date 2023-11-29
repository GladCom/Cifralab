import logo from './logo.svg';
import './App.css';
import "./common/Navibar.jsx"
import MediaCard from './common/MediaCard.jsx';
import SideBar from './components/SideBar';
import {BrowserRouter, Route, Link, Routes} from 'react-router-dom';
import "./assets/css/dino.css"
import CollapsibleTable from './components/StudentTable.jsx';
import EditableTable from './common/EditableTableExample/EditableTable.jsx';

function App() {
  return (
    <BrowserRouter>
      <SideBar/>
      <Routes>
        <Route path="/Home" element={<MediaCard/>} />
        <Route path="/Students" element={<CollapsibleTable/>} />
      </Routes>
      <iframe src="https://chromedino.com/" frameborder="0" scrolling="no" width="100%" height="100%" loading="lazy"></iframe>
    </BrowserRouter>

  );
}


export default App;
