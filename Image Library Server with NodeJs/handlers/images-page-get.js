let fs = require('fs')

module.exports = (req, res, routePaths, storage) => {
  if (req.pathname === routePaths.GalleryPath) {
    let categories = fs.readdirSync('.' + routePaths.GalleryPath)

    res.writeHead(200, {'Content-Type': 'text/html'})
    res.write('---Categories---')
    res.write('<br>')
    res.write('<br>')

    if (storage.length === 0) {
      res.write('No images added yet.')
    } else {
      res.write('<div style="float: none">')
      for (let folder of categories) {
        res.write('<div style="float: left">')
        res.write('<a  href="' + routePaths.GalleryPath + '/' + folder + '">')
        res.write('<img alt="' + folder + '" src="' + routePaths.ContentPath + '/' + 'folder.jpg' + '" width="100" height="100">')
        res.write('<div style="text-align: center">'+ folder +'</div>')
        res.write('</a>')
        res.write('</div>')
      }
      res.write('</div>')
    }

    res.write('<br>')
    res.write('<br>')
    res.write('<br>')
    res.write('<a style="clear: both; float: left; margin: 15px 15px 15px 15px;" href="' + routePaths['IndexSlashPath'] + '"><button>Back to Input Form</button></a>')
    res.end()
    return false
  } else {
    return true
  }
}
