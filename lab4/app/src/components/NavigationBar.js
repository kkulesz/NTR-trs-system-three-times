import React from 'react';
import { Link } from 'react-router-dom';
import { useGlobalState } from '../state';


const NavigationBar = () => {
  const { loggedUser } = useGlobalState();


  return (
    <header>
      <nav>
        <div>
          <Link to="/">
            KonradKulesza
          </Link>
          {
            loggedUser !== '' && // do not render if not logged in

            <Link to="/activitiesDashboard">
              Activities
            </Link>
          }
          {
            loggedUser === '' &&
            <div>TODO navigation and logout {loggedUser}</div>
          }
        </div>

      </nav>
    </header>
  )

}

export default NavigationBar;
