$(document).ready(function () {
    
        //console.log("clicked");
        $.ajax({
            type: "GET",
            url: "http://localhost:2203/api/Cab",
            datatype: "json",
            success: function (data) {
                $.each(data, function (key, val) {
                    row = $("<tr></tr>").appendTo($("#tb"));
                    $("<td></td>").text(val.CabId).appendTo(row);
                    $("<td></td>").text(val.Model).appendTo(row);
                    $("<td></td>").text(val.Capacity).appendTo(row);
                });
            },

            error: function (er) {
                console.log(er);
            }

        });
   
});
