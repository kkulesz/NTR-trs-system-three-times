class Repository {
    constructor() {
        this._fs = require('fs')

        this._dataDir = './data'
        this._usersFilename = `${this._dataDir}/users.json`
        this._projectsFilename = `${this._dataDir}/projects.json`
        this._activitiesFilename = `${this._dataDir}/activities.json`

        this._makeSureEverythingExists()
    }

    createUser(newUser) {
        const users = this.getUsers()
        if (users.find(u => u.login === newUser.login)) {
            return undefined
        } else {
            users.push(newUser)
            this._saveUsers(users)
            return newUser
        }
    }

    getUsers() {
        var result = this._fs.readFileSync(this._usersFilename, 'utf8')
        return JSON.parse(result);
    }

    getUser(login) {
        const users = this.getUsers()
        console.log(users)
        return users.find(u => u.login == login)
    }




    /******************************************
     *****************PRIVATE******************
     ******************************************/

    _makeSureEverythingExists() {
        if (!this._fs.existsSync(this._dataDir)) {
            this._fs.mkdirSync(this._dataDir);
        }
        this._makeSureFileExists(this._usersFilename)
        this._makeSureFileExists(this._projectsFilename)
        this._makeSureFileExists(this._activitiesFilename)
    }

    _makeSureFileExists(filename) {
        if (!this._fs.existsSync(filename)) {
            this._fs.writeFile(filename, JSON.stringify([]), () => { })
        }
    }

    _saveUsers(users) { this._writeToFile(this._usersFilename, users) }

    _saveProjects(projects) { this._writeToFile(this._projectsFilename, projects) }

    _saveActivities(activities) { this._writeToFile(this._activitiesFilename, activities) }

    _writeToFile(filename, objects) { this._fs.writeFile(filename, JSON.stringify(objects), () => { }) }
}

module.exports = Repository