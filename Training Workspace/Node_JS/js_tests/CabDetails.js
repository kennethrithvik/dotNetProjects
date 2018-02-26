var http = require('http');
var url=require("url");
var mongoose=require("mongoose");
var db=mongoose.connection;
db.on('error',console.error);
var cabSchema=new mongoose.Schema(
{
		CNO: Number,
		Model: String,
		Type: String,
		"Mob no": Number,
		Rate: Number
},
{ versionKey: false }
);
var cabdb=mongoose.model('CabDB',cabSchema);
		
		
var server=http.createServer(function (req, res) {

    console.log('Request received');
	var parsedUrl=url.parse(req.url,true);
	var queryAsobject=parsedUrl.query;
	console.log(JSON.stringify(queryAsobject));
    res.writeHead(200, { 'Content-Type': 'text/plain' });
    
    
	
	
	db.once('open',function()
	{

		

		var cabdata=new cabdb(queryAsobject);

		cabdata.save(function(err, cabdata)
		{
			if(err) return console.error(err);
			else{
				console.log("Storing data......");
				console.dir(cabdata);
				db.close();
				mongoose.disconnect();
			}
		});

	});



	mongoose.connect('mongodb://localhost:27017/cabdb');
	res.end(JSON.stringify(queryAsobject));
	
}).listen(4000);
console.log('Server running at port 4000');
















/*var mongoose=require('mongoose');
var db=mongoose.connection;
db.on('error',console.error);
db.on('open',function()
{

	var cabSchema=new mongoose.Schema(
	{
		EmployeeID:Number,
		EmployeeName:String,
		DOB:Date
	});
	var cabdb=mongoose.model('CabDB',cabSchema);

	var cabdata=new empdb(
	{
		EmployeeID:1112,
		EmployeeName:'Kenneth2',
		DOB:new Date('05/10/1993')
	});

	cabdata.save(function(err, cabdata)
	{
		if(err) return console.error(err);
		console.log("Storing data......");
		//console.dir(empdata);
	});

	cabdb.find(function(err, cabdbs)
	{
		if(err) return console.error(err);
		console.log("Data Retrieval......");
		console.dir(cabdbs);
	});

});



mongoose.connect('mongodb://localhost:27017/cabdb');*/