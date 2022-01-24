const path = require("path");
const express = require('express')
const cors = require('cors')
const app = express()



app.listen(3001)
app.use(cors())

const userRouter = require('./routes/users')
app.use('/users', userRouter)

const projectRouter = require('./routes/projects')
app.use('/projects', projectRouter)


app.use(express.static(path.join(__dirname, '../app/build')));
app.get("/", (req, res) =>
  res.sendFile(path.join(__dirname, "../app/build", "index.html"))
);



// app.listen(3001)
