const express = require('express')
const router = express.Router()


router
    .route('/')
    .post((req, res) => {
        res.send('user created')
    })
    .get((req, res) => {
        res.send('list of all users')
    })

router.get('/:login', (req, res) => {
    res.send('login')
})

module.exports = router
