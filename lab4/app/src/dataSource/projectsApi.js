import fetch from 'node-fetch';

import { domainPath } from './commons';

const projectsPath = `${domainPath}/projects`

export const fetchActiveProjects = async () => {
    return fetch(projectsPath, {
        method: 'GET'
    }).then((resp) => {
        return resp.json()
    }).then((data) => {
        return data
    })
}


