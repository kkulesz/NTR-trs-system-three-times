import React, { useState, useContext } from 'react';
const AppContext = React.createContext();


const AppState = ({ children }) => {
    let date = new Date();
    const [loggedUser, setUser] = useState(localStorage.getItem('loggedUser') || '');
    const [chosenMonth, setMonth] = useState(parseInt(localStorage.getItem('chosenMonth')) || date.getMonth() + 1);
    const [chosenYear, setYear] = useState(parseInt(localStorage.getItem('chosenYear')) || date.getFullYear());


    return (
        <AppContext.Provider
            value={{
                loggedUser,
                setUser,
                chosenMonth,
                setMonth,
                chosenYear,
                setYear
            }}
        >
            {children}
        </AppContext.Provider>
    );
};

export const useGlobalContext = () => {
    return useContext(AppContext);
};

export { AppContext, AppState };
