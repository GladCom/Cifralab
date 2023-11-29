import logo from './logo.svg';
import './App.css';
import "./components/Navibar"
import NaviBar from './components/Navibar';
import MediaCard from './components/MediaCard';
import SideBar from './components/SideBar';
import {BrowserRouter, Route, Link, Routes} from 'react-router-dom';
import StudentTable from './components/StudentTable.jsx';
import "./assets/css/dino.css"
import FullFeaturedCrudGrid from './components/qwe.jsx';


function App() {
  return (
    <BrowserRouter>
      <SideBar/>
      <Routes>
        <Route path="/Home" element={<MediaCard/>} />
        <Route path="/Students" element={<FullFeaturedCrudGrid/>} />
      </Routes>
      <iframe src="https://chromedino.com/" frameborder="0" scrolling="no" width="100%" height="100%" loading="lazy"></iframe>
    </BrowserRouter>

  );
}


export default App;
