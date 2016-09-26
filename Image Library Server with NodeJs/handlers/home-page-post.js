var qs = require('querystring')
var fs = require('fs')

module.exports = (req, res, routePaths, storage) => {
  var body = ''

  req.on('data', function (data) {
    body += data
  })

  req.on('end', function () {
    let post = qs.parse(body)

    if (!post['FileName'] || post['FileName'] === '' || !post['Url'] || post['Url'] === '') {
      res.writeHead(200)
      res.write('<div>')
      res.write(' Invalid input. One or more of the fields are null or empty.')
      res.write('<br />')
      res.write('<br />')
      res.write('<a href="/"><button>Back to the Form</button></a>')
      res.write('</div>')
      res.end()
    } else {
      let newPicture = { Name: post['FileName'], Url: post['Url'] }
      storage.push(newPicture)
      createStatusHtml(storage, routePaths['StatusPath'])
      res.writeHead(200, {'Content-Type': 'text/html'})
      res.write('<span>Picture added!</span>')
      res.write('<br />')
      res.write('<br />')
      res.write('<a href="' + routePaths['IndexSlashPath'] + '"><button>Go Back</button></a>')
      res.write(' ')
      res.write('<a href="' + routePaths['GalleryPath'] + '"><button>To Gallery</button></a>')
      res.end()
    }
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
  wstream.write('Current Count of Images: ' + storage.length)
  wstream.write('</p>')
  wstream.write('</body>')
  wstream.write('</html>')
  wstream.end()
}
