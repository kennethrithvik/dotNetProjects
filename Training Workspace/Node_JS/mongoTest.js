var mongoose=require('mongoose');
var db=mongoose.connection;
db.on('error',console.error);
db.on('open',function()
{

	var empSchema=new mongoose.Schema(
	{
		EmployeeID:Number,
		EmployeeName:String,
		DOB:Date
	});
	var empdb=mongoose.model('EmpDB',empSchema);

	var empdata=new empdb(
	{
		EmployeeID:1112,
		EmployeeName:'Kenneth2',
		DOB:new Date('05/10/1993')
	});

	empdata.save(function(err, empdata)
	{
		if(err) return console.error(err);
		console.log("Storing data......");
		console.dir(empdata);
	});

	empdb.find(function(err, empdbs)
	{
		if(err) return console.error(err);
		console.log("Data Retrieval......");
		console.dir(empdbs);
	});

});



mongoose.connect('mongodb://localhost:27017/empdb');