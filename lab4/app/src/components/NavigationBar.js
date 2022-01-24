import React from 'react';
import { Link, Navigate } from 'react-router-dom';
import { useGlobalContext } from '../state';


const NavigationBar = () => {
  const { loggedUser } = useGlobalContext();


  return (
    <header>
      <nav>
        <div>
          <Link to="/">
            KonradKulesza
          </Link>
          {
            loggedUser !== '' && // do not render if not logged in
            <div>TODO navigation {loggedUser}</div>
          }
        </div>

      </nav>
    </header>
  )

}

export default NavigationBar;
