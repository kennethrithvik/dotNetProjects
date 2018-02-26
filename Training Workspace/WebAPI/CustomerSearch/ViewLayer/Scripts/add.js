$(document).ready(function () {
    $("#btnSub").click(function () {
        
        var cdata = {
            CabId: $("#txtCN").val(),
            Model: $("#txtMod").val(),
            Capacity: $("#txtCap").val()
        };
        //console.log("clicked");
        $.ajax({
            type: "GET",
            url: "http://localhost:2203/api/Cab",
            datatype: "json",
            data: { cab: JSON.stringify(cdata) },

            success: function (data) {
                //var data = JSON.parse(data);
                console.log(data);
                
            },

            error: function (er) {
                console.log(er);
            }

        });
    });
});
