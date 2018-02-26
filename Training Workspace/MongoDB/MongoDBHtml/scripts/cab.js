$("#btnAdd").click(function () {
        var a1 = $("#txtCN").val();
        var a2 = $("#txtMo").val();
        var a3 = $("#txtTy").val();
        var a4 = $("#txtMob").val();
        var a5 = $("#txtRT").val();
        var cabarr =
            {
                "CNO": a1,
                "Model": a2,
                "Type": a3,
                "Mob no": a4,
                "Rate": a5
            };
        console.log(cabarr);


        $.ajax({
            url: "http://localhost:4000",

            dataType: "JSON",
            data: cabarr,
            type: 'GET',
            success: function (data) {
               
                console.log(data)
            },
            failure: function (msg) {
                console.log(msg);

            },

        });





    });
