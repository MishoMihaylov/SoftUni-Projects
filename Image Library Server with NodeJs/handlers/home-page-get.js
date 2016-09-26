let fs = require('fs')

module.exports = (req, res, routePaths, storage) => {
  console.log(routePaths.IndexSlashPath)
  if (req.pathname === routePaths['IndexSlashPath'] ||
  req.pathname === routePaths['IndexPath'] ||
   req.pathname === routePaths['IndexHtmlPath']) {
    fs.readFile('.' + routePaths['IndexHtmlPath'], (err, data) => {
      if (err) {
        res.writeHead(400)
        res.write('Unexpected error!')
        res.end()
        return false
      }

      res.writeHead(200, {
        'Content-Type': 'text/html'
      })
      res.write(data)
      res.end()
    })

    return false
  } else {
    return true
  }
}
