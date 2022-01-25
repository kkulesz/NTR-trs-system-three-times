import './css/App.css';

import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import Start from './pages/Start'
import ActivitiesDashboard from './pages/ActivitiesDashboard'
import CreateActivityForm from './pages/CreateActivityForm';
import DisplayActivity from './pages/DisplayActivity';

import Footer from './components/Footer'
import NavigationBar from './components/NavigationBar'
import UpdateActivityForm from './pages/UpdateActivityForm';



const App = () => {
  return (
    <div className="App">
      <Router>
        <NavigationBar />

        <Routes>
          <Route path="/" element={<Start />} />
          <Route path="/activitiesDashboard" element={<ActivitiesDashboard />} />
          <Route path="/createActivityForm" element={<CreateActivityForm />} />
          <Route path="/displayActivity" element={<DisplayActivity />} />
          <Route path="/updateActivityForm" element={<UpdateActivityForm />} />
        </Routes>

        <Footer />
      </Router>
    </div>
  );

}

export default App;
