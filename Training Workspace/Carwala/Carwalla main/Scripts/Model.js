Fuel = new Array();
Cars = new Array();
Brands = new Array();

function initData() {
    initFuelType();
    initCars();
    initBrands();
}

function initFuelType() {
    Fuel.push("Petrol");
    Fuel.push("Diesel");
    displayFuelType(Fuel);
}

var Car = function (_name, _brand, _price, _description, _fuelType, _image, _model) {
    this.Name = _name,
    this.Brand = _brand,
    this.Price = _price,
    this.Description = _description,
    this.FuelType = _fuelType,
    this.Image = _image,
    this.Model = _model
}

function initCars() {
    var car1 = new Car("Rx 8", "Mazda", "Rs. 25,00,000", "Have used for 3 years", "Petrol", "../../../images/small/1.jpg", "2011");
    var car2 = new Car("i20", "Honda", "Rs. 2,00,000", "Have used for 4 years", "Diesel", "../../../images/small/2.jpg", "2010");
    var car3 = new Car("City", "Honda", "Rs. 5,00,000", "Have used for 5 years", "Petrol", "../../../images/small/3.jpg", "2012");
    var car4 = new Car("A5", "Audi", "Rs. 15,00,000", "Have used for 5 years", "Diesel", "../../../images/small/4.jpg", "2010");
    var car5 = new Car("IndigoXL", "Toyota", "Rs. 7,00,000", "Have used for 5 years", "Diesel", "../../../images/small/5.jpg", "2010");
    var car6 = new Car("Benz", "Mercedes", "Rs. 25,00,000", "Have used for 8 years", "Petrol", "../../../images/small/6.jpg", "2006");
    var car7 = new Car("Indica V2", "Tata", "Rs. 2,00,000", "Have used for 6 years", "Diesel", "../../../images/small/7.jpg", "2008");
    var car8 = new Car("Swift", "Maruti", "Rs. 2,00,000", "Have used for 7 years", "Petrol", "../../../images/small/8.jpg", "2007");
    var car9 = new Car("Sandero", "Renaunt", "Rs. 8,00,000", "Have used for 7 years", "Diesel", "../../../images/small/9.jpg", "2007");
    var car10 = new Car("Civic", "Honda", "Rs. 2,00,000", "Have used for 10 years", "Petrol", "../../../images/small/10.jpg", "2004");
    var car11 = new Car("Fiesta", "Ford", "Rs. 12,00,000", "Have used for 5 years", "Petrol", "../../../images/small/11.jpg", "2009");
    var car12 = new Car("i10", "Honda", "Rs. 2,90,000", "Have used for 3 years", "Petrol", "../../../images/small/12.jpg", "2011");
    var car13 = new Car("Passat", "Volkswagen", "Rs. 17,00,000", "Have used for 6 years", "Petrol", "../../../images/small/13.jpg", "2008");
    
    Cars.push(car1);
    Cars.push(car2);
    Cars.push(car3);
    Cars.push(car4);
    Cars.push(car5);
    Cars.push(car6);
    Cars.push(car7);
    Cars.push(car8);
    Cars.push(car9);
    Cars.push(car10);
    Cars.push(car11);
    Cars.push(car12);
    Cars.push(car13);

    console.log(Cars);
}

function initBrands() {
    $.each(Cars, function (i, car) {
        if ($.inArray(car.Brand, Brands) == -1) {
            Brands.push(car.Brand);
        }
    });
    console.log(Brands);
    dispalyBrands(Brands);
}