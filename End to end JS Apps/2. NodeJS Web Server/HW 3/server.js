var http = require('http');
var fs = require('fs');
var formidable = require('formidable');
var PORT = 1333;

var storedFile;

var server = http.createServer(function (request, response) {
    if (request.url == '/upload') {
        var form = new formidable.IncomingForm();
        form.uploadDir = './files/';
        form.encoding = 'utf-8';
        form.keepExtensions = true;
        response.writeHead(200, { 'content-type': 'text/html' });

        form.parse(request, function (err, fields, files) {
        });

        form.on('end', function () {
            response.write('<h2>Successfull upload.</h2>');
            response.write('<a href="/download">Download</a>');
            storedFile = this.openedFiles[0].path;
            originalFileName = this.openedFiles[0].name;

            response.end();
        });
    } else if (request.url == '/download') {
        var stat = fs.statSync(storedFile);
        response.writeHead(200, {
            'Content-Length': stat.size
        });
        var readStream = fs.createReadStream(storedFile);
        readStream.pipe(response);
    } else {
        response.write('<div><form action="/upload" method="post" enctype="multipart/form-data"><input type="file" size=80 name="pic" ><input type="submit" value="Upload"></form></div>');
        response.end();
    }
});

server.listen(PORT);
console.log('Server running on ' + PORT);
