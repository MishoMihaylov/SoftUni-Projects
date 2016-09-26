module.exports = (req, res, routePaths, storage) => {
  if (req.pathname === routePaths.GalleryPath) {
    res.writeHead(200, {'Content-Type': 'text/html'})
    res.write('---Gallery---')
    res.write('<br>')
    res.write('<br>')

    if (storage.length === 0) {
      res.write('No images added yet.')
    } else {
      for (let i = 0; i < storage.length; i++) {
        res.write('<a href="' + routePaths.ImgDetailsPath + '/' + i + '">')
        res.write('<img border="2" alt="' + storage[i].Name + '" src="' + storage[i].Url + '" width="100" height="100">')
        res.write('</a>')
        res.write(' ')
      }
    }

    res.write('<br>')
    res.write('<br>')
    res.write('<a href="' + routePaths['IndexSlashPath'] + '"><button>Back to Input Form</button></a>')
    res.end()
    return false
  } else {
    return true
  }
}
