$(document).ready(function () {

   
    $.ajax({
        url: "http://jsonplaceholder.typicode.com/users",
        type: "GET",
        dataType: "JSON",
        success: function (data) {
            var mytab = $("<table></table>").attr({ id: "tab" });

            var rowh = $("<tr></tr>").appendTo(mytab);
            for (key in data[0]) {
                $("<th></th>").text(key).appendTo(rowh);
            }

            $.each(data, function (key, item) {
                var row = $("<tr></tr>").appendTo(mytab);
                $("<td></td>").text(item.id).appendTo(row);
                $("<td></td>").text(item.name).appendTo(row);
                $("<td></td>").text(item.address.city).appendTo(row);
                $("<td></td>").text(item.email).appendTo(row);
            });
            mytab.appendTo("body");
            $("tr:even").css("background-color", "lightgreen");
        },

        failure: function (msg) {
            console.log(msg);
        }

    });

    



});


//Gaming	1
//Mobiles and Tablets	10
//Computers	39
//Eyewear	95
//Home Entertainment	96
//Sports and Fitness	130
//Pens and Stationery	314
//Clothing	371
//Home Decor	646
//Beauty and Personal Care	714
//Bags, Wallets and Belts	907
//Watches	948
//Home and Kitchen	1003
//Cameras and Accessories	1028
//Baby Care	1048
//Toys and School Supplies	1078
//Jewellery	1204
//Footwear	1285
//Auto Parts	1528
//Hardware and Accessories	3262
//Pet Supplies	3918
//Musical Instruments	4083
//Books	5266
//Men	10625
//Regional Webstore	99999
//Events	100420
//Foods from States	100445