var netref = require('net');
var readlineref = require('readline'); 
var inputaccess = readlineref.createInterface(process.stdin, process.stdout);

var server = netref.createServer(function(socket)
{
   console.log("Connected"+socket.remoteAddress+':'+ socket.remotePort);

socket.on('data', function(data) {
                   
        console.log('Server Receives Data from Client ' + socket.remoteAddress + ': ' + data);
        inputaccess.setPrompt('Enter Message> ');
inputaccess.prompt();
inputaccess.on('line', function(line) { 


socket.write('Server Sending Data to client "' + line + '"');
});
        
    });


    socket.on('close', function(data) {
        console.log('CLOSED: ' + socket.remoteAddress +' '+ socket.remotePort);
});


});

server.listen(8124);

console.log("TCP srever started....Client can access it from port number 8124");