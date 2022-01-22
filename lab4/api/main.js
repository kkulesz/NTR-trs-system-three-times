const express = require('express')
const app = express()

app.get('/', (req, res)=>{
    res.send('nothing here')
})

const userRouter = require('./routes/users')
app.use('/users', userRouter)

const projectRouter = require('./routes/projects')
app.use('/projects', projectRouter)

app.listen(3001)
