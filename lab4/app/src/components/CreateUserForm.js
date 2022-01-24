import React, { useState } from 'react';
import { createUser } from '../dataSource/api';

import { useGlobalContext } from '../state'

const CreateUserForm = () => {
    const {setUser} = useGlobalContext()

    const [userLogin, setUserLogin] = useState('');
    const handleChange = (e) => setUserLogin(e.target.value);
    const handleSubmit = async (e) => {
        console.log(userLogin) //TODO to remove
        e.preventDefault()
        
        const response = await createUser(userLogin)
        console.log(response)
        
        //if success
        localStorage.setItem('loggedUser', userLogin)
        setUser(userLogin)

        //if not
        //TODO
     }

    return (
        <div>
            <h4>Add new user</h4>
            <div>
                <form onSubmit={handleSubmit}>
                    <div>
                        <input
                            type="text"
                            value={userLogin}
                            name="registrationLogin"
                            // className="form-control"
                            style={{ marginTop: '10px' }}
                            onChange={handleChange}
                        />
                        <input
                            type="submit"
                            value="Add"
                            // className="btn btn-primary"
                            style={{ marginTop: '10px' }}
                        />
                    </div>
                </form>
            </div>
        </div>
    );


}

export default CreateUserForm;
