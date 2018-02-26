$(document).ready(function () {
    var customerobj;
    $("form").submit(function(){
        customerid=$("#customerid").val();
        customername=$("#customername").val();
        mobileno=$("#mob").val();
        dob=$("#dob").val();
        email = $("#email").val();
        range = $("#rot").val();
        customerobj={
            CustomerID:customerid,
            CustomerName:customername,
            MobileNo:mobileno,
            DOB:dob,
            Email: email,
            RangeOfTravel:range};
        console.log(customerobj);
        $.ajax({
            type: "GET",
            url: "http://localhost:2864/Customers/Create",
            datatype: "json",
            data: { id: JSON.stringify(customerobj) },

            success: function (data) {
                console.log(data);
            },

            error: function (er) {
                console.log(er);
            }

        });
        return false;
    });
 
});