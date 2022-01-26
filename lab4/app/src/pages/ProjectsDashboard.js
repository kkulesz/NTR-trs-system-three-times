import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom';

import { fetchActiveProjects } from '../dataSource/projectsApi'
import { useGlobalState } from '../state'

const ProjectsDashBoard = () => {
    const { loggedUser } = useGlobalState()
    const [projects, setProjects] = useState([])
    useEffect(() => {
        fetchActiveProjects()
            .then((res) => { setProjects(res) })
    }, [])
    console.log(projects)

    return (
        <div>
            {projects.map(
                (p) => { <div>{p}</div> }
            )}
        </div>
    )

}

export default ProjectsDashBoard;
