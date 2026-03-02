let cities = ["Blagoevgrad", "Sofia", "Varna", "Burgas", "Pomorie"];

cities.forEach(c => console.log(c));

let nums = [4, 5, -10, 2, 23];

let transformedNums = nums.map(n => 2 * n);
console.log(transformedNums);

let sevenLetterCity = cities.find(c => c.length === 7);
console.log(sevenLetterCity);
