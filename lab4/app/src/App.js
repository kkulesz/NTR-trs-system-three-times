import './css/App.css';

import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Start from './pages/Start'
import Footer from './components/Footer'
import NavigationBar from './components/NavigationBar'

const App = () => {
  return (
    <div className="App">
      <Router>
        <NavigationBar />

        <Routes>
          <Route path="/" element={<Start />} / >
        </Routes>

        <Footer />
      </Router>
    </div>
  );

}

export default App;
