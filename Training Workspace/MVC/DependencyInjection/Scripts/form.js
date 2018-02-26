$(document).ready(function () {
    var cabobj;
    $("form").submit(function () {
        cabno = $("#Cabno").val();
        model = $("#Model").val();
        cap = $("#Capacity").val();
        cabobj = {
            CabNo: cabno,
            Model: model,
            Capacity: cap
        };
        console.log(cabobj);
        $.ajax({
            type: "GET",
            url: "http://localhost:4731/Cab/PutCab",
            datatype: "json",
            data: { cab: JSON.stringify(cabobj) },

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