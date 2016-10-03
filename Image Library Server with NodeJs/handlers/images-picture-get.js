let fs = require('fs')

module.exports = (req, res, routePaths, storage) => {
  if (req.pathname.startsWith(routePaths.GalleryPath) &&
  (req.pathname.endsWith('jpg') || req.pathname.endsWith('jpeg') || req.pathname.endsWith('png'))) {
    let contentType = ''
    let contentDisposition = 'attachment'

    if (req.pathname.endsWith('jpg')) {
      contentType = 'image/jpg'
    } else if (req.pathname.endsWith('jpeg')) {
      contentType = 'image/jpg'
    } else if (req.pathname.endsWith('png')) {
      contentType = 'image/png'
    }

    fs.readFile('.' + req.pathname, (err, data) => {
      if (err) {
        res.writeHead(404, 'File not found!')
        res.write('File is missing and cannot be found!')
        res.end()
        return false
      }

      res.writeHead(200, {
        'Content-Type': contentType,
        'Content-Disposition': contentDisposition
      })
      res.write(data)
      res.end()
    })

    return false
  } else {
    return true
  }
}
