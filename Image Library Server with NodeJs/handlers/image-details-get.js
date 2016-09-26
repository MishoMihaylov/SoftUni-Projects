module.exports = (req, res, routePaths, storage) => {
  if (req.pathname.startsWith(routePaths.ImgDetailsPath)) {
    let pathParams = req.pathname.split('/')
    let imgIndex = pathParams[pathParams.length - 1]

    if (storage[imgIndex]) {
      res.writeHead(200, {'Content-Type': 'text/html'})
      res.write('<div>')
      res.write('<p>Picture Name: ' + storage[imgIndex].Name + '</p>')
      res.write('<a href="' + storage[imgIndex].Url + '">')
      res.write('<img border="2" alt="' + storage[imgIndex].Name + '" src="' + storage[imgIndex].Url + '" width="100" height="100">')
      res.write('</a>')
      res.write('</div>')
      res.write('<br />')
      res.write('<a href="' + routePaths['GalleryPath'] + '"><button>Back to All Images</button></a>')
      res.end()
      return false
    } else {
      res.writeHead(404, 'File not found!')
      res.write('Error 404. File not found!')
      res.end()
      return false
    }
  } else {
    return true
  }
}
