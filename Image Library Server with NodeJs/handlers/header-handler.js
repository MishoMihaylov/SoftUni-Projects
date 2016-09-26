let fs = require('fs')

module.exports = (req, res, routePaths, storage) => {
  if (req.headers['statusheader'] === 'Full') {
    fs.readFile('.' + routePaths['StatusPath'], (err, data) => {
      if (err) {
        res.writeHead(404)
        res.write('Error occured while trying to access status.html!')
        res.end()
        return false
      }

      res.writeHead(200, {'Content-Type': 'text/html'})
      res.write(data)
      res.end()
      return false
    })
  } else {
    return true
  }
}
