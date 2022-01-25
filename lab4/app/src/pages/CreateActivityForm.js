import React, { useEffect, useState } from 'react'

import { Link } from 'react-router-dom';


import { fetchActiveProjects } from '../dataSource/projectsApi'

const CreateActivityForm = () => {
    const [projects, setProjects] = useState([])
    useEffect(() => {
        fetchActiveProjects()
            .then((res) => { setProjects(res) })
    }, [])

    const projectNames = projects.map(p => p.name)


    return (
        <div>
            <Link to="/activitiesDashboard">
                Back
            </Link>
            {projects.map((p) => <div>{p.owner} - {p.name}</div>)}
        </div>
    )

}

export default CreateActivityForm;
