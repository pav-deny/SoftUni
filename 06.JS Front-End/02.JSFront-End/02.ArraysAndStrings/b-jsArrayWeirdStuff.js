let cities = ["Blagoevgrad", "Sofia", "Varna", "Burgas", "Pomorie"];

let [city1, city2, ...beachCities] = cities;

console.log(city1);
console.log(city2);
console.log(beachCities);


function test(...args) {
    console.log(args);
}

test(3, 8, 15, 49, 67, 68, 69)