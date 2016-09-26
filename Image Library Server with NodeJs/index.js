let http = require('http')
let url = require('url')
let fs = require('fs')

let favicon = require('./handlers/favicon')
let headerHandler = require('./handlers/header-handler')
let homePageGet = require('./handlers/home-page-get')
let imagesPage = require('./handlers/images-page-get')
let imageDetailsGet = require('./handlers/image-details-get')
let staticFilesGet = require('./handlers/static-files-get')

let homePagePost = require('./handlers/home-page-post')

let port = 5667

let storage = []
let routePaths = []

initRoutePaths(routePaths)
initStatus(routePaths.StatusPath)

http.createServer((req, res) => {
  req.pathname = pathParser(req.url)

  if (req.method === 'POST') {
    homePagePost(req, res, routePaths, storage)
  } else if (req.method === 'GET') {
    let handlers = [
      favicon,
      headerHandler,
      homePageGet,
      imagesPage,
      imageDetailsGet,
      staticFilesGet
    ]

    for (let handler of handlers) {
      let passed

      if (handler.length === 4) {
        passed = handler(req, res, routePaths, storage)
      } else {
        passed = handler(req, res, routePaths)
      }

      if (!passed) {
        break
      }
    }
  }
})
.listen(port)

function pathParser (inputUrl) {
  return url.parse(inputUrl).pathname
}

function initRoutePaths (routePaths) {
  // Image paths
  let galleryPath = '/images'
  let imgDetailsPath = '/images/details'
  // Content path
  let contentPath = '/content'
  // Status path
  let statusPath = '/status.html'
  // Index paths
  let indexSlashPath = '/'
  let indexPath = '/index'
  let indexHtmlPath = '/index.html'

  routePaths.GalleryPath = galleryPath
  routePaths.ImgDetailsPath = imgDetailsPath
  routePaths.ContentPath = contentPath
  routePaths.StatusPath = statusPath
  routePaths.IndexSlashPath = indexSlashPath
  routePaths.IndexPath = indexPath
  routePaths.IndexHtmlPath = indexHtmlPath
}

function initStatus (route) {
  let wstream = fs.createWriteStream('.' + route)
  wstream.write('<html>')
  wstream.write('<head>')
  wstream.write('<title> Storage Count </title>')
  wstream.write('</head>')
  wstream.write('<body>')
  wstream.write('<p>')
  wstream.write('Current Count of Images: ' + storage.length)
  wstream.write('</p>')
  wstream.write('</body>')
  wstream.write('</html>')
  wstream.end()
}
