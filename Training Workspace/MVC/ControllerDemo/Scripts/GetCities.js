
    $("#StateRefID").change(function () {
        
        $("#CityRefID").empty();
        $.ajax({
            type: "GET",
            url: "http://localhost:7551/State/GetCities",
            datatype: "json",
            data: { id: $("#StateRefID").val() },
            success: function (citys) {
                $.each(JSON.parse(citys), function (i, city) {
                    $("#CityRefID").append("<option value='"+city.CityID+"'>" + city.Name + "</option>");
                    //console.log(city.Name);
                });
            },
            error: function (er) {
                alert(er);
            }
        });
    });
