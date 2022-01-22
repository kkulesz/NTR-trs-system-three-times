const express = require('express')
const router = express.Router()

router
    .route('/')
    .post((req, res) => {
        res.send('project created')
    })
    .get((req, res) => {
        res.send('list of all projects of user')
    })

router
    .route('/:projectName/activities')
    .post((req, res) => {
        res.send(`activity for ${req.params.projectName} created`)
    })
    .get((req, res) => {
        res.send('list of all activities of project')
    })



module.exports = router