let fs = require('fs')

module.exports = (req, res, routePaths) => {
  if (req.pathname.startsWith(routePaths['ContentPath'])) {
    fs.readFile('.' + req.pathname, (err, data) => {
      if (err) {
        res.writeHead(404, 'File not found!')
        res.write('File is missing and cannot be found!')
        res.end()
        return false
      }

      if (req.pathname.endsWith('.html') ||
        req.pathname.endsWith('.css') ||
        req.pathname.endsWith('.js') ||
        req.pathname.endsWith('.jpg')) {
        let contentType = extractType(req.pathname)
        res.writeHead(200, {
          'Content-Type': contentType
        })
        res.write(data)
        res.end()
        return false
      } else {
        res.writeHead(400, 'File restriction!')
        res.write('Files other than .html, .css, .js and .jpg cannot be accessed!')
        res.end()
        return false
      }
    })
  } else {
    res.writeHead(403, 'Path unavailable!')
    res.write('User is only authorized to search within /content and /images/details folders!')
    res.end()
    return false
  }
}

function extractType (path) {
  let contentType = 'text/plain'

  if (path.endsWith('.html')) {
    contentType = 'text/html'
  } else if (path.endsWith('.js')) {
    contentType = 'application/javascript'
  } else if (path.endsWith('.css')) {
    contentType = 'text/css'
  } else if (path.endsWith('.jpeg')) {
    contentType = 'image/jpg'
  }

  return contentType
}
