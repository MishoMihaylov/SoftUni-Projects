let fs = require('fs')
let multiparty = require('multiparty')
var uuid = require('node-uuid')

module.exports = (req, res, routePaths, storage) => {
  let form = new multiparty.Form()

  form.parse(req, (err, fields, files) => {
    if (err) {
      console.log(err)
    }

    if (!validateInput(res, fields, files)) {
      return false
    }

    let pictureName = fields.PictureName[0]
    let categoryName = fields.CategoryName[0]
    let accessibility = fields.Accessibility[0]

    let picture = files.Picture[0]

    let readStream = fs.createReadStream(picture.path)

    let path = '.' + routePaths.GalleryPath + '/' + categoryName
    if (!fs.existsSync(path)) {
      fs.mkdir(path)
    }

    let fileParts = picture.originalFilename.split('.')
    let fileExtension = fileParts[fileParts.length - 1]

    if (!validateExtension(res, fileExtension)) {
      return false
    }

    let url = uuid.v1() + '.' + fileExtension

    // let fileName = picture.originalFilename
    let fileName = url
    let writeStream = fs.createWriteStream(path + ' /' + fileName)

    readStream.pipe(writeStream)
    let fileFullPath = path + '/' + fileName
    let newPicture = { Name: pictureName, Category: categoryName, Path: fileFullPath, Url: url, Accessibility: accessibility }
    storage.push(newPicture)
    let storageAsJSON = JSON.stringify(storage)
    fs.writeFile('.' + routePaths.StoragePath, storageAsJSON)
    createStatusHtml(storage, routePaths['StatusPath'])

    returnSuccess(res, routePaths)
    return false
  })
}

function createStatusHtml (storage, route) {
  let wstream = fs.createWriteStream('.' + route)
  wstream.write('<html>')
  wstream.write('<head>')
  wstream.write('<title> Storage Count </title>')
  wstream.write('</head>')
  wstream.write('<body>')
  wstream.write('<p>')
  wstream.write('Current Count of All Images(Public and Private): ' + storage.length)
  wstream.write('</p>')
  wstream.write('</body>')
  wstream.write('</html>')
  wstream.end()
}

function validateInput (res, fields, files) {
  if (!fields.PictureName[0] || fields.PictureName[0].trim() === '' ||
      !fields.CategoryName[0] || fields.CategoryName[0].trim() === '' ||
      !fields.Accessibility[0] || fields.Accessibility[0].trim() === '' ||
      files.Picture[0].size === 0 || !files.Picture[0].originalFilename || !files.Picture[0].originalFilename.trim() === '') {
    res.writeHead(200)
    res.write('<div>')
    res.write(' Invalid input. One or more of the fields are null or empty.')
    res.write('<br />')
    res.write('<br />')
    res.write('<a href="/"><button>Back to the Form</button></a>')
    res.write('</div>')
    res.end()
    return false
  } else {
    return true
  }
}

function validateExtension (res, fileExtension) {
  if (fileExtension === 'jpg' || fileExtension === 'jpeg' || fileExtension === 'png') {
    return true
  } else {
    res.writeHead(200)
    res.write('Invalid file extension. Allowed formats: .jpg, .jpeg, .png!')
    res.end()
    return false
  }
}

function returnSuccess (res, routePaths) {
  res.writeHead(200, {'Content-Type': 'text/html'})
  res.write('<span>Picture added!</span>')
  res.write('<br />')
  res.write('<br />')
  res.write('<a href="' + routePaths['IndexSlashPath'] + '"><button>Go Back</button></a>')
  res.write(' ')
  res.write('<a href="' + routePaths['GalleryPath'] + '"><button>To Gallery</button></a>')
  res.end()
}
