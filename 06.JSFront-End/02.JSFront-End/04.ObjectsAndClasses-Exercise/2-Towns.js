function solve(input) {
    let citites = input.map(createCity);

    citites.forEach(a => console.log(a));

    function createCity(cityInput) {
        let [town, latitudeStr, longitudeStr] = cityInput.split(" | ");

        let city = {
            town: town,
            latitude: Number(latitudeStr).toFixed(2),
            longitude: Number(longitudeStr).toFixed(2)
        };

        return city;
    }
}

solve(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']);

solve(['Plovdiv | 136.45 | 812.575']);