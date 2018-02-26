var http=require('http');
var server=http.createServer(function(request,response)
{
	response.writeHead(200,{"Content-Type":"text/plain"});
	response.end("Response from node_js server");
});
server.listen(4000);
console.log("server has started running from port 4000");