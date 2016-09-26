let fs = require('fs')

module.exports = (req, res) => {
  if (req.pathname === '/favicon.ico') {
    fs.readFile('./content/favicon.ico', (err, data) => {
      if (err) console.log(err)

      res.writeHead(200)
      res.write(data)
      res.end()
    })

    return false
  } else {
    return true
  }
}
