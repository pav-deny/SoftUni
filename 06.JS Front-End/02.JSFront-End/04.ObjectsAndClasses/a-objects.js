let cities = ["Soifa", "Varna", "Plovdiv"];

let person = ["Pencho", "Minchov", 25, true];

let personObj = {
    firstName: "Pencho",
    lastName: "Minchov",
    age: 25,

    greet: function(name) {
        console.log(`Hello, ${name}!`);
    },

    sayHello() {
        console.log("Hello!");
    }
};

console.log(personObj);
console.log(personObj.lastName);
console.log(personObj["age"]);

personObj.age = 26;
console.log(personObj["age"]);

console.log(personObj.hasGraduated);
personObj.hasGraduated = true;
console.log(personObj.hasGraduated);

personObj.greet("Ginka");

personObj.sayGoodbye = () => console.log("Goodbye");
personObj.sayGoodbye();

let keys = Object.keys(personObj);
console.log(keys);

let values = Object.values(personObj);
console.log(values);

let entries = Object.entries(personObj);
console.log(entries);