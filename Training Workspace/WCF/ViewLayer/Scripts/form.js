$(document).ready(function () {
    $("#btnSub").click(function () {
        
        var ccdata = {
            CardNo: $("#txtCCN").val(),
            ExpiryDate: $("#dtExD").val()
        };
        //console.log("clicked");
        $.ajax({
            type: "GET",
            url: "http://localhost:1691/Card/ValCard",
            datatype: "json",
            data: { card: JSON.stringify(ccdata) },

            success: function (data) {
                var data = JSON.parse(data);
                console.log(data);
                if(data==true)
                    $("#res").text("Valid Card");
                else
                    $("#res").text("Invalid Card");
            },

            error: function (er) {
                console.log(er);
            }

        });
    });
});
