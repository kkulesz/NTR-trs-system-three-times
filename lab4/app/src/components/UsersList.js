import React from 'react'
import { Link, Navigate } from 'react-router-dom'
import { getUser } from '../dataSource/api'

import { useGlobalContext } from '../state'


const UsersList = (props) => {
    const {setUser} = useGlobalContext()

    const users = props.users
    const onClick = async (e) => {
        e.preventDefault()
        const login = e.target.value

        const response = await getUser(login)
        console.log(response)
        localStorage.setItem('loggedUser', login)
        setUser(login)
        // IF NOT navigate('TODO')
    };

    return (
        <div>
            <h1 className="display-4" style={{ marginBottom: '2rem' }}>
                Jakiś nagłówek
            </h1>
            <div>
                <form>
                    {users.map((user) => {
                        return (
                            <input
                                type="button"
                                key={user.login}
                                value={user.login}
                                style={{ margin: '2px 3px' }}
                                onClick={onClick}
                            />
                        );
                    })}
                </form>
            </div>
        </div>
    );

}

export default UsersList;
