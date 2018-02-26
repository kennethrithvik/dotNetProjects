function displayFuelType(FuelType) {
    var str = FuelType[0] + "<input type='radio' checked='checked' \
                name='fuel' /> <br/>";
    str = str + FuelType[1] + "<input type='radio' name='fuel'/>";
    $("#fuels").html(str);
}

function dispalyBrands(BrandType) {
    $.each(BrandType, function (i, brand) {
        var str = "<input type='checkbox' class='cbrand' checked='checked' value ='"+brand+"'/>" + brand;
        str = str + "<br/>";
        $("#brands").append(str);
    });
}

function displayCars(SelCars) {
    $("#cars").empty();
    var str = "";
    $.each(SelCars, function (i, car) {
        str = "<div id='car'><div>";
        str = str + "<div id='carimg'><img src=" + car.Image + "></div>";
        str = str + "<div id='cardetails'>";
        str = str + "<div class='carname'>" + car.Name + "</div>";
        str = str + "<div class='carinfo'> Model: " + car.Model + "</div>";
        str = str + "<div class='price'>" + car.Price + "/-</div><br>";
        str = str + "<div class='owner'>" + car.Description + "</div>";
        str = str + "</div></div><div class='clear'></div>";
        $("#cars").append(str);
    });
}