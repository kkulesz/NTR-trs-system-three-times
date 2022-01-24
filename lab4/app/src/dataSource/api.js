import fetch from 'node-fetch';

const domainPath = 'http://localhost:3001'

const usersPath = `${domainPath}/users`


export const fetchUsers = async () => {
    return fetch(usersPath, {
        method: 'GET'
    }).then((resp) => {
        return resp.json()
    }).then((data) => {
        return data
    })
}

export const getUser = async (login) => {
    return fetch(`${usersPath}/${login}`, {
        method: 'GET'
    }).then((resp) => {
        return resp.json()
    }).then((data) => {
        return data
    })
}

export const createUser = async (login) => {
    console.log(login)
    return fetch(`${usersPath}`, {
        method: 'POST',
        body: JSON.stringify({ "login": login }),
        headers: { 'Content-Type': 'application/json' }
    }).then((resp) => {
        return resp.json()
    }).then((data) => {
        return data
    })
}