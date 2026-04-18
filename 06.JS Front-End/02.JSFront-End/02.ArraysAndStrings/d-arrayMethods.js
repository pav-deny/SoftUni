let cities = ["Blagoevgrad", "Sofia", "Varna", "Burgas", "Pomorie"];

console.log(cities);

let removedCity = cities.pop();

console.log(cities);
console.log(removedCity);

cities.push(removedCity);
cities.push("Silistra", "Karlovo");

console.log(cities);

cities.pop();
cities.pop();

console.log(cities);

let removedFirst = cities.shift();
console.log(cities);
console.log(removedFirst);

cities.unshift(removedFirst);
cities.unshift("Kazanlak");

console.log(cities);

cities.shift();
console.log(cities);

let removed = cities.splice(3, 1);
console.log(cities);
console.log(removed);

cities = ["Blagoevgrad", "Sofia", "Varna", "Burgas", "Pomorie"];

console.log(cities);

cities.splice(3, 1, "Kiten");
console.log(cities);

cities.splice(3, 1, "Burgas");
console.log(cities);

cities.splice(3, 0, "Kiten");
console.log(cities);

cities.splice(3, 1);
console.log(cities);

cities.reverse();
console.log(cities);

cities.reverse();
console.log(cities);

console.log(cities.join(" || "));

let beachCities = cities.slice(2, cities.length);
console.log(beachCities);

console.log(cities.includes("Sliven"));
console.log(cities.includes("Varna"));
console.log(cities.includes("varna"));
console.log(cities.includes("Sofia"));
console.log(cities.includes("Godech"));

console.log(cities.indexOf("Varna"));
console.log(cities.indexOf("Pomorie"));
console.log(cities.indexOf("Godech"));
