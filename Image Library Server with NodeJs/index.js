let http = require('http')
let url = require('url')
let fs = require('fs')

let favicon = require('./handlers/favicon')
let headerHandler = require('./handlers/header-handler')
let homePageGet = require('./handlers/home-page-get')
let imagesPictureGet = require('./handlers/images-picture-get')
let imagesPage = require('./handlers/images-page-get')
let imagesCategoryPage = require('./handlers/images-category-get')
let staticFilesGet = require('./handlers/static-files-get')

let homePagePost = require('./handlers/home-page-post')

let port = process.env.PORT || 5667

let storage = []
let routePaths = []

initRoutePaths(routePaths)
initStatus(routePaths.StatusPath)
loadStorage(storage, routePaths)

http.createServer((req, res) => {
  req.pathname = pathParser(req.url)

  if (req.method === 'POST') {
    homePagePost(req, res, routePaths, storage)
  } else if (req.method === 'GET') {
    let handlers = [
      favicon,
      headerHandler,
      homePageGet,
      imagesPictureGet,
      imagesPage,
      imagesCategoryPage,
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

function loadStorage (storage, routePaths) {
  if (!fs.existsSync('.' + routePaths.StoragePath)) {
    let path = '.' + routePaths.GalleryPath + '/Words'
    if (!fs.existsSync(path)) {
      fs.mkdir(path)
    }
    return
  }

  let storageInformation = JSON.parse(fs.readFileSync('.' + routePaths.StoragePath))

  for (let entity of storageInformation) {
    storage.push(entity)
  }
}

function initRoutePaths (routePaths) {
  // Image paths
  let galleryPath = '/images'
  // Content path
  let contentPath = '/content'
  // Status path
  let statusPath = '/status.html'
  // Index paths
  let indexSlashPath = '/'
  let indexPath = '/index'
  let indexHtmlPath = '/index.html'
  // Storage
  let storagePath = '/storage/database.json'

  routePaths.GalleryPath = galleryPath
  routePaths.ContentPath = contentPath
  routePaths.StatusPath = statusPath
  routePaths.IndexSlashPath = indexSlashPath
  routePaths.IndexPath = indexPath
  routePaths.IndexHtmlPath = indexHtmlPath
  routePaths.StoragePath = storagePath
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
