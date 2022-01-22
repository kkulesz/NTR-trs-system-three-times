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
        return this._getUsers()
    }

    getUser(login) {
        const users = this.getUsers()
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

    // users
    _saveUsers(users) { this._writeToFile(this._usersFilename, users) }
    _getUsers() { return JSON.parse(this._readFromFile(this._usersFilename)) }

    //projects
    _saveProjects(projects) { this._writeToFile(this._projectsFilename, projects) }
    _getProjects() { return JSON.parse(this._readFromFile(this._projectsFilename)) }

    //activities
    _saveActivities(activities) { this._writeToFile(this._activitiesFilename, activities) }
    _getActivities() { return JSON.parse(this._readFromFile(this._activitiesFilename)) }

    // general
    _writeToFile(filename, objects) { this._fs.writeFile(filename, JSON.stringify(objects), () => { }) }
    _readFromFile(filename) { return this._fs.readFileSync(filename, 'utf8') }
}

module.exports = Repository