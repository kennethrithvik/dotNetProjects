/*var http = require('http'),
    fs = require('fs');


fs.readFile('D:/Tesco batch5/MongoDB/MongoDBHtml/Create.html', function (err, html) {
    if (err) {
        throw err; 
    }       
    http.createServer(function(request, response) {  
        response.writeHeader(200, {"Content-Type": "text/html"});  
        response.write(html);  
        response.end();  
    }).listen(4000);
});*/




var port = 4000;
var serverUrl = "127.0.0.1";

var http = require("http");
var path = require("path"); 
var fs = require("fs"); 		

console.log("Starting web server at " + serverUrl + ":" + port);

http.createServer( function(req, res) {

	var now = new Date();

	var filename = "index.html";
	var ext = path.extname(filename);
	var localPath = "D:/Tesco batch5/MongoDB/MongoDBHtml/";//__dirname;
	var validExtensions = {
		".html" : "text/html",			
		".js": "application/javascript", 
		".css": "text/css",
		".txt": "text/plain",
		".jpg": "image/jpeg",
		".ico": "image/ico",
		".gif": "image/gif",
		".png": "image/png"
	};
	var isValidExt = validExtensions[ext];

	if (isValidExt) {
		
		localPath += filename;
		fs.exists(localPath, function(exists) {
			if(exists) {
				console.log("Serving file: " + localPath);
				getFile(localPath, res, ext);
			} else {
				console.log("File not found: " + localPath);
				res.writeHead(404);
				res.end();
			}
		});

	} else {
		console.log("Invalid file extension detected: " + ext)
	}

}).listen(port, serverUrl);

function getFile(localPath, res, mimeType) {
	fs.readFile(localPath, function(err, contents) {
		if(!err) {
			
			res.statusCode = 200;
			res.writeHeader(200, {"Content-Type": "text/html"});  
			res.write(contents);  
			res.end();
		} else {
			res.writeHead(500);
			res.end();
		}
	});
}