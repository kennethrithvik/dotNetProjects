
$(document).ready(function () {



    $(".js__p_start, .js__p_another_start").simplePopup();

    $("#adpics").cycle();


    var categs = [
           { "id": 1, "Name": "Gaming" },
           { "id": 10, "Name": "Mobiles and Tablets" },
           { "id": 39, "Name": "Computers" },
           { "id": 95, "Name": "Eyewear" },
           { "id": 96, "Name": "Home Entertainment" },
           { "id": 130, "Name": "Sports and Fitness" },
           { "id": 314, "Name": "Pens and Stationery" },
           { "id": 371, "Name": "Clothing" },
           { "id": 646, "Name": "Home Decor" },
           { "id": 714, "Name": "Beauty and Personal Care" },
           { "id": 907, "Name": "Bags, Wallets and Belts" },
           { "id": 948, "Name": "Watches" },
           { "id": 1003, "Name": "Home and Kitchen" },
           { "id": 1028, "Name": "Cameras and Accessories" }
    ];
    $.each(categs, function(key, item) {
        $("#catlist").append("<option id="+item.id+">"+item.Name+"</option>");
    });
    var catid=10;
    $("#catlist").change(function() {
                catid = $(this).find("option:selected").attr("id");
                $("#product").empty();



                $.ajax({
                    url: "http://www.shimply.com/api/search/list",
                    type: "GET",
                    data: { query: "hp", category_id:catid, key: "c8f38932ec7d5142946f247cb6de0325" },
                    dataType: "json",
                    success: function (data) {
                        var i = 1;
                        $.each(data, function (key, item) {
                            var mystar = $("<div>").attr('id', 'rateYo' + i);
                            $(mystar).rateYo(
                            {
                                starWidth: "25px",
                                ratedFill: "gold",
                                onChange: function (rating, rateYoInstance)
                                {
                                    //console.log(rating);
                                }
                            }
                            );
                            var mylink = $("<a></a>").attr({ href: item.permalink, target: "blank" });
                            var mydiv = $("<div></div>").attr({ "class": "mob" }).appendTo(mylink);
                            $("<img class=prod_img>").attr({ src: item.image_url }).appendTo(mydiv);
                            var mydivd = $("<div></div>").attr({ "class": "details" }).appendTo(mydiv);
                            $("<h3></h3>").text(item.name).appendTo(mydivd);
                            $("<p></p>").text("Price Rs." + item.price).appendTo(mydivd);
                            if (item.instock !== "1")
                                $("<p></p>").text("Item Not Available Currently").appendTo(mydivd);
                            mystar.appendTo(mydivd);
                            mylink.appendTo("#product");
                            i++;
                        });


                    },

                    failure: function (msg) {
                        console.log(msg);
                    }

        });



    });


        

    });
