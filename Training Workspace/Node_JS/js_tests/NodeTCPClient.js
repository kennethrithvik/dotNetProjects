var netref = require('net');
var readlineref = require('readline'); 
var inputaccess = readlineref.createInterface(process.stdin, process.stdout);



var host="127.0.0.1"
var port = 8124;

var client = new netref.Socket();
client.connect(port,host,function()
{
    console.log('CONNECTED TO: ' + host + ':' + port);
    
inputaccess.setPrompt('Enter Message> ');
inputaccess.prompt();
inputaccess.on('line', function(line) { 


    client.write(line);
});


});

client.on('data', function(data) {
    console.log('DATA: ' + data);
    
});

