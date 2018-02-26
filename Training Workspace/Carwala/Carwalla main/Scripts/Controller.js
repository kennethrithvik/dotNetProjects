$(function () {
    initData();
    displayCars(Cars);

    $(".cbrand").change(function () {
        brandClick();
    });
});

function brandClick() {
    var brandSelected = new Array();
    console.clear();
    $(".cbrand").each(function () {
        if ($(this).is(':checked')) {
            console.log($(this).val());
            brandSelected.push($(this).val());
        }
    });
    console.log(brandSelected);
    changedBrandCars(brandSelected);
}

function changedBrandCars(selectedCars) {
    var fCars = new Array();
    $.each(Cars, function (c, car) {
        $.each(selectedCars, function (i, sCar) {
            if (sCar == car.Brand) {
                fCars.push(car);
            }
        });
    });
    console.log(fCars);
    displayCars(fCars);
}
