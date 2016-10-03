let fs = require('fs')

module.exports = (req, res, routePaths, storage) => {
  if (req.pathname.startsWith(routePaths.GalleryPath)) {
    let pathParams = req.pathname.split('/')
    let category = pathParams[2]
    category = category.replace('%20', ' ')

    let categoryPath = '.' + routePaths.GalleryPath + '/' + category

    if (!fs.existsSync(categoryPath)) {
      res.writeHead(404, 'File not found!')
      res.write('File is missing and cannot be found!')
      res.end()
      return false
    }

    let categoryImages = []
    category = category.replace(' ', '%20')
    for (let image of storage) {
      if (image.Category === category && image.Accessibility === 'public') {
        categoryImages.push(image)
      }
    }

    if (categoryImages.length === 0) {
      res.writeHead(200, {
        'Content-Type': 'text/html'
      })
      res.write('<span>No pictures in this category.</span>')
      res.write('<br>')
      res.write('<a style="clear: both; float: left; margin: 15px 15px 15px 15px;" href="' + routePaths.GalleryPath + '"><button>Back to Gallery</button></a>')
      res.end()
      return false
    }

    res.writeHead(200)
    for (let image of categoryImages) {
      res.write('<div style="float: left">')
      res.write('<a  href="' + '.' + image.Path + '">')
      res.write('<img alt="' + category + '" src="' + '.' + image.Path + '" width="100" height="100">')
      res.write('<div style="text-align: center">' + image.Name + '</div>')
      res.write('</a>')
      res.write('</div>')
    }

    res.write('<br>')
    res.write('<a style="clear: both; float: left; margin: 15px 15px 15px 15px;" href="' + routePaths.GalleryPath + '"><button>Back to Gallery</button></a>')
    res.end()
    return false
  } else {
    return true
  }
}
